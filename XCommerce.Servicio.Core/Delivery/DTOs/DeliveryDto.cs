using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Delivery.DTOs
{
    public class DeliveryDto : ComprobanteBase
    {
        public long? CadeteId { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public long DireccionId { get; set; }
        public string Direccion => $"{Calle} {Numero}";
        public EstadoPedido Estado { get; set; }
        public string Calle { get;  set; }
        public int Numero { get;  set; }

        public string CadeteNombreCompleto => $"{CadeteApellido} {CadeteNombre}";
        public string CadeteNombre { get; set; }
        public string CadeteApellido { get; set; }
        public int Legajo { get; set; }
    }
}
