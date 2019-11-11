namespace XCommerce.Servicio.Core.ListaPrecio.DTOs
{
    using Base;

    public class ListaPreciosDto : BaseDto
    {
        public string Descripcion { get; set; }

        public decimal Rentabilidad { get; set; }
    }
}
