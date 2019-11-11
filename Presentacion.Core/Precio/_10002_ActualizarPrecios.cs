namespace Presentacion.Core.Precio
{
    using System;
    using System.Windows.Forms;
    using Articulo;
    using Helpers;
    using ListaPrecios;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.CompranteMesa;
    using XCommerce.Servicio.Core.ListaPrecio;
    using XCommerce.Servicio.Core.ListaPrecio.DTOs;
    using XCommerce.Servicio.Core.Precio;
    using XCommerce.Servicio.Core.Precio.DTOs;

    public partial class _10002_ActualizarPrecios : FormularioBase.FormularioBase
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IListaPreciosServicio _listaPreciosServicio;
        private readonly IPrecioServicio _precioServicio;
        private decimal _rentabilidad;

        public _10002_ActualizarPrecios() 
        {
            InitializeComponent();
            _articuloServicio = new ArticuloServicio();
            _listaPreciosServicio = new ListaPreciosServicio();
            _precioServicio = new PrecioServicio();
            btnEjecutar.Image = Constantes.ImagenesSistema.Ejecutar;
            btnLimpiar.Image = Constantes.ImagenesSistema.Limpiar;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
            Inicializar();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
        }
        
        public bool RealizoOperacion { get; set; }

        private void Inicializar()
        {
            RealizoOperacion = false;
            CargarComboBox(cmbLista,_listaPreciosServicio.Obtener(string.Empty),"Descripcion","Id");
            CargarComboBox(cmbProducto,_articuloServicio.Obtener(string.Empty),"Descripcion","Id");
            cmbLista.SelectedItem = 0;
            cmbProducto.SelectedItem = 0;
            if (cmbLista.Items.Count > 0)
            {
                ActualizarRentabilidad();
            }
        }

        private void ActualizarRentabilidad()
        {
            _rentabilidad = _listaPreciosServicio.ObtenerPorId(((ListaPreciosDto)cmbLista.SelectedItem).Id).Rentabilidad;

        }

        private void cbActivarHora_CheckedChanged(object sender, System.EventArgs e)
        {
            lblHoraVenta.Enabled = cbActivarHora.Checked ? true : false;
            dtpHoraVenta.Enabled = cbActivarHora.Checked ? true : false;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (nudPrecioCosto.Value <= nudPrecioPublico.Value)
            {
                var precioNuevo = new PrecioDto
                {
                    ActivarHoraVenta = cbActivarHora.Checked,
                    ArticuloId = ((ArticuloDto)cmbProducto.SelectedItem).Id,
                    ListaPrecioId = ((ListaPreciosDto)cmbLista.SelectedItem).Id,
                    FechaActualizacion = DateTime.Now,
                    HoraVenta = dtpHoraVenta.Value,
                    PrecioCosto = nudPrecioCosto.Value,
                    PrecioPublico = nudPrecioPublico.Value
                };
                _precioServicio.Agregar(precioNuevo);
                RealizoOperacion = true;
                Limpiar(this);
                MessageBox.Show(@"Se cargaron los datos correctamente", @"Atencion");
            }
            else
            {
                MessageBox.Show("El precio publico no debe ser menor al costo", "Atencion", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro de limpiar el formulario?","Atencion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            Limpiar(this);
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            var fNuevaLista = new _00026_ABM_ListaPrecios(TipoOp.Nuevo);
            fNuevaLista.ShowDialog();

            if (!fNuevaLista.RealizoAlgunaOperacion) return;
            CargarComboBox(cmbLista, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");


        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var fNuevoProducto = new _00010_ABM_Articulo(TipoOp.Nuevo);
            fNuevoProducto.ShowDialog();

            if (!fNuevoProducto.RealizoAlgunaOperacion) return;
            CargarComboBox(cmbProducto, _articuloServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLista_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarRentabilidad();
            ActualizarPrecioPublico();
        }

        private void nudPrecioCosto_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrecioPublico();
        }

        private void ActualizarPrecioPublico()
        {
            nudPrecioPublico.Value =
                nudPrecioCosto.Value + CalcularDescuento.Calcular(_rentabilidad, nudPrecioCosto.Value);
        }

        private void nudPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                ActualizarPrecioPublico();
            }
        }
    }
}

