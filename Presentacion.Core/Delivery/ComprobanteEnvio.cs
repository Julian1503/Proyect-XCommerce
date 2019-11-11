using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.Empresa;

namespace Presentacion.Core.Delivery
{
    public partial class ComprobanteEnvio : Comprobante
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IDeliveryServicio _deliveryServicio;
        public ComprobanteEnvio()
        {
            InitializeComponent();
        }
        public ComprobanteEnvio(IEmpresaServicio empresaServicio,
                               IClienteServicio clienteServicio,
                               IDeliveryServicio deliveryServicio)
        {
            _empresaServicio = empresaServicio;
            _clienteServicio = clienteServicio;
            _deliveryServicio = deliveryServicio;
        }
        public ComprobanteEnvio(long comprobanteId) : this(new EmpresaServicio(), new ClienteServicio(), new DeliveryServicio())
        {
            comprobante = _deliveryServicio.ObtenerPorId(comprobanteId);
            cliente = _clienteServicio.ObtenerPorId(comprobante.ClienteId);
            empresa = _empresaServicio.Obtener();
        }

    }
}
