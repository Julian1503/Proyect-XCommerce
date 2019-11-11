namespace XCommerce.Servicio.Core.ListaPrecio
{
    using AccesoDatos;
    using DTOs;
    using System.Collections.Generic;
    using System.Linq;
    using Exception = System.Exception;

    public class ListaPreciosServicio : IListaPreciosServicio
    {
        public long Agregar(ListaPreciosDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var listaPreciosNueva = new AccesoDatos.ListaPrecio
                {
                    Descripcion = dto.Descripcion,
                    Rentabilidad = dto.Rentabilidad
                };
                context.ListaPrecios.Add(listaPreciosNueva);
                context.SaveChanges();
                return listaPreciosNueva.Id;
            }
        }
        
        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var listaPreciosElim = context.ListaPrecios.FirstOrDefault(x => x.Id == entidadId);
                if (listaPreciosElim == null) throw new Exception("No se encontro la Lista de Precios");
                listaPreciosElim.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public bool HayListas()
        {
            using(var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios.Any();
            }
        }

        public void Modificar(ListaPreciosDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var listaPreciosMod = context.ListaPrecios.FirstOrDefault(x => x.Id == dto.Id);
                if (listaPreciosMod == null) throw new Exception("No se encontro la Lista de Precios");
                listaPreciosMod.Descripcion = dto.Descripcion;
                listaPreciosMod.Rentabilidad = dto.Rentabilidad;
                listaPreciosMod.Id = dto.Id;
                context.SaveChanges();
            }
        }

        public IEnumerable<ListaPreciosDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios.AsNoTracking().Where(x=>x.Descripcion.Contains(cadenaBuscar))
                    .Select(x=>new ListaPreciosDto
                {
                    Descripcion = x.Descripcion,
                    Rentabilidad = x.Rentabilidad,
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado
                    
            }).ToList();
            }
        }

        public ListaPreciosDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios.AsNoTracking()
                    .Select(x => new ListaPreciosDto
                    {
                        Descripcion = x.Descripcion,
                        Rentabilidad = x.Rentabilidad,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
