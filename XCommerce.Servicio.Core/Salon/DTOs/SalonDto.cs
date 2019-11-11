namespace XCommerce.Servicio.Core.Salon.DTOs
{
    using Base;

    public class SalonDto : BaseDto
    {
        public string Descripcion { get; set; }

        public long ListaPreciosId { get; set; }
    }
}
