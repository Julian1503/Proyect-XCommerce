using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.CompranteMesa;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;

namespace XCommerce.Servicio.Core.Base
{
   public class ComprobanteBase : BaseDto
    {
        public ComprobanteBase()
        {
            if (Items == null)
                Items = new List<DetalleComprobanteDto>();
        }
        public TipoComprobante TipoComprobante { get; set; }
        public decimal MontoEfectivo { get; set; }
        public string ClienteNombreCompleto => $"{ClienteApellido} {ClienteNombre}";
        public string ClienteApellido { get; set; }
        public string ClienteNombre { get; set; }
        public decimal MontoTarjeta { get; set; }
        public decimal MontoCheque { get; set; }
        public decimal MontoCtaCte { get; set; }
        public int NumeroComprobante { get;  set; }
        public long ClienteId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleComprobanteDto> Items { get; set; }
        public decimal SubTotal => Items.Sum(x => x.SubTotal);
        public decimal Descuento { get; set; }
        public decimal Total => Math.Round(SubTotal - CalcularDescuento.Calcular(Descuento, SubTotal),2);
    }
}
