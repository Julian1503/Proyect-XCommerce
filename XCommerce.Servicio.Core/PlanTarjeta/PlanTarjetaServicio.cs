namespace XCommerce.Servicio.Core.PlanTarjeta
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class PlanTarjetaServicio : IPlanTarjetaServicio
    {
        public long? Agregar(PlanTarjetaDto plan)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var planNuevo = new AccesoDatos.PlanTarjeta
                {
                    Alicuota = plan.Alicuota,
                    TarjetaId = plan.TarjetaId,
                    Descripcion = plan.Descripcion,
                };
                context.PlanesTarjetas.Add(planNuevo);
                context.SaveChanges();
                return planNuevo.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var planTarjetaElim = context.PlanesTarjetas.FirstOrDefault(x => x.Id == entidadId);
                if (planTarjetaElim == null) throw new Exception("No se encontro el Plan de Tarjeta");
                planTarjetaElim.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(PlanTarjetaDto plan)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var planTarjetaMod = context.PlanesTarjetas.FirstOrDefault(x => x.Id == plan.Id);
                if (planTarjetaMod == null) throw new Exception("No se encontro el Plan de Tarjeta");
                planTarjetaMod.Id = plan.Id;
                planTarjetaMod.Alicuota = plan.Alicuota;
                planTarjetaMod.TarjetaId = plan.TarjetaId;
                planTarjetaMod.Descripcion = plan.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<PlanTarjetaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.PlanesTarjetas.AsNoTracking().Include(x => x.Tarjeta)
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) || x.Tarjeta.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new PlanTarjetaDto
                    {
                        Id = x.Id,
                        Alicuota = x.Alicuota,
                        EstaEliminado = x.EstaEliminado,
                        TarjetaId = x.TarjetaId,
                        TarjetaNombre = x.Tarjeta.Descripcion,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }

        public PlanTarjetaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.PlanesTarjetas.AsNoTracking()
                    .Include(x=>x.Tarjeta)
                    .Select(x => new PlanTarjetaDto
                    {
                        Id = x.Id,
                        Alicuota = x.Alicuota,
                        EstaEliminado = x.EstaEliminado,
                        TarjetaId = x.TarjetaId,
                        TarjetaNombre = x.Tarjeta.Descripcion,
                        Descripcion = x.Descripcion
                    }).FirstOrDefault(x=>x.Id==entidadId);
            }
        }
    }
}
