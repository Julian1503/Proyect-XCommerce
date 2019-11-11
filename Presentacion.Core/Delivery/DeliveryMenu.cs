using Presentacion.Core.Delivery.Control;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Notificacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Delivery;

namespace Presentacion.Core.Delivery
{
    public partial class DeliveryMenu : FormularioBase.FormularioBase
    {
        private readonly IDeliveryServicio _deliveryServicio;
        public DeliveryMenu()
        {
            InitializeComponent();
            _deliveryServicio = new DeliveryServicio();
            ControlesPendientes();
        }

        private void ControlesPendientes()
        {
            foreach (System.Windows.Forms.Control i in flpPendientes.Controls)
            {
                if (i == null)
                    break;
                flpPendientes.Controls.Remove(i);
            }
            foreach (var pedidos in _deliveryServicio.ObtenerPorDia().Where(x=>x.Estado == XCommerce.AccesoDatos.EstadoPedido.Pendiente))
            {
                var controlPedido = new ControlPedido
                {
                    Margin = new Padding(15, 15, 10, 10),
                    Name = $"ctrlPedido{pedidos.Id}",
                    PedidoNumero = pedidos.Id,
                    Cliente = pedidos.ClienteNombreCompleto,
                    Direccion = pedidos.Direccion,
                    Cadete = pedidos.CadeteNombreCompleto,
                    Total = pedidos.Total,
                    EnviarClick = Control_EnviarClick,
                    CancelarClick=Control_CancelarClick,
                    Estado = XCommerce.AccesoDatos.EstadoPedido.Pendiente,
                    EditarClick=Control_EditarClick
                };
                
                void Control_EnviarClick(object sender, EventArgs e)
                {
                    _deliveryServicio.Enviar(pedidos.Id);
                    NotificacionCorrecta.MensajeSatisfactorio("Envio exitoso");
                    ControlesPendientes();
                }
                void Control_CancelarClick(object sender, EventArgs e)
                {
                    _deliveryServicio.Cancelar(pedidos.Id);
                    NotificacionCorrecta.MensajeSatisfactorio("Cancelacion exitosa");
                    ControlesPendientes();
                }
                void Control_EditarClick(   object sender, EventArgs e)
                {
                    var fComprobante = new ComprobanteDelivery(pedidos.Id);
                    fComprobante.ShowDialog();
                }
                flpPendientes.Controls.Add(controlPedido);
            }
            

        }

         

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            var fComprobanteDelivery = new ComprobanteDelivery();
            try
            {
                fComprobanteDelivery.ShowDialog();
                if (fComprobanteDelivery.RealizoOperacion)
                    ControlesPendientes();
            }catch(IndexOutOfRangeException a)
            {
                Console.WriteLine(a.Data);
                Console.WriteLine(a.HResult);
                Console.WriteLine(a.TargetSite);
                Console.WriteLine(a.Message);
                Console.WriteLine(a.InnerException);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var fDelivery = new DeliveryPedidosTodos();
            fDelivery.ShowDialog();
        }

        private void pagePedidos_Selecting(object sender, TabControlCancelEventArgs e)
        {
            foreach (System.Windows.Forms.Control i in flpPendientes.Controls)
            {
                flpPendientes.Controls.Remove(i);
            }
            foreach (System.Windows.Forms.Control i in flpEnviados.Controls)
            {
                flpEnviados.Controls.Remove(i);
            }
            if (e.TabPage == tabEnviados)
            {
                ControlesEnviado();
            }
            else
            {
                ControlesPendientes();
            }
        }

        private void ControlesEnviado()
        {
            foreach (System.Windows.Forms.Control i in flpEnviados.Controls)
            {
                flpEnviados.Controls.Remove(i);
            }
            foreach (var pedidos in _deliveryServicio.ObtenerPorDia().Where(x => x.Estado ==
            XCommerce.AccesoDatos.EstadoPedido.Enviado))
            {
                var controlPedido = new ControlPedido
                {
                    Margin = new Padding(15, 15, 10, 10),
                    Name = $"ctrlPedido{pedidos.Id}",
                    PedidoNumero = pedidos.Id,
                    Cliente = pedidos.ClienteNombreCompleto,
                    Direccion = pedidos.Direccion,
                    Cadete = pedidos.CadeteNombreCompleto,
                    Total = pedidos.Total,
                    Estado = XCommerce.AccesoDatos.EstadoPedido.Enviado,
                    CancelarClick = Control_CancelarClick,
                    EntregarClick = Control_EntregarClick
                };
                void Control_CancelarClick(object obj, EventArgs a)
                {
                    _deliveryServicio.Cancelar(pedidos.Id);
                    NotificacionCorrecta.MensajeSatisfactorio("Cancelacion exitosa");
                    ControlesEnviado();
                }
                void Control_EntregarClick(object sender, EventArgs e)
                {
                    var fp = new FormaPagoDelivery(pedidos.Id);
                    fp.ShowDialog();
                    ControlesEnviado();
                }
                flpEnviados.Controls.Add(controlPedido);
            }
        }

        
    }
}
