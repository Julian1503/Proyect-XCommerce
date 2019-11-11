namespace Presentacion.Core.Ventas.Controladores
{
    using System.Drawing;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.CompranteMesa;

    public partial class CtrolMesaRedonda : CtrolBase
    {
        private readonly IComprobanteMesaServicio _comprobanteServicio;

        public override int Numero
        {
            set
            {
                _numeroMesa = value;
                lblNumero.Text = $"{value}";
            }
        }

        public override decimal PrecioConsumido
        {
            set { lblPrecioConsumido.Text = value.ToString("C"); }
        }

        public override EstadoMesa EstadoMesa
        {
            set
            {
                _estadoMesa = value;
                abrirMenu.Visible = false;
                cerrarMenu.Visible = false;
                reservaMenu.Visible = false;
                fueraServicioMenu.Visible = false;
                sacarFueraServicioMenu.Visible = false;
                cancelarReservaMenu.Visible = false;
                        cancelarVentaMenu.Visible = false;
                switch (value)
                {
                    case EstadoMesa.Cerrada:
                        Circulo.BackColor = Color.Red;
                        lblPrecioConsumido.BackColor = Color.Red;
                        lblNumero.BackColor = Color.Red;
                        reservaMenu.Visible = true;
                        fueraServicioMenu.Visible = true;
                        abrirMenu.Visible = true;
                        break;
                    case EstadoMesa.Abierta:
                        Circulo.BackColor = Color.Green;
                        lblPrecioConsumido.BackColor = Color.Green;
                        lblNumero.BackColor = Color.Green;
                        ActualizarNumero(_mesaId);
                        cancelarVentaMenu.Visible = true;
                        cerrarMenu.Visible = true;
                        break;
                    case EstadoMesa.FueraServicio:
                        Circulo.BackColor = Color.Black;
                        lblPrecioConsumido.BackColor = Color.Black;
                        lblNumero.BackColor = Color.Black;
                        sacarFueraServicioMenu.Visible = true;
                        break;
                    case EstadoMesa.Reservado:
                        Circulo.BackColor = Color.Blue;
                        lblPrecioConsumido.BackColor = Color.Blue;
                        lblNumero.BackColor = Color.Blue;
                        cancelarReservaMenu.Visible = true;
                        abrirMenu.Visible = true;
                        break;
                    default:
                        Circulo.BackColor = Color.White;
                        lblPrecioConsumido.BackColor = Color.White;
                        lblNumero.BackColor = Color.White;
                        break;
                }
            }
        }

        public CtrolMesaRedonda() 
        {
            InitializeComponent();
            lblNumero.DoubleClick += lblNumero_DoubleClick;
            lblPrecioConsumido.DoubleClick += lblNumero_DoubleClick;
            abrirMenu.Click += abrirMesaToolStripMenuItem_Click;
        }

    }


}

