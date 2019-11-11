namespace XCommerce.Servicio.Seguridad.Seguridad
{
    public interface IAccesoSistema
    {
        bool VerificarSiExisteUsuario(string nombreUsuario, string password);

        bool VerificarSiEstaBloqueadoUsuario(string nombreUsuario);

        long ObtenerPorId(string nom, string pass);
    }
}
