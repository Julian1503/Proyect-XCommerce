namespace XCommerce.Servicio.Core.Provincia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class ProvinciaServicio : IProvinciaServicio
    {
        public void Eliminar(long provinciaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provinciaEliminar = context.Provincias
                    .FirstOrDefault(x => x.Id == provinciaId);

                if(provinciaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(ProvinciaDto provinciaDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provinciaNueva = new AccesoDatos.Provincia
                {
                    Descripcion = provinciaDto.Descripcion
                };

                context.Provincias.Add(provinciaNueva);

                context.SaveChanges();

                return provinciaNueva.Id;
            }
        }

        public void Modificar(ProvinciaDto provinciaDto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provinciaModificar = context.Provincias
                    .FirstOrDefault(x => x.Id == provinciaDto.Id);

                if (provinciaModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaModificar.Descripcion = provinciaDto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Provincias
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new ProvinciaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public ProvinciaDto ObtenerPorId(long provinciaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Provincias
                    .AsNoTracking()
                    .Select(x => new ProvinciaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x=>x.Id == provinciaId);
            }
        }
    }
}
