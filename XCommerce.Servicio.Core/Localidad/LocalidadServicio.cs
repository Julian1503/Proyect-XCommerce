namespace XCommerce.Servicio.Core.Localidad
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class LocalidadServicio : ILocalidadServicio
    {
        public void Eliminar(long localidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var localidadEliminar = context.Localidades
                    .FirstOrDefault(x => x.Id == localidadId);

                if (localidadEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Localidad");

                localidadEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(LocalidadDto localidadDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var localidadNueva = new AccesoDatos.Localidad
                {
                    Descripcion = localidadDto.Descripcion,
                    ProvinciaId = localidadDto.ProvinciaId
                };

                context.Localidades.Add(localidadNueva);

                context.SaveChanges();

                return localidadNueva.Id;
            }
        }

        public void Modificar(LocalidadDto localidadDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var localidadModificar = context.Localidades
                    .FirstOrDefault(x => x.Id == localidadDto.Id);

                if (localidadModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                localidadModificar.Descripcion = localidadDto.Descripcion;
                localidadModificar.ProvinciaId = localidadDto.ProvinciaId;

                context.SaveChanges();
            }
        }

        public IEnumerable<LocalidadDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades
                    .AsNoTracking()
                    .Include(x => x.Provincia)
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        Provincia = x.Provincia.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public IEnumerable<LocalidadDto> ObtenerPorProvincia(long provinciaId, string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades
                    .AsNoTracking()
                    .Include(x=>x.Provincia)
                    .Where(x => x.ProvinciaId == provinciaId
                                && x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        Provincia = x.Provincia.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public LocalidadDto ObtenerPorId(long localidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Localidades
                    .Include(x=>x.Provincia)
                    .AsNoTracking()
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        Provincia = x.Provincia.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == localidadId);
            }
        }
    }
}
