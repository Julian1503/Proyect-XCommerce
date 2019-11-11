namespace XCommerce.Servicio.Core.PlanTarjeta.DTOs
{
    using Base;

    public class PlanTarjetaDto : BaseDto
    {
        public string Descripcion { get; set; }

        public decimal Alicuota { get; set; }

        public string TarjetaNombre { get; set; }

        public long TarjetaId { get; set; }
    }
}
