namespace XCommerce.Servicio.Core.Salon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class SalonServicio : ISalonServicio
    {
        public long? Agregar(SalonDto salon)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonAgregar = new AccesoDatos.Salon
                {
                    Descripcion = salon.Descripcion,
                    ListaPrecioId = salon.ListaPreciosId
                    
                };
                context.Salones.Add(salonAgregar);
                context.SaveChanges();
                return salonAgregar.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonElim = context.Salones.FirstOrDefault(x => x.Id == entidadId);
                if (salonElim == null) throw new Exception("No se encontro el Salon");
                salonElim.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(SalonDto salon)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var salonMod = context.Salones.FirstOrDefault(x => x.Id == salon.Id);
                if (salonMod == null) throw new Exception("No se encontro el Salon");
                salonMod.Descripcion = salon.Descripcion;
                salonMod.EstaEliminado = salon.EstaEliminado;
                salonMod.Id = salon.Id;
                salonMod.ListaPrecioId = salon.ListaPreciosId;

                context.SaveChanges();
            }
        }

        public IEnumerable<SalonDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar)).Select(x=>new SalonDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,
                    ListaPreciosId = x.ListaPrecioId
                }).ToList();
            }
        }

        public SalonDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones.AsNoTracking().Select(x => new SalonDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,
                    ListaPreciosId = x.ListaPrecioId
                }).FirstOrDefault(x=>x.Id==entidadId);
            }
        }
    }
}
