using Presentacion.Core.Delivery;
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
using XCommerce.Servicio.Core.CompranteMesa;
using XCommerce.Servicio.Core.Empresa;
using XCommerce.Servicio.Core.Kiosco;

namespace Presentacion.Core.Kiosco
{
    public partial class ComprobanteKiosco : Comprobante
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IKioscoServicio _comprobanteServicio;

        public ComprobanteKiosco()
        {
            InitializeComponent();
        }

        public ComprobanteKiosco(IEmpresaServicio empresaServicio,
                                IClienteServicio clienteServicio,
                                IKioscoServicio comprobanteServicio)
        {
            _empresaServicio = empresaServicio;
            _clienteServicio = clienteServicio;
            _comprobanteServicio = comprobanteServicio;
        }
        public ComprobanteKiosco(long comprobanteId) : this(new EmpresaServicio(), new ClienteServicio(), new KioscoServicio())
        {
            comprobante = _comprobanteServicio.ObtenerComprobante(comprobanteId);
            cliente = _clienteServicio.ObtenerConsumidorFinal();
            empresa = _empresaServicio.Obtener();
        }
    }
}
