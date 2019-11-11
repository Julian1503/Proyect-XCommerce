using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.FormaPago.DTOs
{
    public class FormaPagoDto : BaseDto
    {
        public long ComprobanteId { get; set; }
        public TipoFormaPago TipoFormaPago { get; set; }
        public decimal Monto { get; set; }
    }
}
