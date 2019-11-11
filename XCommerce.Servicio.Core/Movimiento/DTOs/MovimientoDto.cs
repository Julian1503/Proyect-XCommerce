namespace XCommerce.Servicio.Core.Movimiento.DTOs
{
    using System;
    using AccesoDatos;

    public class MovimientoDto
    {
        public long Id { get; set; }
        public long CajaId { get; set; }
        public string Descripcion { get; set;}
        public long ComprobanteId { get; set; }
        public TipoMovimiento TipoMovimento { get; set; }
        public string TipoMovimientoStr => TipoMovimento == TipoMovimiento.Egreso ? "Egreso" : "Ingreso";
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public long UsuarioId { get; set; }
    }
}
