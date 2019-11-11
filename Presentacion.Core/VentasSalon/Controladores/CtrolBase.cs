using System.Linq;
using XCommerce.Servicio.Core.Reserva.DTOs;

namespace Presentacion.Core.Ventas.Controladores
{
    using Presentacion.Core.FormaPago;
    using System.Windows.Forms;
    using VentasSalon;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.CompranteMesa;
    using XCommerce.Servicio.Core.Entidad;
    using XCommerce.Servicio.Core.Mesa;
    using XCommerce.Servicio.Core.Reserva;

    public partial class CtrolBase : UserControl
    {
        private readonly IComprobanteMesaServicio _comprobanteServicio;
        private readonly IReservaServicio _reservaServicio;
        protected long _mesaId;

        public long MesaId
        {
            set { _mesaId = value; }
        }
        public virtual int Numero { get; set; }

        public virtual decimal PrecioConsumido { get; set; }
        private readonly IMesaServicio _mesa;

        protected int _numeroMesa;
        protected EstadoMesa _estadoMesa;
        public virtual EstadoMesa EstadoMesa { get; set; }

        public CtrolBase() : this(new ReservaServicio(), new ComprobanteMesaServicio(),new MesaServicio())
        {
            InitializeComponent();
            
        }

        public CtrolBase(IReservaServicio reservaServicio,IComprobanteMesaServicio comprobanteMesaServicio, IMesaServicio mesaServicio)
        {
            _reservaServicio = reservaServicio;
            _comprobanteServicio = comprobanteMesaServicio;
            _mesa = mesaServicio;
        }

        protected void lblNumero_DoubleClick(object sender, System.EventArgs e)
        {
            EjecutarFomularioComprobante();
        }

        protected void ActualizarNumero(long mesaId)
        {
            PrecioConsumido = _comprobanteServicio.ObtenerComprobanteMesa(mesaId).Total;
        }

        private void EjecutarFomularioComprobante()
        {
            if (_estadoMesa == EstadoMesa.Cerrada || _estadoMesa == EstadoMesa.Reservado)
            {
                _comprobanteServicio.Abrir(_mesaId, Entidad.UsuarioId, 1);
                if (_estadoMesa == EstadoMesa.Reservado)
                {
                    var a = _reservaServicio.Obtener(string.Empty).FirstOrDefault(x =>
                        x.MesaId == _mesaId && x.EstadoReserva == EstadoReserva.Confirmada);
                    if(a!=null)
                    _reservaServicio.Modificar(new ReservaDto
                    {
                        Id = a.Id,
                        EstadoReserva = EstadoReserva.Finalizada,
                        Fecha = a.Fecha,
                        ClienteId = a.ClienteId,
                        MotivoReservaId = a.MotivoReservaId,
                        Senia = a.Senia,
                        UsuarioId = a.UsuarioId,
                        MesaId = a.MesaId
                    });
                }
                EstadoMesa = EstadoMesa.Abierta;
            }

            if (_estadoMesa == EstadoMesa.Abierta)
            {
                var fComprobante = new x(_mesaId, _numeroMesa);
                fComprobante.ShowDialog();
                ActualizarNumero(_mesaId);
            }
        }

        protected void abrirMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EjecutarFomularioComprobante();
        }

        private void reservaMenu_Click(object sender, System.EventArgs e)
        {
            var fRes = new _10016_ReservarMesa(_mesaId);
            fRes.ShowDialog();
            if (fRes.RealizoAlgunaOperacion)
            {
                EstadoMesa = EstadoMesa.Reservado;
            }

        }

        private void fueraServicioMenu_Click(object sender, System.EventArgs e)
        {
            EstadoMesa = EstadoMesa.FueraServicio;
        }

        private void sacarFueraServicioMenu_Click(object sender, System.EventArgs e)
        {
            EstadoMesa = EstadoMesa.Cerrada;
        }

        private void cerrarMenu_Click(object sender, System.EventArgs e)
        {
            if (_estadoMesa == EstadoMesa.Abierta)
            {
                var comprobante = _comprobanteServicio.ObtenerComprobanteMesa(_mesaId);

                if (comprobante.Total > 0)
                {
                    if (comprobante.MozoId != null)
                    {
                        var fMen = new FormaPagoMesa(_mesaId);
                        fMen.ShowDialog();
                        if (fMen.Realizo)
                        {
                            EstadoMesa = EstadoMesa.Cerrada;
                            PrecioConsumido = 0m;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puede cerrar la mesa si no añade un mozo a la mesa", "Atencion");
                    }

                }
                else
                {
                    if (MessageBox.Show("¿Desea cancelar la venta?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;
                    _comprobanteServicio.CancelarVenta(_mesaId);
                    EstadoMesa = EstadoMesa.Cerrada;
                    PrecioConsumido = 0m;
                }

            }

        }
        
        private void cancelarReservaMenu_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de cancelar la reserva?", "Atencion", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No) return;
            _comprobanteServicio.CancelarReserva(_mesaId);
            EstadoMesa = EstadoMesa.Cerrada;
        }

        private void cancelarVentaMenu_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de cancelar la venta?", "Atencion!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No) return;
            _comprobanteServicio.CancelarVenta(_mesaId);
            EstadoMesa = EstadoMesa.Cerrada;
            PrecioConsumido = 0m;
        }

        private void cancelarVentaMenu_Click_1(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de cancelar la venta?", "Atencion!", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.No) return;
            _comprobanteServicio.CancelarVenta(_mesaId);
            EstadoMesa = EstadoMesa.Cerrada;
            PrecioConsumido = 0m;
        }
    }
}