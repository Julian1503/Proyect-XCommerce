namespace Presentacion.Core.VentaKiosco
{
    using System;
    using System.Windows.Forms;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.ComprobanteKiosco.DTOs;
    using XCommerce.Servicio.Core.Kiosco;
    using XCommerce.Servicio.Core.Movimiento;

    public partial class _0004_Mensaje : FormularioBase.FormularioBase
    {
        private  TipoComprobante tipoComprobante;
        private readonly IKioscoServicio _kioscoServicio;
        private ComprobanteKioscoDto comprobanteKioscoDto;
        private ArticuloDto articulo;

        public _0004_Mensaje() 
        {
            InitializeComponent();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;

        }
        public _0004_Mensaje(ComprobanteKioscoDto compro) :this()
        {
            comprobanteKioscoDto = compro;
            _kioscoServicio = new KioscoServicio();
            RealizoOperacion = false;
            Cargartxt();
            cmbTipoFactura.SelectedIndex = 0;
            tipoComprobante = TipoComprobante.A;
        }

        public bool RealizoOperacion { get; set; }

        public void Cargartxt()
        {
            txtFinal.Text = comprobanteKioscoDto.Total.ToString("C");
        }

    private void btnPagar_Click(object sender, EventArgs e)
        {
            _kioscoServicio.CerrarKiosco(comprobanteKioscoDto, tipoComprobante);
            MessageBox.Show(@"Su Factura se esta imprimiendo"
                , @"Venta Realizada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RealizoOperacion = true;
            this.Close();

        }

        private void cmbTipoFactura_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cmbTipoFactura.SelectedIndex)
            {
                case 0:
                    tipoComprobante = TipoComprobante.A;
                    break;

                case 1:
                    tipoComprobante = TipoComprobante.B;

                    break;
                case 2:
                    tipoComprobante = TipoComprobante.C;

                    break;
                case 3:
                    tipoComprobante = TipoComprobante.X;

                    break;

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
