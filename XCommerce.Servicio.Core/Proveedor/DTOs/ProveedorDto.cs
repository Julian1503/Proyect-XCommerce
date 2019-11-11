namespace XCommerce.Servicio.Core.Proveedor.DTOs
{
    using Base;

    public class ProveedorDto : BaseDto
    {
        public string RazonSocial { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Contacto { get; set; }

        public long CondicionIvaId { get; set; }
    }
}
