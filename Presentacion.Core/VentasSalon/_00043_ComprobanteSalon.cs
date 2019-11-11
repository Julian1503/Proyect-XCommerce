using Presentacion.Core.VentasSalon;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.Precio;

namespace Presentacion.Core.Ventas
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Empleado;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.CompranteMesa;
    using XCommerce.Servicio.Core.Empleado;
    using XCommerce.Servicio.Core.Entidad;

    public partial class x : FormularioBase.FormularioBase
    {
        private readonly IComprobanteMesaServicio _mesaServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IPrecioServicio _precioServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        private long _mesaId;
        public object EntidadSeleccionada;
        public decimal Total;

        public x()
        {
            InitializeComponent();
        }

        public x(long mesaId, int numeroMesa) : this(new ArticuloServicio(),new PrecioServicio(), 
            new ComprobanteMesaServicio(), new EmpleadoServicio())
        {
            this.Text = $"Mesa {numeroMesa}";
            this._mesaId = mesaId;
            ObtenerComprobanteMesa(mesaId);
        }
        public x(IArticuloServicio articuloServicio,IPrecioServicio precioServicio,
            IComprobanteMesaServicio comprobanteMesa, IEmpleadoServicio empleadoServicio) : this()
        {
            _precioServicio = precioServicio;
            _articuloServicio = articuloServicio;
            _mesaServicio = comprobanteMesa;
            _empleadoServicio = empleadoServicio;
        }

        private void ObtenerComprobanteMesa(long mesaId)
        {
            ActualizarGrilla(mesaId);
        }

        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public void RowEnter(DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount>0)
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        private void ActualizarGrilla(long mesaId)
        {
            var comprobante = _mesaServicio.ObtenerComprobanteMesa(mesaId);
            dgvGrilla.DataSource = comprobante.Items.Where(x=>x.Cantidad>0).ToList();
            //TODO
            //dgvGrilla.Columns.Add(
            //   _columnButton = new DataGridViewButtonColumn()
            //   {
            //       Name = "Borrar",
            //       HeaderText = "Borrar",
            //       AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            //       FlatStyle = FlatStyle.Flat,
            //       DefaultCellStyle = new DataGridViewCellStyle
            //       {
            //           Padding = new Padding(10, 0, 10, 0),
            //           SelectionBackColor = Color.Orange,
            //           Alignment = DataGridViewContentAlignment.MiddleCenter,
            //           WrapMode=DataGridViewTriState.True
            //       }
            //       , FillWeight = 30,
            //       ValueType = typeof(Button),
            //       Text = "X",
            //   }
            //    );
            txtNombre.Text = comprobante.DniCliente=="99999999"? comprobante.ApyNomCl :comprobante.ContactoCliente;
            txtMozo.Text = comprobante.ApyNomMozo;
            txtLegajo.Text = comprobante.Legajo.ToString();
            nudSubTotal.Value = comprobante.SubTotal;
            nudDescuento.Value = comprobante.Descuento;
            nudComensales.Value = comprobante.Comensal;
            nudTotal.Value = comprobante.Total;
            Total = comprobante.Total;
            txtCodigos.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            nudCantidad.Value = 1m;

        }

        private void txtCodigos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                AgregarArticulo();
            }
        }

        private void AgregarArticulo()
        {
            var articulo = _articuloServicio.ObtenerPorCodigo(_mesaId, txtCodigos.Text);
            if (articulo != null)
            {
                if (articulo.Precio !=null)
                {
                    var precio = _precioServicio.Obtener(_mesaId, articulo.Id);

                if (!precio.ActivarHoraVenta || (precio.ActivarHoraVenta && (precio.FechaActualizacion.TimeOfDay >= DateTime.Now.TimeOfDay)))
                {
                   
                        if (!articulo.EstaDiscontinuado && !articulo.EstaEliminado)
                        {
                            if (!articulo.ActivarLimiteVenta || articulo.LimiteVenta >= nudCantidad.Value)
                            {

                                if (articulo.Stock >= nudCantidad.Value || articulo.PermiteStockNegativo ||
                                    !articulo.DescuentaStock)
                                {
                                    _mesaServicio.AgregarArticulo(_mesaId, articulo, nudCantidad.Value);

                                    ActualizarGrilla(_mesaId);
                                    if (articulo.StockMinimo >= articulo.Stock)
                                    {
                                        MessageBox.Show(
                                            $"Debe recargar el Stock de {articulo.Descripcion}! (Stock inferior al Stock Minimo)",
                                            $"Recarga de Stock de {articulo.Descripcion}", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(@"No se pudo realizar la operacion por falta de Stock", "Atencion",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(@"No se pudo realizar la operacion por limite de venta", "Atencion",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                @"No se pudo realizar la operacion el articulo esta eliminado/descontinuado.",
                                "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            $"No se pudo agregar el producto: '{articulo.Descripcion} ya que termino la hora de venta.",
                            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                    else
                    {
                        MessageBox.Show(
                            $"No se pudo agregar el producto: '{articulo.Descripcion} ya que carece de precio en este salon.",
                            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
               

            }
            else
            {
                var fBuscar = new _00044_BuscarProducto(_mesaId);
                fBuscar.ShowDialog();
                if (fBuscar.RealizoOperacion)
                {
                    txtDescripcion.Text = fBuscar.Descripcion;
                    txtCodigos.Text = fBuscar.Codigo;
                    txtPrecio.Text = fBuscar.Precio;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AgregarMozo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                AgregarMozo();
            }
        }

        private void AgregarMozo()
        {
            var mozo = _empleadoServicio.ObtenerIdPorLegajo(txtLegajo.Text,Entidad.CategoriaMozoDescripcion);
            if (mozo != null)
            {
                _mesaServicio.AgregarMozo(_mesaId, mozo.Id);
                ActualizarGrilla(_mesaId);
                    txtNombre.Focus();
            }
            else
            {
                var fBuscarEmpleado = new _10004_BuscarEmpleado();
                fBuscarEmpleado.ShowDialog();
                if (fBuscarEmpleado.RealizoOperacion)
                {
                    _mesaServicio.AgregarMozo(_mesaId, fBuscarEmpleado.EmpleadoId);
                    ActualizarGrilla(_mesaId);
                    txtNombre.Focus();
                }
            }
        }

        private void x_Load(object sender, EventArgs e)
        {
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvGrilla.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvGrilla.Columns["CodigoProducto"].HeaderText = @"Codigo";
            dgvGrilla.Columns["PrecioUnitario"].HeaderText = @"Precio por Unidad";
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                nudTotal.Value = nudSubTotal.Value - CalcularDescuento.Calcular(nudDescuento.Value, nudSubTotal.Value);
                Total = nudTotal.Value;
            }
        }

        private void x_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mesaServicio.AgregarAlComprobante(_mesaId, (int) nudComensales.Value, nudDescuento.Value, nudTotal.Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            var fElim = new _10013_EliminarProductos(((DetalleComprobanteDto)EntidadSeleccionada));
            fElim.ShowDialog();
            if (fElim.RealizoOperacion)
            {
               _mesaServicio.EliminarProducto(_mesaId,_articuloServicio.ObtenerPorCodigo(_mesaId, ((DetalleComprobanteDto)EntidadSeleccionada).CodigoProducto), fElim.Cantidad);
                ActualizarGrilla(_mesaId);
                MessageBox.Show("Se quito con exito");
                EntidadSeleccionada = null;
            }
        }

        private void dgvGrilla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewColumn oDGVC = dgvGrilla.Columns[e.ColumnIndex];
            string sTextoMensaje = "Error en la columna: " + oDGVC.DataPropertyName + "\n" + e.Exception.Message;
            e.Cancel = false;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {

            }
        }
    }
}