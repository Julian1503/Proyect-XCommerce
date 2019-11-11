using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.ComprobanteCompra.DTOs
{
    public class ComprobanteCompraDto : ComprobanteBase
    {
        public long ProveedorId { get; set; }
        public string ProveedorRazonSocial { get; set; }
    }
}
