namespace XCommerce.Servicio.Core.Comprobante
{
    using System.Linq;
    using AccesoDatos;

    public static class NumeroDeComprobante
    {

        public static int UltimoNumeroComprobante()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Comprobantes.Any())
                {
                    return context.Comprobantes.Max(x => x.Numero) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
