namespace XCommerce.Servicio.Core.CuentaCorriente.DTOs
{
    using Base;

    public class CuentaCorrienteDto : BaseDto
    {
        public int NumeroCuenta { get; set; }
        public string ApyNomCliente => $"{ApellidoCliente} {NombreCliente}";

        public string DniCliente { get; set; }

        public decimal Limite { get; set; }

        public decimal Saldo { get; set; }


        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public long ClienteId { get; set; }
    }
}
