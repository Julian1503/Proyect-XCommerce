namespace XCommerce.Servicio.Core.Categoria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class CategoriaServicio : ICategoriaServicio
    {
        public void Eliminar(long? CategoriaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CategoriaEliminar = context.Categorias
                    .FirstOrDefault(x => x.Id == CategoriaId);

                if (CategoriaEliminar == null)
                {
                    throw new Exception("No se encontro el Categoria");
                }

                CategoriaEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(CategoriaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaCategoria = new Categoria
                {
                    Id = dto.Id,
                    Descripcion = dto.Descripcion,
                    SalarioCategoria= dto.SalarioCategoria,
                    EstaEliminado=dto.EstaEliminado
                };


                context.Categorias.Add(nuevaCategoria);

                context.SaveChanges();

                return nuevaCategoria.Id;
            }
        }

        public void Modificar(CategoriaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CategoriaModificar = context.Categorias
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (CategoriaModificar == null)
                    throw new Exception("No se encontro el Categoria");


                CategoriaModificar.SalarioCategoria = dto.SalarioCategoria;
                CategoriaModificar.Descripcion = dto.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<CategoriaDto> Obtener(string Nombre)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                  return context.Categorias
                 .AsNoTracking()
                 .Where(x => x.Descripcion.Contains(Nombre))
                 .Select(x => new CategoriaDto
                 {
                     Id = x.Id,
                     Descripcion = x.Descripcion,
                     SalarioCategoria = x.SalarioCategoria
                 }).ToList();
            }
        }

        public CategoriaDto ObtenerPorId(long? CategoriaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Categorias
                    .AsNoTracking()
                    .Select(x => new CategoriaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        SalarioCategoria = x.SalarioCategoria
                    }
                    ).FirstOrDefault(x => x.Id == CategoriaId);
            }
        }

    }
}
