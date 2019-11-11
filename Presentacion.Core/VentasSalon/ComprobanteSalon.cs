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
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.Empresa;

namespace Presentacion.Core.VentasSalon
{
    public partial class ComprobanteSalon : Comprobante
    {

        private readonly IEmpresaServicio _empresaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IComprobanteMesaServicio _comprobanteMesaServicio;

        public ComprobanteSalon() 
        {
            InitializeComponent();
        }

        public ComprobanteSalon(IEmpresaServicio empresaServicio,
                                IClienteServicio clienteServicio,
                                IComprobanteMesaServicio comprobanteMesaServicio)
        {
            _empresaServicio = empresaServicio;
            _clienteServicio = clienteServicio;
            _comprobanteMesaServicio = comprobanteMesaServicio;
        }
        public ComprobanteSalon(long comprobanteId) : this(new EmpresaServicio(),new ClienteServicio(), new ComprobanteMesaServicio())
        {
          comprobante =  _comprobanteMesaServicio.ObtenerPorId(comprobanteId);
          cliente =  _clienteServicio.ObtenerPorId(comprobante.ClienteId);
            empresa =_empresaServicio.Obtener();
        }
            
    }
}
