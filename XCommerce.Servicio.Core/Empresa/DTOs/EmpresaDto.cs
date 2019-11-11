namespace XCommerce.Servicio.Core.Empresa.DTOs
{
    public class EmpresaDto 
    {
        public long Id { get; set; }

        public long CondicionIvaId { get; set; }

        public string RazonSocial { get; set; }

        public string NombreFantasia { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public string Sucursal { get; set; }

        public byte[] Logo { get; set; }

        public string Calle { get; set; }

        public string DireccionCompleta => $"{Calle} {Numero}";

        public int Numero { get; set; }

        public string Piso { get; set; }

        public string Dpto { get; set; }

        public string Casa { get; set; }

        public string Lote { get; set; }

        public string Mza { get; set; }

        public string Barrio { get; set; }

        public long LocalidadId { get; set; }

        public long ProvinciaId { get; set; }

        public string CondicionIvaIdDescripcion { get; set; }
    }
}
