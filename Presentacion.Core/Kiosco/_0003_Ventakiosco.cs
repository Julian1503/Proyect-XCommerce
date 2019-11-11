using Presentacion.Core.Kiosco;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;

namespace Presentacion.Core.VentaKiosco
{
    using Presentacion.Core.FormaPago;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using VentasSalon;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.ComprobanteKiosco.DTOs;
    using XCommerce.Servicio.Core.Entidad;
    using XCommerce.Servicio.Core.Kiosco;

    public partial class _0003_Ventakiosco : FormularioBase.FormularioBase
    {
        #region Propiedades
        private readonly IKioscoServicio _kioscoServicio;
        private readonly IArticuloServicio _articuloServicio;
        public ComprobanteKioscoDto comprobante;
        public ArticuloDto articulo;
        public object EntidadSeleccionada;
        decimal Cantidad;

        #endregion

        #region Constructores
        public _0003_Ventakiosco() : this(new KioscoServicio(), new ArticuloServicio())
        {
            InitializeComponent();
        }
        public _0003_Ventakiosco(IKioscoServicio kioscoServicio, IArticuloServicio articuloServicio)
        {
            _kioscoServicio = kioscoServicio;
            articulo = new ArticuloDto();
            _articuloServicio = articuloServicio;
            comprobante = new ComprobanteKioscoDto();
        }
        #endregion

        #region Metodos

        private void txtCodigos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarArticulo();
            }
        }

        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
              RowEnter(e);
        }

        public void RowEnter(DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                EntidadSeleccionada = null;
            }
        }

        private void ActualizarGrilla()
        {
            dgvGrilla.DataSource = null;
            comprobante.Descuento = nudDescuento.Value;
            nudTotal.Value = comprobante.Total;
            nudSubTotal.Value = comprobante.SubTotal;
           if (comprobante.Items.Count > 0)
            {
                dgvGrilla.DataSource = comprobante.Items;
            Formateo();
            }
        }

        private void AgregarArticulo()
        {
          
                var articulo = _articuloServicio.ObtenerProductoPorCodigo(txtCodigos.Text, (long)Entidad.ListaPrecioKioscoId);

                if (articulo != null)
                {
                    if (articulo.Precio!=null)
                    {
                        if (!articulo.EstaDiscontinuado && !articulo.EstaEliminado)
                        {
                            if (!articulo.ActivarLimiteVenta || articulo.LimiteVenta >= nudCantidad.Value)
                            {
                                if (articulo.Stock >= nudCantidad.Value || articulo.PermiteStockNegativo || !articulo.DescuentaStock)
                                {

                                    if (articulo.StockMinimo >= articulo.Stock && articulo.DescuentaStock)
                                    {
                                        MessageBox.Show($"Debe recargar el Stock de {articulo.Descripcion}!",
                                            $"Recarga de Stock de {articulo.Descripcion}", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        txtDescripcion.Text = articulo.Descripcion;
                                        txtPrecio.Text = articulo.Precio.ToString();


                                        var _articulo = new DetalleComprobanteDto
                                        {
                                            ArticuloId=articulo.Id,
                                            CodigoProducto = articulo.CodigoBarra,
                                            Descripcion = articulo.Descripcion,
                                            Cantidad = nudCantidad.Value,
                                            PrecioUnitario = (decimal) articulo.Precio
                                        };


                                        if (!comprobante.Items.Any(x =>
                                            x.Descripcion == _articulo.Descripcion &&
                                            x.CodigoProducto == _articulo.CodigoProducto))
                                        {
                                            comprobante.Items.Add(_articulo);
                                        }
                                        else
                                        {
                                            var articuloASumar = comprobante.Items
                                                .FirstOrDefault(x => x.CodigoProducto == _articulo.CodigoProducto);
                                            if (articuloASumar.Cantidad + _articulo.Cantidad <= articulo.Stock)
                                            {
                                                articuloASumar.Cantidad += _articulo.Cantidad;
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Su stock es de {articulo.Stock - articuloASumar.Cantidad}, no puede agregar {nudCantidad.Value} productos");
                                            }
                                        }

                                        ActualizarGrilla();
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
                                @"No se pudo realizar la operacion el articulo esta eliminado/descontinuado",
                                "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo agregar el producto: '{articulo.Descripcion}' ya que carece de precio en este salon",
                            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    var fBuscar = new _10111_BuscarArticulo((long)Entidad.ListaPrecioKioscoId);
                    fBuscar.ShowDialog();
                    if (fBuscar.RealizoOperacion)
                    {
                        txtDescripcion.Text = fBuscar.Descripcion;
                        txtCodigos.Text = fBuscar.Codigo;
                        txtPrecio.Text = fBuscar.Precio;
                    }
                }
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigos.Text))
            {
            AgregarArticulo();
            }
            else
            {
                MessageBox.Show("Ingrese algun codigo de producto", "Advertencia");
            }
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarGrilla();
            }

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (nudTotal.Value > 0)
            {
                ActualizarGrilla();

                var fMensaje = new FormaPagoKiosco(comprobante);
                fMensaje.ShowDialog();
                if (fMensaje.Realizo)
                {
                    for (int i = 0; i < comprobante.Items.Count; i++)
                    {
                        _kioscoServicio.AgregarProducto(comprobante.Items[i], _articuloServicio.ObtenerProductoPorCodigo(comprobante.Items[i].CodigoProducto,(long) Entidad.ListaPrecioKioscoId).Id);
                    }
                    cerrandoFormPiezas();
                    Entidad.VentasHoy++;
                }
            }
            else
            {
                MessageBox.Show("No se puede facturar en 0", "Cuidado!");
            }

        }

        private void cerrandoFormPiezas()
        {
            this.txtCodigos.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            comprobante.Items.Clear();
            this.nudSubTotal.Value = 0;
            this.nudTotal.Value = 0;
            this.nudDescuento.Value = 0;
            this.txtPrecio.Text = string.Empty;
            dgvGrilla.DataSource = null;
        }

        private void Formateo()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["CodigoProducto"].Visible = true;
            dgvGrilla.Columns["CodigoProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ;
            dgvGrilla.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["CodigoProducto"].HeaderText = @"Codigo de Barras";
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgvGrilla.Columns["PrecioUnitario"].Visible = true;
            dgvGrilla.Columns["PrecioUnitario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["PrecioUnitario"].HeaderText = @"Precio Unitario";
            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["SubTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["SubTotal"].HeaderText = @"SubTotal";
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
                var n = comprobante.Items.FirstOrDefault(x =>
                    x.CodigoProducto == ((DetalleComprobanteDto)EntidadSeleccionada).CodigoProducto);
                if (n.Cantidad == fElim.Cantidad)
                {
                    comprobante.Items.Remove(n);
                }
                else
                {
                    n.Cantidad -= fElim.Cantidad;
                }
                EntidadSeleccionada = null;
                ActualizarGrilla();

                MessageBox.Show("Se quito con exito");
            }
        }

        private void pnlProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nudDescuento_Leave(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void _0003_Ventakiosco_Load(object sender, EventArgs e)
        {
            //ActualizarGrilla();
        }
         private void dgvGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '-')
            {
                if (EntidadSeleccionada == null)
                {
                    return;
                }
                        var n = comprobante.Items.FirstOrDefault(x =>
                            x.CodigoProducto == ((DetalleComprobanteDto)EntidadSeleccionada).CodigoProducto);
                        if (n.Cantidad == 1)
                        {
                            comprobante.Items.Remove(n);
                        }
                        else
                        {
                            n.Cantidad -= 1;
                        }
                        EntidadSeleccionada = null;
                        ActualizarGrilla();
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

