namespace XCommerce.Servicio.Seguridad.Usuario.DTOs
{
    public class UsuarioDto
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPersona { get; set; }

        public string NombrePersona { get; set; }

        public string ApyNom => $"{ApellidoPersona} {NombrePersona}";

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        public string EstaBloqueadoStr => EstaBloqueado ? "Si" : "No";

        public long PersonaId { get; set; }
    }
}
