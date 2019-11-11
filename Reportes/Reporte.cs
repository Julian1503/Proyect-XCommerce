using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.DetalleComprobante;

namespace Reportes
{
    public partial class Reporte : Form
    {
        private readonly IDeliveryServicio _deliveryServicio;
        private readonly IDetalleComprobanteServicio _detalleComprobanteServicio;

        public Reporte(IDeliveryServicio deliveryServicio, IDetalleComprobanteServicio detalleComprobanteServicio)
        {
            _deliveryServicio = deliveryServicio;
            _detalleComprobanteServicio = detalleComprobanteServicio;
            
        }
        public Reporte() : this(new DeliveryServicio(),new DetalleComprobanteServicio())
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            DeliveryReport cp = new DeliveryReport();
            var resultado = _detalleComprobanteServicio.Obtener(2);
            cp.SetDataSource(resultado);
            crystalReportViewer2.ReportSource = cp;
        }
    }
}
