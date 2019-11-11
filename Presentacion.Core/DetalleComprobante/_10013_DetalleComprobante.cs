using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.VentasSalon
{
    using System;
    using XCommerce.Servicio.Core.DetalleComprobante;

    public partial class _10013_DetalleComprobante : FormularioBase.FormularioBase
    {
        private long _comproId;
        private readonly IDetalleComprobanteServicio _comprobanteServicio;
        public _10013_DetalleComprobante()
        {
            InitializeComponent();
            menuAccesoRapido.BackColor = Constantes.Color.ColorMenu;
            _comprobanteServicio = new DetalleComprobanteServicio();
        }

        public _10013_DetalleComprobante(long comproId) : this()
        {
            _comproId = comproId;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarDatos()
        {
            dgvGrilla.DataSource = _comprobanteServicio.Obtener(_comproId);
        }

        private void _10013_DetalleComprobante_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
            Formatear();
        }

        private void Formatear()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        
    }
}
