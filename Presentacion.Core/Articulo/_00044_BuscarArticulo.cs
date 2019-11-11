namespace Presentacion.Core.Ventas
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using System.Linq;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;

    public partial class _00044_BuscarProducto : FormularioBusqueda
    {
        private readonly IArticuloServicio _articuloServicio;

        public string Codigo { get; private set; }

        public string Descripcion { get; private set; }

        public string Precio { get; private set; }

        private long _mesaId;

        public _00044_BuscarProducto() 
        {
            InitializeComponent();
            _articuloServicio = new ArticuloServicio();
            Codigo = "";
            Descripcion = "";
            Precio = "";
        }
        
        public _00044_BuscarProducto(long mesaId)
        {
            InitializeComponent();
            _mesaId = mesaId;
            _articuloServicio = new ArticuloServicio();
            Codigo = "";
            Descripcion = "";
            Precio = "";
        }
        

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 75;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["CodigoBarra"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].HeaderText = @"Codigo de Barras";
            dgvGrilla.Columns["CodigoBarra"].Width = 100;

            dgvGrilla.Columns["Precio"].Visible = true;
            dgvGrilla.Columns["Precio"].HeaderText = @"Precio Unitario";
            dgvGrilla.Columns["Precio"].Width = 75;

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = @"Precio Costo";
            dgvGrilla.Columns["PrecioCosto"].Width = 75;

            dgvGrilla.Columns["Stock"].Visible = true;
            dgvGrilla.Columns["Stock"].Width = 75;

        }


        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _articuloServicio.ObtenerSinEliminados(cadena, _mesaId);
        }


        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccion una fila");
                return;
            }
            Codigo = ((ArticuloDto)EntidadSeleccionada).Codigo;
            Descripcion = ((ArticuloDto)EntidadSeleccionada).Descripcion;
            Precio = ((ArticuloDto)EntidadSeleccionada).Precio.ToString();
            RealizoOperacion = true;
            this.Close();
        }
    }
}
