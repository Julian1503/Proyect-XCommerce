using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.FormaPago.DTOs
{
    public class FormaPagoTarjetaDto : FormaPagoDto
    {
        public long PlanTarjetaId { get; set; }
        public string Cupon { get; set; }
        public string Numero { get; set; }
        public string NumeroTarjeta { get; set; }
    }
}
