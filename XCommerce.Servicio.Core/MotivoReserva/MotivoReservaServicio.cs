using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.MotivoReserva.DTOs;

namespace XCommerce.Servicio.Core.MotivoReserva
{
    public class MotivoReservaServicio : IMotivoReservaServicio
    {
        public long Agregar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
               
                    var MotivoAgregar = new AccesoDatos.MotivoReserva();
                    MotivoAgregar.Descripcion = dto.Descripcion;
                    context.MotivoReservas.Add(MotivoAgregar);
                    context.SaveChanges();
                    return MotivoAgregar.Id;
                
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Eliminar = context.MotivoReservas.FirstOrDefault(x => x.Id == entidadId);
                if (Eliminar == null) throw new Exception("No se encontro el Motivo de Reserva");
                Eliminar.Descripcion = "HOLA SI GUARDO"; 
                Eliminar.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var motivoModificar = context.MotivoReservas.FirstOrDefault(x => x.Id == dto.Id);
                if (motivoModificar == null) throw new Exception("No se encontro el Motivo de Reserva");
                motivoModificar.Id = dto.Id;
                motivoModificar.Descripcion = dto.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<MotivoReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivoReservas.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar)).
                    Select(x => new MotivoReservaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public MotivoReservaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivoReservas.AsNoTracking().Select(x => new MotivoReservaDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    Descripcion = x.Descripcion
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
