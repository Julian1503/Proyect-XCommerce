namespace Presentacion.Core.Delivery
{
    using Presentacion.Core.Empleado;
    using Presentacion.Core.Kiosco;
    using Presentacion.Core.VentasSalon;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.Cliente.DTOs;
    using XCommerce.Servicio.Core.CompranteMesa.DTOs;
    using XCommerce.Servicio.Core.Delivery;
    using XCommerce.Servicio.Core.Delivery.DTOs;
    using XCommerce.Servicio.Core.Empleado;
    using XCommerce.Servicio.Core.Entidad;

    public partial class ComprobanteDelivery : FormularioBase.FormularioBase
    {
        #region Propiedades
        private readonly IDeliveryServicio _deliveryServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        public DeliveryDto comprobante;
        public ArticuloDto articulo;
        public object EntidadSeleccionada;
        private bool _edicion;
        private ClienteDto _cliente;


        public bool RealizoOperacion { get; set; }
        #endregion

        #region Constructores
        public ComprobanteDelivery() : this(new DeliveryServicio(), new ArticuloServicio(),new EmpleadoServicio(),new ClienteServicio())
        {
            InitializeComponent();
        }

        public ComprobanteDelivery(long id) : this(new DeliveryServicio(), new ArticuloServicio(),new EmpleadoServicio(),new ClienteServicio())
        {
            InitializeComponent();
            comprobante = _deliveryServicio.ObtenerPorId(id);
            _edicion = true;
            ActualizarGrilla();
        }

        public ComprobanteDelivery(IDeliveryServicio deliveryServicio,
            IArticuloServicio articuloServicio,
            IEmpleadoServicio empleadoServicio,
            IClienteServicio clienteServicio)
        {
            if(comprobante==null)
                comprobante = new DeliveryDto();
            _clienteServicio = clienteServicio;
            _deliveryServicio = deliveryServicio;
            _empleadoServicio = empleadoServicio;
            _articuloServicio = articuloServicio;
        }

        #endregion



        #region Metodos
        private void AgregarArticulo()
        {
             var articulo = _articuloServicio.ObtenerProductoPorCodigo(txtCodigos.Text, (long)Entidad.ListaPrecioDeliveryId);

                if (articulo != null)
                {
                    if (articulo.Precio !=null)
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
                                            ArticuloId = articulo.Id,
                                            CodigoProducto = articulo.CodigoBarra,
                                            Descripcion = articulo.Descripcion,
                                            Cantidad = nudCantidad.Value,
                                            PrecioUnitario = (decimal)articulo.Precio
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
                    var fBuscar = new _10111_BuscarArticulo((long)Entidad.ListaPrecioDeliveryId);
                    fBuscar.ShowDialog();
                    if (fBuscar.RealizoOperacion)
                    {
                        txtDescripcion.Text = fBuscar.Descripcion;
                        txtCodigos.Text = fBuscar.Codigo;
                        txtPrecio.Text = fBuscar.Precio;
                    }
                }
        }

        private void Formateo()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }
            dgvGrilla.Columns["CodigoProducto"].Visible = true;
            dgvGrilla.Columns["CodigoProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public void RowEnter(DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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

        private void ActualizarGrilla()
        {
            _cliente = _clienteServicio.ObtenerPorId(comprobante.ClienteId);
            if (_cliente != null)
            {
                txtCliente.Text = _cliente.ApyNom;
                txtCalle.Text = _cliente.Calle;
                txtNumero.Text = _cliente.Numero.ToString();
                txtPiso.Text = _cliente.Piso;
                txtDpto.Text = _cliente.Dpto;
                txtBarrio.Text = _cliente.Barrio;
                txtManz.Text = _cliente.Mza;
                txtLote.Text = _cliente.Lote;
                txtCasa.Text = _cliente.Casa;
            }
            txtCadete.Text = comprobante.CadeteNombreCompleto;
            txtLegajo.Text = comprobante.Legajo.ToString();
            comprobante.Descuento = nudDescuento.Value;
            nudTotal.Value = comprobante.Total;
            nudSubTotal.Value = comprobante.SubTotal;
            dgvGrilla.DataSource = null;
            if(comprobante.Items.Count>0)
            {
                dgvGrilla.DataSource = comprobante.Items;
                Formateo();
            }
        }

        private void nudDescuento_Leave(object sender, EventArgs e)
        {

        }

        //private void btnPagar_Click(object sender, EventArgs e)
        //{
        //    if (nudTotal.Value > 0)
        //    {
        //        ActualizarGrilla();

        //        //var fMensaje = new _0004_Mensaje(comprobante);
        //        //fMensaje.ShowDialog();
        //        //if (fMensaje.RealizoOperacion)
        //        //{
        //        //    for (int i = 0; i < comprobante.Items.Count; i++)
        //        //    {

        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se puede facturar en 0", "Cuidado!");
        //    }

        //}
        #endregion
        
        private void txtCodigos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarArticulo();
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void AgregarCadete()
        {
            BuscarCadete();
        }

        private void BuscarCadete()
        {
            var fBuscarEmpleado = new _10004_BuscarEmpleado(true);
            fBuscarEmpleado.ShowDialog();
            if (fBuscarEmpleado.RealizoOperacion)
            {
                comprobante.CadeteId = fBuscarEmpleado.EmpleadoId;
                comprobante.Legajo = fBuscarEmpleado.Legajo;
                comprobante.CadeteNombre = fBuscarEmpleado.EmpleadoNombre;
                comprobante.CadeteApellido = fBuscarEmpleado.EmpleadoApellido;
                ActualizarGrilla();
                txtCliente.Focus();
            }
        }

        private void ComprobanteDelivery_Load(object sender, EventArgs e)
        {
            //ActualizarGrilla();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            var fCliente = new Cliente._10001_BusquedaCliente();
            fCliente.ShowDialog();
            if (fCliente.RealizoOperacion)
            {
                comprobante.ClienteId = fCliente.ClienteId;
                ActualizarGrilla();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AgregarCadete();
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (nudTotal.Value > 0)
            {
                if (!string.IsNullOrWhiteSpace(txtCadete.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtCliente.Text))
                    {
                        if (!_edicion)
                        {
                            _deliveryServicio.GenerarComprobante(comprobante);
                            RealizoOperacion = true;
                            Notificacion.NotificacionCorrecta.MensajeSatisfactorio("Pedido listo para preparar");
                            this.Close();
                        }
                        else
                        {
                            _deliveryServicio.EditarComprobante(comprobante);
                            RealizoOperacion = true;
                            Notificacion.NotificacionCorrecta.MensajeSatisfactorio("Pedido editado");
                            this.Close();
                        }
                    }
                    else
                    {
                       Notificacion.NotificacionIncorrecta.MensajeCuidado("Sin cliente","Ingrese el cliente que realizo el pedido");
                    }
                }
                else
                {
                     Notificacion.NotificacionIncorrecta.MensajeCuidado("Sin cadete", "Ingrese el cadete que llevara la orden");
                }
            }
            else
            {

                Notificacion.NotificacionIncorrecta.MensajeCuidado("No se puede facturar en 0", "Para realizar un pedido debe tener al menos 1 producto");
            }
        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var cadete =_empleadoServicio.ObtenerIdPorLegajo(txtLegajo.Text, Entidad.CategoriaCadeteDescripcion);
                if (cadete != null)
                {
                    comprobante.CadeteId = cadete.Id;
                    comprobante.Legajo = cadete.Legajo;
                    comprobante.CadeteNombre = cadete.Nombre;
                    comprobante.CadeteApellido = cadete.Apellido;
                    ActualizarGrilla();
                }
                else
                {
                    BuscarCadete();
                }
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarCliente();
            }
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
