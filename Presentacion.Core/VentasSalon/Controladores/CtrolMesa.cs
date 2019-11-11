namespace Presentacion.Core.Ventas.Controladores
{
    using System.Drawing;
    using XCommerce.AccesoDatos;

    public partial class CtrolMesa : CtrolBase
    {


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
            set
            {
                lblPrecioConsumido.Text=value.ToString("C");
            }
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
                        this.BackColor = Color.Red;
                        reservaMenu.Visible = true;
                        fueraServicioMenu.Visible = true;
                        abrirMenu.Visible = true;
                        break;
                    case EstadoMesa.Abierta:
                        this.BackColor = Color.Green;
                        ActualizarNumero(_mesaId);
                        cancelarVentaMenu.Visible = true;
                        cerrarMenu.Visible = true;
                        break;
                    case EstadoMesa.FueraServicio:
                        this.BackColor = Color.Black;
                        sacarFueraServicioMenu.Visible = true;
                        break;
                    case EstadoMesa.Reservado:
                        this.BackColor = Color.Blue;
                        cancelarReservaMenu.Visible = true;
                        abrirMenu.Visible = true;
                        break;
                    default:
                        this.BackColor = Color.White;
                        break;
                }
            }
        }

        public CtrolMesa()
        {
            InitializeComponent();
            lblNumero.DoubleClick += lblNumero_DoubleClick;
            lblPrecioConsumido.DoubleClick += lblNumero_DoubleClick;

            abrirMenu.Click += abrirMesaToolStripMenuItem_Click;
        }

    }
}
