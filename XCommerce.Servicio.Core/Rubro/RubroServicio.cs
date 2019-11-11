namespace XCommerce.Servicio.Core.Rubro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class RubroServicio : IRubroServicio
    {
        public void Eliminar(long? RubroId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var RubroEliminar = context.Rubros.OfType<AccesoDatos.Rubro>()
                    .FirstOrDefault(x => x.Id == RubroId);

                if (RubroEliminar == null)
                {
                    throw new Exception("No se encontro el Rubro");
                }
                  

                RubroEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoRubro = new AccesoDatos.Rubro
                {
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado

                };


                context.Rubros.Add(nuevoRubro);

                context.SaveChanges();

                return nuevoRubro.Id;
            }
        }

        public void Modificar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var RubroModificar = context.Rubros                 
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (RubroModificar == null)
                    throw new Exception("No se encontro el Rubro");


                RubroModificar.Descripcion = dto.Descripcion;
                RubroModificar.EstaEliminado = dto.EstaEliminado;
                context.SaveChanges();
            }
        }

        public IEnumerable<RubroDto> Obtener(string Nombre)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(Nombre))
                    .Select(x => new RubroDto
                    {Id=x.Id,
                       Descripcion = x.Descripcion,
                       EstaEliminado=x.EstaEliminado                                      
                    }).ToList();
            }
        }

        public RubroDto ObtenerPorId(long? RubroId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }
                    ).FirstOrDefault(x => x.Id == RubroId);
            }
        }

    }
}
