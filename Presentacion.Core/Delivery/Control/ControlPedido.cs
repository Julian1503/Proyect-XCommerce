using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using System.Windows;
using System.Drawing;
using System.Globalization;

namespace Presentacion.Core.Delivery.Control
{
    public partial class ControlPedido : UserControl
    {
        public ControlPedido()
        {
            InitializeComponent();
        }

        public EventHandler EnviarClick
        {
            set
            {
                enviarMenu.Click += value;
            }
        }
        public EventHandler DoubleClickControl
        {
            set
            {
                pbNote.DoubleClick += value;
            }
        }
        public EventHandler CancelarClick
        {
            set
            {
                cancelarMenu.Click += value;
            }
        }
        public EventHandler EntregarClick
        {
            set
            {
                entregarMenu.Click += value;
            }
        }
        public EventHandler EditarClick
        {
            set
            {
                editarMenu.Click += value;
            }
        }
        public long PedidoNumero
        {
            set {

                    lblPedido.Text = $"Pedido N°{value}";
                }
        }

        public EstadoPedido Estado
        {
            set
            {
                switch (value)
                {
                    case EstadoPedido.Pendiente:
                        cancelarMenu.Visible = true;
                        enviarMenu.Visible = true;
                        editarMenu.Visible = true;
                        entregarMenu.Visible = false;
                        break;
                    case EstadoPedido.Enviado:
                        editarMenu.Visible = false;
                        cancelarMenu.Visible = true;
                        entregarMenu.Visible = true;
                        enviarMenu.Visible = false;
                        break;
                }
            }
        }

        public string Cliente
        {
            set
            {
                if (value.Length > 19)
                {
                    lblClienteDescrip.Text = $"{value.Remove(19, value.Length - 19)}..";
                }
                else
                {
                    lblClienteDescrip.Text = $"{value}";
                }
            }
        }

        public string Direccion
        {
            set
            {

                if (value.Length>19)
                {
                    lblDirecDescrip.Text = $"{value.Remove(19,value.Length-19)}..";
                }
                else
                {
                    lblDirecDescrip.Text = $"{value}";
                }
            }
        }

        public string Cadete
        {
            set
            {
                if (value.Length > 19)
                {
                    lblCadeteDescripcion.Text = $"{value.Remove(19, value.Length- 19)}..";
                }
                else
                {
                    lblCadeteDescripcion.Text = $"{value}";
                }
            }
        }

        public decimal Total
        {
            set
            {
                lblTotalDescrip.Text = $"{value.ToString("C")}";
            }
        }

        private void ControlPedido_Paint(object sender, PaintEventArgs e)
        {
            // Área cliente del formulario.
            //
            Rectangle rectangulo = this.ClientRectangle;
            // Punto intermedio del área cliente.
            //
            var centrado = rectangulo.Width / 2;
            // Establecemos la nueva posición del control Label.
            //
            lblPedido.Location = new Point(centrado - lblPedido.Width / 2, lblPedido.Location.Y);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblClienteDescrip_TextChanged(object sender, EventArgs e)
        {
            //lblClienteDescrip.Location = new Point(lblCliente.Location.X+lblCliente.Width);
        }

        private void pbNote_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                menu.Show(Cursor.Position);
            }
        }
    }
}
