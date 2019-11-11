namespace XCommerce.Servicio.Core.Mesa
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class MesaServicio : IMesaServicio
    {
        public long? Agregar(MesaDto mesa)
        {
            
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaNueva = new AccesoDatos.Mesa
                {
                    Descripcion = mesa.Descripcion,
                    EstaEliminado = mesa.EstaEliminado,
                    EstadoMesa = mesa.EstadoMesa,
                    TipoMesa = mesa.TipoMesa,
                    Numero = mesa.Numero,
                    SalonId = mesa.SalonId
                };
                context.Mesas.Add(mesaNueva);
                context.SaveChanges();
                return mesaNueva.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaEliminar = context.Mesas.FirstOrDefault(x => x.Id == entidadId);
                if(mesaEliminar ==null)
                throw new Exception("No se encontro la Mesa");
                mesaEliminar.EstaEliminado = true;
                context.SaveChanges();
            }
        }

            public void Modificar(MesaDto mesa)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaMod = context.Mesas.FirstOrDefault(x => x.Id == mesa.Id);
                if (mesaMod == null)
                    throw new Exception("No se encontro la Mesa");
                mesaMod.Descripcion = mesa.Descripcion;
                mesaMod.Id = mesa.Id;
                mesaMod.EstaEliminado = mesa.EstaEliminado;
                mesaMod.EstadoMesa = mesaMod.EstadoMesa;
                mesaMod.TipoMesa = mesa.TipoMesa;
                mesaMod.Numero = mesa.Numero;
                mesaMod.SalonId = mesa.SalonId;
                context.SaveChanges();
            }

        }

        public IEnumerable<MesaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.Include(x => x.Salon).AsNoTracking().Where(x =>
                    x.Descripcion.Contains(cadenaBuscar) || x.EstadoMesa.ToString().Contains(cadenaBuscar) ||
                    x.Salon.Descripcion.Contains(cadenaBuscar)).Select(x => new MesaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,
                    Numero = x.Numero,
                    SalonId = x.SalonId,
                    EstadoMesa = x.EstadoMesa,
                    SalonNombre = x.Salon.Descripcion,
                    TipoMesa = x.TipoMesa
                    }).ToList();
            }
        }
        public IEnumerable<MesaDto> ObtenerSinReservas(long? mesaId = null)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.Include(x => x.Salon).AsNoTracking().Where(x =>!x.EstaEliminado && (x.EstadoMesa==EstadoMesa.Cerrada||x.Id == mesaId)).Select(x => new MesaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,
                    Numero = x.Numero,
                    SalonId = x.SalonId,
                    EstadoMesa = x.EstadoMesa,
                    SalonNombre = x.Salon.Descripcion,
                    TipoMesa = x.TipoMesa
                }).ToList();
            }
        }

        public MesaDto ObtenerPorId(long? entidadId)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.AsNoTracking().Select(x => new MesaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado,
                    SalonNombre = x.Salon.Descripcion,
                    Numero = x.Numero,
                    SalonId = x.SalonId,
                    EstadoMesa = x.EstadoMesa,
                    TipoMesa = x.TipoMesa
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public IEnumerable<MesaDto> ObtenerPorSalon(long id, string cadena)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.AsNoTracking().Where(x => x.SalonId == id && x.Descripcion.Contains(cadena))
                    .Select(x => new MesaDto
                    {
                        Id=x.Id,
                        Descripcion = x.Descripcion,
                        EstadoMesa = x.EstadoMesa,
                        Numero = x.Numero,
                        SalonId = x.SalonId,
                        TipoMesa = x.TipoMesa
                    }).ToList();
            }
        }

        public int ObtenerSiguienteNumero()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Mesas.Any())
                {
                    return context.Mesas.Max(x => x.Numero) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }

      
}

