namespace XCommerce.Servicio.Core.Marca
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class MarcaServicio : IMarcaServicio
    {
        public void Eliminar(long? MarcaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var MarcaEliminar = context.Marcas.OfType<AccesoDatos.Marca>()
                    .FirstOrDefault(x => x.Id == MarcaId);

                if (MarcaEliminar == null)
                {
                    throw new Exception("No se encontro la Marca");
                }


                MarcaEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoMarca = new AccesoDatos.Marca
                {
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado

                };


                context.Marcas.Add(nuevoMarca);

                context.SaveChanges();

                return nuevoMarca.Id;
            }
        }

        public void Modificar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var MarcaModificar = context.Marcas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (MarcaModificar == null)
                    throw new Exception("No se encontro la Marca");


                MarcaModificar.Descripcion = dto.Descripcion;


                MarcaModificar.EstaEliminado = dto.EstaEliminado;

                context.SaveChanges();
            }
        }

        public IEnumerable<MarcaDto> Obtener(string Nombre)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(Nombre))
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public MarcaDto ObtenerPorId(long? MarcaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }
                    ).FirstOrDefault(x => x.Id == MarcaId);
            }
        }


    }
}
