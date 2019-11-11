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
    public partial class NotificacionCorrecta : Form
    {
        public NotificacionCorrecta()
        {
            InitializeComponent();
        }
        public NotificacionCorrecta(string mensaje):this()
        {
            lblMensaje.Text = mensaje;
        }
        private void NotificacionCorrecta_Load(object sender, EventArgs e)
        {
        }

        public static void MensajeSatisfactorio(string mensaje)
        {
            NotificacionCorrecta fNoti = new NotificacionCorrecta(mensaje);
            fNoti.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
