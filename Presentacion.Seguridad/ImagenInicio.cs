using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Seguridad
{
    public partial class ImagenInicio : Form
    {
        public ImagenInicio()
        {
            InitializeComponent();
        }

        private void ImagenInicio_Load(object sender, EventArgs e)
        {
            efecto.ShowAsyc(this);
           timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
