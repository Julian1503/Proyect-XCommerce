namespace XCommerce.Servicio.Core.Movimiento
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class MovimientoServicio : IMovimientoServicio
    {
      
        public void GenerarMovimiento(MovimientoDto movimiento)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var movi = context.Movimientos.Add(new AccesoDatos.Movimiento
                {
                    CajaId = movimiento.CajaId,
                    ComprobanteId = movimiento.ComprobanteId,
                    Descripcion = movimiento.Descripcion,
                    Fecha = movimiento.Fecha,
                    Monto = movimiento.Monto,
                    UsuarioId = movimiento.UsuarioId,
                    TipoMovimento = movimiento.TipoMovimento
                });
                context.Movimientos.Add(movi);
                context.SaveChanges();
            }
        }

        public bool HayMovimientos(DateTime p, DateTime u)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos.Any(x=>x.Fecha>=p && x.Fecha<=u);
            }
        }

        public IEnumerable<MovimientoDto> Obtener(DateTime fechaApertura,DateTime fechaCierre)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos.OfType<AccesoDatos.Movimiento>().Where(x => x.Fecha >= fechaApertura && x.Fecha <= fechaCierre)
                    .Select(x => new MovimientoDto
                    {CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Monto = x.Monto,
                        TipoMovimento = x.TipoMovimento,
                        UsuarioId = x.UsuarioId
                        
                    }).ToList();
            }
        }
        public IEnumerable<MovimientoDto> Obtener(string cadena)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos.OfType<AccesoDatos.Movimiento>().Where(x=>x.Descripcion.Contains(cadena))
                    .Select(x => new MovimientoDto
                    {
                        CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Monto = x.Monto,
                        TipoMovimento = x.TipoMovimento,
                        UsuarioId = x.UsuarioId

                    }).OrderByDescending(x=>x.Fecha).ToList();
            }
        }
        public IEnumerable<MovimientoDto> ObtenerPorCaja(long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Movimientos.OfType<AccesoDatos.Movimiento>().Where(x => x.CajaId == cajaId)
                    .Select(x => new MovimientoDto
                    {
                        CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Monto = x.Monto,
                        TipoMovimento = x.TipoMovimento,
                        UsuarioId = x.UsuarioId,
                        Id =x.Id
                    }).ToList();
            }
        }
        public int ObtenerVentasHoy()
        {
            using (var context = new ModeloXCommerceContainer())
            {   
                return context.Movimientos.Where(x => x.TipoMovimento == TipoMovimiento.Ingreso && x.Fecha.Day == DateTime.Now.Day && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Year == DateTime.Now.Year).Count();
            }
        }
    }
}
