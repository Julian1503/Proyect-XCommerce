namespace Presentacion.Core.Kiosco
{
    using System.Windows.Forms;
    using Ventas;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Entidad;

    public partial class _10111_BuscarArticulo : _00044_BuscarProducto
    {
        private readonly IArticuloServicio _articuloServicio;
        private long _listaId;
        public _10111_BuscarArticulo():this(new ArticuloServicio())
        {
            InitializeComponent();
            this.Text = "Busqueda de Productos";
        }
        public _10111_BuscarArticulo(long listaId): this()
        {
            _listaId = listaId;
        }
        public _10111_BuscarArticulo(IArticuloServicio articuloServicio)
        {
            _articuloServicio = articuloServicio;
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _articuloServicio.ObtenerProducto(cadena,_listaId);
        }
       
    }
}
