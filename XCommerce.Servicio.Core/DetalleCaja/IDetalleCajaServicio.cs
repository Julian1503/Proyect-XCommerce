namespace XCommerce.Servicio.Core.DetalleCaja
{
    using AccesoDatos;

    public interface IDetalleCajaServicio
   {
       void Generar(decimal monto, TipoPago pago);
   }
}
