namespace Presentacion.Core.VentasSalon
{
    using XCommerce.Servicio.Core.CompranteMesa.DTOs;

    public partial class _10013_EliminarProductos : FormularioBase.FormularioBase
    {
        private DetalleComprobanteDto _detalleComprobanteDto;
        public bool RealizoOperacion { get; set; }
        public decimal Cantidad { get; private set; }

        public _10013_EliminarProductos()
        {
            InitializeComponent();
            RealizoOperacion = false;
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
        }


        public _10013_EliminarProductos(DetalleComprobanteDto detalleComprobanteDto):this()
        {
            _detalleComprobanteDto = detalleComprobanteDto;
            nudDisminuir.Maximum = _detalleComprobanteDto.Cantidad;
        }

        private void _10013_EliminarProductos_Load(object sender, System.EventArgs e)
        {
            if (_detalleComprobanteDto != null)
            {
                txtCantidad.Text = _detalleComprobanteDto.Cantidad.ToString();
                txtSubtotal.Text = _detalleComprobanteDto.SubTotal.ToString("C");
                nudDisminuir.Maximum = _detalleComprobanteDto.Cantidad;
            }
        }

        private void nudDisminuir_ValueChanged(object sender, System.EventArgs e)
        {
            if(_detalleComprobanteDto!=null)
            {
                txtCantidad.Text = (_detalleComprobanteDto.Cantidad - nudDisminuir.Value).ToString();
                txtSubtotal.Text =
                    ((_detalleComprobanteDto.Cantidad - nudDisminuir.Value) * _detalleComprobanteDto.PrecioUnitario)
                    .ToString();
            }
        }
        
        private void btnSacar_Click(object sender, System.EventArgs e)
        {
            if (nudDisminuir.Value != 0)
            {
                RealizoOperacion = true;
                Cantidad = nudDisminuir.Value;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
