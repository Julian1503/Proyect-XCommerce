using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.FormaPago.DTOs
{
    public class FormaPagoChequeDto :FormaPagoDto
    {
        public long BancoId { get; set; }
        public string Numero { get; set; }
        public string EnteEmisor { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public int Dias { get; set; }
        public EstadoCheque EstadoCheque{ get; set; }
    }
}
