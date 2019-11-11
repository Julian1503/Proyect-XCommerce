using XCommerce.Servicio.Core.CompranteMesa;

namespace XCommerce.Servicio.Core.Reserva
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class ReservaServicio : IReservaServicio
    {
        public long Agregar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var reservaNueva = new Reserva
                {
                    ClienteId = dto.ClienteId,
                    EstadoReserva = dto.EstadoReserva,
                    Fecha = dto.Fecha,
                    MesaId = dto.MesaId,
                    MotivoReservaId = dto.MotivoReservaId,
                    UsuarioId = dto.UsuarioId,
                    Senia = dto.Senia
                };
                context.Reservas.Add(reservaNueva);
                if (dto.EstadoReserva == EstadoReserva.Confirmada)
                {
                    var mesa = new ComprobanteMesaServicio();
                    mesa.Reservar(dto.MesaId,Entidad.Entidad.UsuarioId,dto.ClienteId, reservaNueva.Senia);
                }
                context.SaveChanges();
                return reservaNueva.Id;
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ReservaElim = context.Reservas.FirstOrDefault(x => x.Id == entidadId);
                if(ReservaElim==null) throw new Exception("No se encontro la Reserva");
                var mesa = new ComprobanteMesaServicio();
                mesa.CancelarReserva(ReservaElim.MesaId);
                context.SaveChanges();
            }
        }

        public void Modificar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ReservaMod = context.Reservas.FirstOrDefault(x => x.Id == dto.Id);
                if (ReservaMod == null) throw new Exception("No se encontro la Reserva");
                ReservaMod.ClienteId = dto.ClienteId;
                ReservaMod.Fecha = dto.Fecha;
                ReservaMod.MesaId = dto.MesaId;
                ReservaMod.MotivoReservaId = dto.MotivoReservaId;
                ReservaMod.UsuarioId = dto.UsuarioId;
                ReservaMod.Senia = dto.Senia;
                ReservaMod.Id = dto.Id;
                if (dto.EstadoReserva == EstadoReserva.Confirmada && ReservaMod.EstadoReserva 
                    != EstadoReserva.Confirmada)
                {
                    var mesa = new ComprobanteMesaServicio();
                    mesa.Reservar(dto.MesaId, Entidad.Entidad.UsuarioId, dto.ClienteId,ReservaMod.Senia);
                }

                if (dto.EstadoReserva == EstadoReserva.Cancelada)
                {
                    var mesa = new ComprobanteMesaServicio();
                    mesa.CancelarReserva(dto.MesaId);
                }
                ReservaMod.EstadoReserva = dto.EstadoReserva;

                context.SaveChanges();
            }
        }
        public IEnumerable<ReservaDto>ObtenerReservas(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .Include(x => x.Cliente)
                    .Include(x => x.Mesa)
                    .Include(x => x.Usuario)
                    .AsNoTracking()
                    .Where(x => x.Cliente.Nombre.Contains(cadenaBuscar)
                                || x.Cliente.Apellido.Contains(cadenaBuscar)
                                || x.Mesa.Numero.ToString() == cadenaBuscar
                                || x.Usuario.Nombre.Contains(cadenaBuscar)
                                || x.EstadoReserva.ToString().Equals(cadenaBuscar.Trim())
                    ).Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        EstadoReserva = x.EstadoReserva,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        MotivoReservaId = x.MotivoReservaId,
                        UsuarioId = x.UsuarioId,
                        Senia = x.Senia,
                        EstaEliminado = x.EstaEliminado,
                        ApellidoCliente = x.Cliente.Apellido,
                        NombreCliente = x.Cliente.Nombre,
                        NumeroMesa = x.Mesa.Numero.ToString(),
                        Usuario = x.Usuario.Nombre,
                        Motivo = x.MotivoReserva.Descripcion
                    }).ToList();
            }
        }
        public IEnumerable<ReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .Include(x => x.Cliente)
                    .Include(x => x.Mesa)
                    .Include(x => x.Usuario)
                    .AsNoTracking()
                    .Where(x => x.Cliente.Nombre.Contains(cadenaBuscar)
                                || x.Cliente.Apellido.Contains(cadenaBuscar)
                                || x.Mesa.Numero.ToString() == cadenaBuscar
                                || x.Usuario.Nombre.Contains(cadenaBuscar)
                                || x.EstadoReserva.ToString().Equals(cadenaBuscar.Trim())
                    ).Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        EstadoReserva = x.EstadoReserva,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        MotivoReservaId = x.MotivoReservaId,
                        UsuarioId = x.UsuarioId,
                        Senia = x.Senia,
                        EstaEliminado = x.EstaEliminado,
                        ApellidoCliente = x.Cliente.Apellido,
                        NombreCliente = x.Cliente.Nombre,
                        NumeroMesa = x.Mesa.Numero.ToString(),
                        Usuario = x.Usuario.Nombre,
                        Motivo = x.MotivoReserva.Descripcion
                    }).ToList();
            }
        }

        public ReservaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .AsNoTracking()
                    .Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        EstadoReserva = x.EstadoReserva,
                        Fecha = x.Fecha,
                        MesaId = x.MesaId,
                        MotivoReservaId = x.MotivoReservaId,
                        UsuarioId = x.UsuarioId,
                        Senia = x.Senia,
                        EstaEliminado = x.EstaEliminado,
                        ApellidoCliente = x.Cliente.Apellido,
                        NombreCliente = x.Cliente.Nombre,
                        NumeroMesa = x.Mesa.Numero.ToString(),
                        Usuario = x.Usuario.Nombre,
                        Motivo = x.MotivoReserva.Descripcion
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
