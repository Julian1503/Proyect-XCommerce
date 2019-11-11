using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Notificacion
{
    public partial class NotificacionIncorrecta : Form
    {
        public NotificacionIncorrecta()
        {
            InitializeComponent();
        }
        public NotificacionIncorrecta(string mensaje,string descripcion ) :this()
        {
            lblMensaje.Text = mensaje;
            if(!string.IsNullOrWhiteSpace(lblDescripcion.Text))
            {
                lblDescripcion.Text = descripcion;
            }
        }

        public static void MensajeCuidado(string mensaje,string descripcion)
        {
            NotificacionIncorrecta fNoti = new NotificacionIncorrecta(mensaje, descripcion);
            fNoti.ShowDialog();
        }

        private void NotificacionIncorrecta_Load(object sender, EventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
