namespace XCommerce.Servicio.Core.BajaArticulo.DTOs
{
    using Base;

    public class BajaArticuloDto : BaseDto
    {

        public System.DateTime Fecha { get; set; }

        public decimal Cantidad { get; set; }

        public string Observacion { get; set; }

        public string Motivo { get; set; }

        public string Articulo { get; set; }

        public long MotivoBajaId { get; set; }

        public long ArticuloId { get; set; }

    }
}
