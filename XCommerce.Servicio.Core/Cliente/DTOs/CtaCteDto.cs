namespace XCommerce.Servicio.Core.CtaCte
{
    public class CtaCteDto
    {
        public long Id { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public bool EstaEliminada { get; set; }
        public string NumeroCuienta { get; set; }
        public long ClienteId { get; set; }

    }
}
