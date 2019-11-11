namespace XCommerce.Servicio.Core.Tarjeta
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class TarjetaServicio : ITarjetaServicio
    {
        public long? Agregar(TarjetaDto tarjeta)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var tarjetaNueva = new AccesoDatos.Tarjeta
                {
                    Descripcion = tarjeta.Descripcion
                };
                context.TarjetaSet.Add(tarjetaNueva);
                context.SaveChanges();
                return tarjetaNueva.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var tarjetaElim = context.TarjetaSet.FirstOrDefault(x => x.Id == entidadId);
                if(tarjetaElim == null) throw new Exception("No se encontro la Tarjeta");
                tarjetaElim.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(TarjetaDto tarjeta)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                var tarjetaMod = context.TarjetaSet.FirstOrDefault(x => x.Id == tarjeta.Id);
                if (tarjetaMod == null) throw new Exception("No se encontro la Tarjeta");
                tarjetaMod.Descripcion = tarjeta.Descripcion;
                tarjetaMod.Id = tarjeta.Id;
                tarjetaMod.EstaEliminado = tarjeta.EstaEliminado;
                context.SaveChanges();
            }
        }

        public IEnumerable<TarjetaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.TarjetaSet.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new TarjetaDto
                    {
                        Id=x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public TarjetaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.TarjetaSet.AsNoTracking().Select(x => new TarjetaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
