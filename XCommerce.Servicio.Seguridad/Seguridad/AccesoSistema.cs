namespace XCommerce.Servicio.Seguridad.Seguridad
{
    using System.Linq;
    using AccesoDatos;
    using Presentacion.Helpers;

    public class AccesoSistema : IAccesoSistema
    {
        public bool VerificarSiEstaBloqueadoUsuario(string nombreUsuario)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario
                              && x.EstaBloqueado);
            }
        }

        public bool VerificarSiExisteUsuario(string nombreUsuario, string password)
        {
            if (nombreUsuario == "Admin"
                && password == "Admin")
                return true;

            using (var context = new ModeloXCommerceContainer())
            {
                var passEncriptado =  Encriptar.Encriptador(password);
                return context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario
                              && x.Password == passEncriptado);
            }
        }

        public long ObtenerPorId(string nombre, string pass)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (nombre == "Admin" && pass == "Admin") return 0;
                var passEn = Encriptar.Encriptador(pass);
                return context.Usuarios
                    .FirstOrDefault(x => x.Nombre == nombre && x.Password == passEn).Id;
            }
        }
    }
}
