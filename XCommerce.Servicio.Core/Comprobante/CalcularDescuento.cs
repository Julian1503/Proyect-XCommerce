namespace XCommerce.Servicio.Core.CompranteMesa
{
    public static class CalcularDescuento
    {
        public static decimal Calcular(decimal porc, decimal valor)
        {
            return (valor *(porc / 100m));
        }
    }
}
