using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Core.Reserva;
using XCommerce.Servicio.Core.Entidad;
using Presentacion.Constantes;
using Presentacion.Core.Caja;
using Bunifu.Framework.UI;
using XCommerce.Servicio.Core.Articulo;
using Presentacion.Core.Delivery;
using Presentacion.Core.VentaKiosco;
using Presentacion.Core.Venta;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.Reserva;
using XCommerce.Servicio.Core.Movimiento;

namespace XCommerce.Controles
{
    public partial class ControlPresentacion : UserControl
    {

        private long nArticulos;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IReservaServicio _reservaServicio;
        private readonly IDeliveryServicio _deliveryServicio;
        public ControlPresentacion() : this(new ArticuloServicio(), new MovimientoServicio(), new ReservaServicio(), new DeliveryServicio())
        {
            InitializeComponent();
           
           
            Actualizar();
        }
        public ControlPresentacion(IArticuloServicio articuloServicio,
            IMovimientoServicio movimientoServicio,
           IReservaServicio reservaServicio,
            IDeliveryServicio deliveryServicio)
        {

            _articuloServicio = articuloServicio;
            _deliveryServicio = deliveryServicio;
            _movimientoServicio = movimientoServicio;
            _reservaServicio = reservaServicio;
            nArticulos = _articuloServicio.ReporteReponerStock().Count();
        }

        private void ComponenteStock_Click(object sender, EventArgs e)
        {
           
        }

        private void ComponenteReserva_Click(object sender, EventArgs e)
        {
            var fReservas = new _00029_Reserva();
            fReservas.ShowDialog();
        }

        private void Actualizar()
        {
            if (Entidad.CajaAbierta)
            {
                pnlCerrar.Visible = true;
                pnlAbrir.Visible = false;
            }
            else
            {
                pnlCerrar.Visible = false;
                pnlAbrir.Visible = true;
            }
        }
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {

            if (Entidad.CajaAbierta)
            {
                if (Entidad.UsuarioId != 0)
                {
                    var fCaja = new _10008_CerrarCaja();
                    fCaja.ShowDialog();
                    Actualizar();

                }
                else
                {
                    MessageBox.Show("Debe estar logueado con una cuenta de usuario!");

                }
            }
            else
            {
                MessageBox.Show("Abra la caja!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!Entidad.CajaAbierta)
            {
                if (Entidad.UsuarioId != 0)
                {
                    var fCaja = new _00044_AbrirCaja();
                    fCaja.ShowDialog();
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("Debe estar logueado con una cuenta de usuario!");

                }
            }
            else
            {
                MessageBox.Show("La caja ya esta abierta", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pnlCerrar_Enter(object sender, EventArgs e)
        {
           ((BunifuCards)sender).color = System.Drawing.Color.Aqua;
        }

        private void pnlCerrar_Leave(object sender, EventArgs e)
        {
            ((BunifuCards)sender).color = System.Drawing.Color.Transparent;
        }

        private void bunifuImageButton2_MouseHover(object sender, EventArgs e)
        {
            ((BunifuCards)((Control)sender).Parent).color = System.Drawing.Color.Aqua;
        }

        private void btnSalon_Click(object sender, EventArgs e)
        {
            if (Entidad.ListaPrecioDeliveryId == null)
            {
                MessageBox.Show("No puede ejecutar delivery sin tener configurada la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!Entidad.CajaAbierta)
            {
                MessageBox.Show("Debe tener caja abierta para facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Entidad.UsuarioId == 0)

            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Debe loguearse", "Debe estar logueado con una cuenta de usuario!");
                return;
            }
            var fVentas = new _00038_VentaSalon();
            fVentas.ShowDialog();
            lblProductosReponer.Refresh();
                    lblVentasHoy.Refresh();
        }

        private void pnlKiosco_Click(object sender, EventArgs e)
        {
            if (Entidad.ListaPrecioKioscoId == null)
            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Debe configurar las listas","No puede ejecutar kiosco sin tener configurada la lista");
                return;
            }
            AbrirKiosco();
        }

        private void AbrirKiosco()
        {
            if (Entidad.CajaAbierta)
            {
                if (Entidad.UsuarioId != 0)

                {
                    var fkios = new _0003_Ventakiosco();
                    fkios.ShowDialog();
            lblProductosReponer.Refresh();
                    lblVentasHoy.Refresh();
                }
                else
                {
                    Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Debe loguearse", "Debe estar logueado con una cuenta de usuario!");

                }
            }
            else
            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Necesita abrir la caja","Debe tener caja abierta para facturar");
            }
        }

        private void lblDelivery_Click(object sender, EventArgs e)
        {

            if (Entidad.ListaPrecioDeliveryId == null)
            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Debe configurar las listas", "No puede ejecutar delivery sin tener configurada la lista");
                return;
            }
            if (!Entidad.CajaAbierta)
            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Necesita abrir la caja", "Debe tener caja abierta para facturar");
                return;
            }
            if (Entidad.UsuarioId == 0)

            {
                Presentacion.Core.Notificacion.NotificacionIncorrecta.MensajeCuidado("Debe loguearse", "Debe estar logueado con una cuenta de usuario!");
                return;
            }
            var prov = new DeliveryMenu();
            prov.ShowDialog();
            lblEnviosHoy.Refresh();
            lblProductosReponer.Refresh();
            lblVentasHoy.Refresh();
        }

        private void ControlPresentacion_Enter(object sender, EventArgs e)
        {

        }

        private void lblVentasHoy_Paint(object sender, PaintEventArgs e)
        {
            Entidad.VentasHoy = _movimientoServicio.ObtenerVentasHoy();
            lblVentasHoy.Text = $"{Entidad.VentasHoy} ventas";
        }

        private void lblNumeroReservas_Paint(object sender, PaintEventArgs e)
        {
            Entidad.ReservasHoy = _reservaServicio.Obtener(string.Empty).Where(x => x.Fecha.Date == DateTime.Now.Date).Count();
            lblNumeroReservas.Text = $"{Entidad.ReservasHoy} reservas";
        }

        private void lblProductosReponer_Paint(object sender, PaintEventArgs e)
        {
            Entidad.ArticulosReponer = _articuloServicio.ReporteReponerStock().Count();
            lblProductosReponer.Text = $"{Entidad.ArticulosReponer} productos";
        }

        private void lblEnviosHoy_Paint(object sender, PaintEventArgs e)
        {
            Entidad.PedidosHoy = _deliveryServicio.ObtenerTodos(string.Empty).Where(x => x.Fecha.Date == DateTime.Now.Date).Count();
            lblEnviosHoy.Text = $"{Entidad.PedidosHoy} envios";
        }
    }
}
