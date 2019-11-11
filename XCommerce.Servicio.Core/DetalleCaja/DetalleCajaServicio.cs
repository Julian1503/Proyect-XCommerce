namespace XCommerce.Servicio.Core.DetalleCaja
{
    using AccesoDatos;

    public class DetalleCajaServicio : IDetalleCajaServicio
    {
        public void Generar(decimal monto, TipoPago pago)
        {
            using (var context = new ModeloXCommerceContainer())
            {
            //TODO
                var nuevoDetalle = new AccesoDatos.DetalleCaja
                {
                    CajaId = Entidad.Entidad.CajaId,
                    Monto = monto,
                    TipoPago = pago
                };
                context.DetalleCajas.Add(nuevoDetalle);
                context.SaveChanges();
            }
        }
    }
}
