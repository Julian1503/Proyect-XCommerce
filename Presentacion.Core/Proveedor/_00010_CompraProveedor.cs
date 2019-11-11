using Presentacion.Core.FormaPago;
using Presentacion.Core.Kiosco;
using Presentacion.Core.ListaPrecios;
using Presentacion.Core.VentasSalon;
using System;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.ComprobanteCompra;
using XCommerce.Servicio.Core.ComprobanteCompra.DTOs;
using XCommerce.Servicio.Core.Entidad;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.Proveedor;

namespace Presentacion.Core.Proveedor
{
    public partial class _00010_CompraProveedor : FormularioBase.FormularioBase
    {
        public object EntidadSeleccionada;
        public decimal Total;
        private long _listaId;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IListaPreciosServicio _listaPrecioServicio;
        private readonly IProveedorServicio _proveedorServicio;
        private readonly IComprobanteCompraServicio _comprobanteCompraServicio;
        private ComprobanteCompraDto comprobante;

        public bool RealizoOperacion { get; private set; }

        public _00010_CompraProveedor() :this(new ArticuloServicio(),new ListaPreciosServicio(),new ProveedorServicio(),new ComprobanteCompraServicio())
        {
            InitializeComponent();
        }
        public _00010_CompraProveedor(IArticuloServicio articuloServicio, IListaPreciosServicio listaPrecioServicio, IProveedorServicio proveedorServicio,IComprobanteCompraServicio comprobanteCompraServicio)
        {
            _comprobanteCompraServicio = comprobanteCompraServicio;
            _articuloServicio = articuloServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _proveedorServicio = proveedorServicio;
            comprobante = new ComprobanteCompraDto();
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
        private void AgregarArticulo()
        {
            var articulo = _articuloServicio.ObtenerProductoPorCodigo(txtCodigos.Text, _listaId);

            if (articulo != null)
            {
                if (articulo.PrecioCosto != null)
                {
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();


                    var _articulo = new DetalleComprobanteDto
                    {
                        ArticuloId = articulo.Id,
                        CodigoProducto = articulo.CodigoBarra,
                        Descripcion = articulo.Descripcion,
                        Cantidad = nudCantidad.Value,
                        PrecioUnitario = (decimal)articulo.PrecioCosto,
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
                            .FirstOrDefault(x => x.ArticuloId == _articulo.ArticuloId);
                            articuloASumar.Cantidad += _articulo.Cantidad;
                    }


                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show($"No se pudo agregar el producto: '{articulo.Descripcion}' ya que carece de precio en este salon",
                        "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                var fBuscar = new _10111_BuscarArticulo(_listaId);
                fBuscar.ShowDialog();
                if (fBuscar.RealizoOperacion)
                {
                    txtDescripcion.Text = fBuscar.Descripcion;
                    txtCodigos.Text = fBuscar.Codigo;
                    txtPrecio.Text = fBuscar.Precio;
                }
            }
        }

        private void ActualizarGrilla()
        {
            dgvGrilla.DataSource = null;
            comprobante.Descuento = nudDescuento.Value;
            nudTotal.Value = comprobante.Total;
            nudSubTotal.Value = comprobante.SubTotal;
            dgvGrilla.DataSource = comprobante.Items;
            Formateo();
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
            dgvGrilla.Columns["PrecioUnitario"].HeaderText = @"Precio Costo";
            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["SubTotal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["SubTotal"].HeaderText = @"SubTotal";
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarGrilla();
            }

        }
        private void pnlProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCodigos_Click(object sender, EventArgs e)
        {

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

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                var fProveedor = new _00001_SeleccionProveedor();
                fProveedor.ShowDialog();
                if (fProveedor.RealizoOperacion)
                {
                    comprobante.ProveedorId = fProveedor.ProveedorId;
                    txtProveedor.Text = _proveedorServicio.ObtenerPorId(comprobante.ProveedorId).Contacto;
                }
            }
        }

        private void txtLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var fLista = new ListaPreciosBusqueda();
                fLista.ShowDialog();
                if (fLista.RealizoOperacion)
                {
                    _listaId = fLista.ListaId;
                    txtLista.Text = fLista.ListaNombre;
                }
            }
        }

        private void txtCodigos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarArticulo();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (nudTotal.Value > 0)
            {
                if (!string.IsNullOrWhiteSpace(txtLista.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtProveedor.Text))
                    {
                        var fPago = new FormaPagoCompra(comprobante);
                        fPago.ShowDialog();
                        if (fPago.Realizo)
                        {
                            MessageBox.Show("Se esta imprimiendo el comprobante");
                            RealizoOperacion = true;
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el cliente que realizo el pedido");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el cadete que llevara la orden");
                }
            }
            else
            {

                MessageBox.Show("No se puede facturar en 0");
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
    }
}
