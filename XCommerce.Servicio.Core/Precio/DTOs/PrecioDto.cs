namespace XCommerce.Servicio.Core.Precio.DTOs
{
    using System;

    public class PrecioDto
    {
        public long Id { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public string DescripcionArticulo { get; set; }

        public string NombreLista { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }
        
        public long ListaPrecioId { get; set; }


        public long ArticuloId { get; set; }


        public bool ActivarHoraVenta { get; set; }

        public DateTime HoraVenta { get; set; }
    }
}
