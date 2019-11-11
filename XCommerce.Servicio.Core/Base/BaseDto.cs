namespace XCommerce.Servicio.Core.Base
{
    public class BaseDto
    {
        public long Id { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}
