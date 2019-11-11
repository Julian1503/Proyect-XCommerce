
namespace XCommerce.Servicio.Core.CondicionIva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;
    public class CondicionIvaServicio : ICondicionIvaServicio
    {
        public long? Agregar(CondicionIvaDto ci)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CondicionIva = new AccesoDatos.CondicionIva
                {
                    Descripcion = ci.Descripcion,
                    EstaEliminado = ci.EstaEliminado
                };
                context.CondicionIvas.Add(CondicionIva);
                context.SaveChanges();
                return CondicionIva.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CondicionIva = context.CondicionIvas.FirstOrDefault(x => x.Id == entidadId);
                if (CondicionIva == null) throw new Exception("Error no se encuentra la entidad");
                CondicionIva.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(CondicionIvaDto ci)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var CondicionIva = context.CondicionIvas.FirstOrDefault(x => x.Id == ci.Id);
                if (CondicionIva == null) throw new Exception("Error no se encuentra la entidad");
                CondicionIva.Id = ci.Id;
                CondicionIva.Descripcion = ci.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<CondicionIvaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar)).Select(x =>
                    new CondicionIvaDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }

        public CondicionIvaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CondicionIvas.AsNoTracking().Select(x => new CondicionIvaDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    Descripcion = x.Descripcion
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
