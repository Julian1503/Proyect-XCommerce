namespace XCommerce.Servicio.Core.Caja.DTOs
{
    using AccesoDatos;

    public class DetalleCajaDto
    {

        public long Id { get; set; }
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }
        public string TipoPagoStr => TipoPago == TipoPago.CtaCte ? "Cuenta Corriente" : TipoPago == TipoPago.Efectivo ? "Efectivo" : TipoPago == TipoPago.Cheque ? "Cheque" : "Tarjeta";

    }
}
