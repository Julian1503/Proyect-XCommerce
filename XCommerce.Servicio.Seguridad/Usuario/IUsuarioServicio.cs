namespace XCommerce.Servicio.Seguridad.Usuario
{
    using System.Collections.Generic;
    using DTOs;

    public interface IUsuarioServicio
    {
        /// <summary>
        /// Metodo para Bloquear o Desbloquear el Usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre del USuario</param>
        /// <param name="estado">Estado => True: bloquear; False: desbloquear</param>
        void CambiarEstado(string nombreUsuario, bool estado);

        IEnumerable<UsuarioDto> Obtener(string cadenaBuscar);

        void Crear(long EntidadId, string apellido, string nombre);

        UsuarioDto ObtenerPorId(long? entidadId);
        bool VerificarSiUsuarioExiste(string cadena);

    }
}
