namespace XCommerce.Servicio.Seguridad.Usuario
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;
    using Presentacion.Helpers;

    public class UsuarioServicio : IUsuarioServicio
    {
        public void CambiarEstado(string nombreUsuario, bool estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var usuario = context.Usuarios
                    .FirstOrDefault(usu => usu.Nombre == nombreUsuario);

                if(usuario == null)
                    throw new Exception($"No se encontro el Usuario: {nombreUsuario}.");

                usuario.EstaBloqueado = estado;

                context.SaveChanges();
            }
        }
        public UsuarioDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios
                    .AsNoTracking()
                    .Include(x=>x.Persona)
                    .Select(x => new UsuarioDto
                    {
                       Id = x.Id,
                        Nombre = x.Nombre,
                        EstaBloqueado = x.EstaBloqueado,
                        PersonaId = x.PersonaId,
                        NombrePersona = x.Persona.Nombre,
                        ApellidoPersona = x.Persona.Apellido,
                        Password = x.Password
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
        public void Crear(long EntidadId, string apellido, string nombre)
        {
            var cantidadLetra = 1;
            var contador = 0;
            var nombreUsuario = CrearNombre(apellido, nombre, cantidadLetra);
            using (var context = new ModeloXCommerceContainer())
            {
                while(context.Usuarios.Any(x => x.Nombre == nombreUsuario))
                {
                    if (cantidadLetra < nombre.Length)
                    {
                        cantidadLetra++;
                        nombreUsuario = CrearNombre(apellido, nombre, cantidadLetra);
                    }
                    else
                    {
                       nombreUsuario= CrearNombreConNumeros(apellido, nombre, contador);
                        contador++;
                    }
                }

                var usuario = new AccesoDatos.Usuario
                {
                    Nombre = nombreUsuario,
                    Password = Encriptar.Encriptador("1234"),
                    PersonaId = EntidadId,
                    EstaBloqueado = false
                };
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }

            
        }

        private string CrearNombreConNumeros(string apellido, string nombre, int contador)
        {
            var primer = nombre.Trim().ToLower();
            var segunda = apellido.Trim().ToLower();
            return $"{primer}{segunda}{contador}";
        }

        private string CrearNombre(string apellido, string nombre, int cantidad )
        {
                var primer = nombre.Trim().Substring(0, cantidad).ToLower();
                var segunda = apellido.Trim().ToLower();
                return $"{primer}{segunda}";
        }

        public IEnumerable<UsuarioDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.AsNoTracking().Include(x => x.Usuarios).Where(x => x.Dni !="99999999" &&( x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni==cadenaBuscar)).Select(x=> new UsuarioDto
                {
                    PersonaId = x.Id,
                    ApellidoPersona = x.Apellido,
                    NombrePersona = x.Nombre,
                    Id = context.Usuarios.Any()? context.Usuarios.FirstOrDefault().Id : 0,
                    Nombre = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Nombre : "NO ASIGNADO",
                    EstaBloqueado = x.Usuarios.Any() && x.Usuarios.FirstOrDefault().EstaBloqueado
                }).OrderBy(x=>x.ApellidoPersona).OrderBy(x=>x.NombrePersona).
                    ToList();
            }
        }

        public bool VerificarSiUsuarioExiste(string cadena)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios.Any(x => x.Nombre.Contains(cadena));
            }
        }
    }
}
