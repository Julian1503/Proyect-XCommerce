using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Entidad;

namespace Presentacion.Core.Caja
{
    public partial class _00011_Caja : Form
    {
        public _00011_Caja()
        {
            InitializeComponent();
            Actualizar();
        }

        private void Actualizar()
        {
            if (Entidad.CajaAbierta)
            {
                btnCerrarCaja.Enabled = true;
                btnAbrirCaja.Enabled = false;
            }
            else
            {
                btnCerrarCaja.Enabled = false;
                btnAbrirCaja.Enabled = true;
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
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
    }
}
