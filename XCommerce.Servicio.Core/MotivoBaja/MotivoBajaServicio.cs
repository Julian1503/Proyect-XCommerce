namespace XCommerce.Servicio.Core.MotivoBaja
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class MotivoBajaServicio : IMotivoBajaServicio
    {
        public long? Agregar(MotivoBajaDto motivoBaja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var MotivoAgregar = new AccesoDatos.MotivoBaja();
                MotivoAgregar.Descripcion = motivoBaja.Descripcion;
                context.MotivosBajas.Add(MotivoAgregar);
                context.SaveChanges();
                return MotivoAgregar.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Eliminar = context.MotivosBajas
                    .FirstOrDefault(x => x.Id == entidadId);

                if (Eliminar == null)
                {
                    throw new Exception("No se encontro el Motivo");
                }


                Eliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public void Modificar(MotivoBajaDto motivoBaja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var motivoModificar = context.MotivosBajas.FirstOrDefault(x => x.Id == motivoBaja.Id);
                if (motivoModificar == null) throw new Exception("No se encontro el Motivo de Baja");
                motivoModificar.Descripcion = motivoBaja.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<MotivoBajaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivosBajas.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar)).
                    Select(x=>new MotivoBajaDto
                    {
                        Id=x.Id,
                        EstaEliminado = x.EstaEliminado,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }

        public MotivoBajaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivosBajas.AsNoTracking().Select(x => new MotivoBajaDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    Descripcion = x.Descripcion
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
