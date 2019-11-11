using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Operacion
{
    public class OperacionDto : BaseDto
    {

        public long CuentaCorrienteId { get; set; }

        public TipoOperacion TipoOperacion { get; set; }

        public System.DateTime Fecha { get; set; }

        public string TipoOperacionStr => TipoOperacion == TipoOperacion.Cobranza ? "Pago" : "Compra";

        public decimal Monto { get; set; }
        
        public decimal Saldo { get; set; }
        public long ComprobanteId { get;set; }
    }
}
