using System;

namespace XCommerce.Servicio.Core.CompranteMesa.DTOs
{
    public class DetalleComprobanteDto
    {
        public long ArticuloId { get; set; }
        public string CodigoProducto { get; set; }
        public long ComprobanteId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal => Math.Round(Cantidad * PrecioUnitario,2);
    }
}
