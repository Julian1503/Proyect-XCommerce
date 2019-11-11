namespace XCommerce.Servicio.Core.Entidad
{
    public static class Entidad
    {
        public static long UsuarioId { get; set; }
        public static string NombreUsuario { get; set; }
        public static string ApyNom { get; set; }
        public static long CajaId { get; set; }
        public static bool CajaAbierta { get; set; }
        public static byte[] ImagenLogo { get; set; }
        public static long? ListaPrecioDeliveryId { get; set; }
        public static long? ListaPrecioKioscoId { get; set; }
        public static string ListaPrecioDeliveryDescripcion { get; set; }
        public static string ListaPrecioKioscoDescripcion { get; set; }
        public static long? CategoriaCadeteId { get; set; }
        public static string CategoriaCadeteDescripcion { get; set; }
        public static string CategoriaMozoDescripcion { get; set; }
        public static long? CategoriaMozoId { get; set; }
        public static int PedidosHoy { get; set; }
        public static int ArticulosReponer { get; set; }
        public static int ReservasHoy { get; set; }
        public static int VentasHoy { get; set; }
    }
}
