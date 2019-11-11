
using XCommerce.Servicio.Core.FormaPago;

namespace XCommerce.Servicio.Core.CompranteMesa
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using Comprobante;
    using CuentaCorriente;
    using DetalleCaja;
    using DTOs;
    using Operacion;
    using Movimiento;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.Movimiento.DTOs;

    public class ComprobanteMesaServicio : IComprobanteMesaServicio
    {
        public void Abrir(long mesaId, long usuarioId, int comensales, long? mozoId = null)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesa = context.Mesas.FirstOrDefault(x => x.Id == mesaId);
                if (mesa == null) throw new Exception("no se encontro la entidad");
                mesa.EstadoMesa = EstadoMesa.Abierta;

                if (context.Comprobantes.OfType<ComprobanteSalon>().Any(x =>
                    x.MesaId == mesaId && x.EstadoComprobante ==
                    EstadoComprobanteSalon.Proceso))
                {
                    context.SaveChanges();
                    return;
                }

                var cliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(x =>
                    x.Dni == "99999999");
                if (cliente == null) throw new Exception("no se encontro la entidad");
                
                var comprobanteNuevo = new ComprobanteSalon
                {
                    Numero =0 ,
                    Fecha = DateTime.Now,
                    SubTotal = 0m,
                    Descuento = 0m,
                    Total = 0m,
                    MozoId = mozoId,
                    UsuarioId = usuarioId,
                    ClienteId = cliente.Id,
                    TipoComprobante = TipoComprobante.X,
                    Comensal = comensales,
                    MesaId = mesaId,
                    DetalleComprobantes = new List<DetalleComprobante>(),
                    EstadoComprobante = EstadoComprobanteSalon.Proceso
                };
                context.Comprobantes.Add(comprobanteNuevo);
                context.SaveChanges();

            }
        }

        public void CancelarReserva(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesa = context.Mesas.FirstOrDefault(x => x.Id == mesaId);
                if (mesa == null) throw new Exception("no se encontro la entidad");
                mesa.EstadoMesa = EstadoMesa.Cerrada;

                if (context.Comprobantes.OfType<ComprobanteSalon>().Any(x =>
                    x.MesaId == mesaId && x.EstadoComprobante ==
                    EstadoComprobanteSalon.Proceso))
                {
                    var compro = context.Comprobantes.OfType<ComprobanteSalon>().FirstOrDefault(x =>
                        x.MesaId == mesaId && x.EstadoComprobante ==
                        EstadoComprobanteSalon.Proceso);
                    compro.EstadoComprobante = EstadoComprobanteSalon.Finalizado;
                    compro.Comensal = 0;
                    compro.Descuento = 0;
                    compro.Total = 0;
                }
                var reser =
                context.Reservas.FirstOrDefault(x => x.MesaId == mesaId && x.EstadoReserva == EstadoReserva.Confirmada);
                reser.EstaEliminado = true;
                reser.EstadoReserva = EstadoReserva.Cancelada;
                context.SaveChanges();

            }
        }

        public void Reservar(long mesaId, long usuarioId, long clienteId, decimal monto = 0, long? mozoId = null)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesa = context.Mesas.FirstOrDefault(x => x.Id == mesaId);
                if (mesa == null) throw new Exception("no se encontro la entidad");
                mesa.EstadoMesa = EstadoMesa.Reservado;

                if (context.Comprobantes.OfType<ComprobanteSalon>().Any(x =>
                    x.MesaId == mesaId && x.EstadoComprobante ==
                    EstadoComprobanteSalon.Proceso))
                {
                    context.SaveChanges();
                    return;
                }

                var comprobanteNuevo = new ComprobanteSalon
                {
                    Numero = 0,
                    Fecha = DateTime.Now,
                    SubTotal = monto,
                    Descuento = 0m,
                    Total = monto,
                    MozoId = mozoId,
                    UsuarioId = usuarioId,
                    ClienteId = clienteId,
                    TipoComprobante = TipoComprobante.X,
                    Comensal = 1,
                    MesaId = mesaId,
                    DetalleComprobantes = new List<DetalleComprobante>(),
                    EstadoComprobante = EstadoComprobanteSalon.Proceso
                };
                context.Comprobantes.Add(comprobanteNuevo);
                context.SaveChanges();

            }
        }

        public void CerrarMesa
            (ComprobanteMesaDto Comprobante,TipoComprobante tipoComprobante)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (Comprobante.Total == 0)
                {
                    var mesaCero = context.Mesas.FirstOrDefault(x => x.Id == Comprobante.MesaId);
                    if (mesaCero == null) throw new Exception("no se encontro la entidad");
                    mesaCero.EstadoMesa = EstadoMesa.Cerrada;
                    var comprobanteCero = context.Comprobantes.OfType<ComprobanteSalon>().FirstOrDefault(x =>
                    x.MesaId == Comprobante.MesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                    comprobanteCero.EstadoComprobante = EstadoComprobanteSalon.Finalizado;
                    context.SaveChanges();
                    return;
                }

                //CAMBIAR ESTADO MESA
                var mesa = context.Mesas.FirstOrDefault(x => x.Id == Comprobante.MesaId);
                if (mesa == null) throw new Exception("no se encontro la entidad");
                mesa.EstadoMesa = EstadoMesa.Cerrada;
                //CAMBIAR ESTADO COMPROBANTE
                var comprobante = context.Comprobantes.OfType<ComprobanteSalon>().FirstOrDefault(x =>
                x.MesaId == Comprobante.MesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                comprobante.Numero = NumeroDeComprobante.UltimoNumeroComprobante();
                comprobante.TipoComprobante = tipoComprobante;
                comprobante.SubTotal = Comprobante.SubTotal;
                comprobante.Descuento = Comprobante.Descuento;
                comprobante.Total = Comprobante.Total;
                comprobante.EstadoComprobante = EstadoComprobanteSalon.Finalizado;
                comprobante.TipoComprobante = Comprobante.TipoComprobante;
                MovimientoServicio m = new MovimientoServicio();
                FormaPagoServicio fp = new FormaPagoServicio();

                if (Comprobante.MontoEfectivo>0)
                   {
                       //GENERAR MOVIMIENTO
                       m.GenerarMovimiento(new MovimientoDto
                       {
                           CajaId = Entidad.Entidad.CajaId,
                           ComprobanteId = comprobante.Id,
                           Fecha = DateTime.Now,
                           Monto = Comprobante.MontoEfectivo,
                           TipoMovimento = TipoMovimiento.Ingreso,
                           Descripcion = $"FC_{comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                           UsuarioId = Entidad.Entidad.UsuarioId
                       });
                   }

                if (Comprobante.MontoCtaCte > 0)
                   {
                    //GENERAR MOVIMIENTO
                       m.GenerarMovimiento(new MovimientoDto
                       {
                           CajaId = Entidad.Entidad.CajaId,
                           ComprobanteId = comprobante.Id,
                           Fecha = DateTime.Now,
                           Monto = Comprobante.MontoCtaCte,
                           TipoMovimento = TipoMovimiento.Ingreso,
                           Descripcion = $"CC_{comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                           UsuarioId = Entidad.Entidad.UsuarioId
                       });
                   }

                if (Comprobante.MontoTarjeta > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = Comprobante.MontoTarjeta,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"TC_{comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                if (Comprobante.MontoCheque > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = Comprobante.MontoCheque,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"CH_{comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }
                context.SaveChanges();
            }
        }

        public void CancelarVenta(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesa = context.Mesas.FirstOrDefault(x => x.Id == mesaId);
                if (mesa == null) throw new Exception("no se encontro la entidad");
                mesa.EstadoMesa = EstadoMesa.Cerrada;

                if (context.Comprobantes.OfType<ComprobanteSalon>().Any(x =>
                    x.MesaId == mesaId && x.EstadoComprobante ==
                    EstadoComprobanteSalon.Proceso))
                {

                    var compro = context.Comprobantes.OfType<ComprobanteSalon>().FirstOrDefault(x =>
                        x.MesaId == mesaId && x.EstadoComprobante ==
                        EstadoComprobanteSalon.Proceso);
                    context.Comprobantes.Remove(compro);
                    compro.EstadoComprobante = EstadoComprobanteSalon.Finalizado;
                    compro.Comensal = 0;
                    compro.Descuento = 0;
                    compro.Total = 0;
                    var det = context.DetalleComprobantes.Where(x => x.ComprobanteId == compro.Id);
                    if(det!=null)
                    {
                        foreach (var art in det)
                        {
                            var articulos = context.Articulos.FirstOrDefault(x => x.Id == art.ArticuloId);
                            if(articulos!=null)
                            {
                                if (articulos.DescuentaStock)
                                {
                                    articulos.Stock += art.Cantidad;
                                }

                                context.DetalleComprobantes.Remove(art);
                            }
                        }
                    }
                }

                context.SaveChanges();

            }
        }

        public bool ComprobantesCerrados()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>()
                    .All(x => x.EstadoComprobante == EstadoComprobanteSalon.Finalizado);
            }
        }

        public ComprobanteMesaDto ObtenerComprobanteMesa(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>().AsNoTracking().Where(x =>
                    x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso).Select(x =>
                    new ComprobanteMesaDto
                    {
                        Id=x.Id,
                        ClienteId = x.ClienteId,
                        UsuarioId = x.UsuarioId,
                        MesaId = x.MesaId,
                        MozoId = x.MozoId,
                        NumeroComprobante=x.Numero,
                        ComprobanteId = x.Id,
                        Comensal = x.Comensal,
                        Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                        ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                        NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                        ApellidoCliente = x.Cliente.Apellido,
                        NombreCliente = x.Cliente.Nombre,
                        DniCliente = x.Cliente.Dni,
                        Descuento = x.Descuento,
                        Items = x.DetalleComprobantes.Select(d => new DetalleComprobanteDto
                        {
                                    ArticuloId = d.ArticuloId,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            PrecioUnitario = d.PrecioUnitario,
                            CodigoProducto = d.Codigo
                        }).ToList()
                    }).FirstOrDefault();

            }

        }
        public ComprobanteMesaDto ObtenerPorId(long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>().AsNoTracking().Where(x =>x.Id==id).Select(x =>
                    new ComprobanteMesaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        NumeroComprobante = x.Numero,
                        UsuarioId = x.UsuarioId,
                        MesaId = x.MesaId,
                        MozoId = x.MozoId,
                        ClienteApellido = x.Cliente.Apellido,
                        ClienteNombre = x.Cliente.Nombre,
                        Fecha = x.Fecha,
                        TipoComprobante = x.TipoComprobante,
                        ComprobanteId = x.Id,
                        Comensal = x.Comensal,
                        Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                        ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                        NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                        ApellidoCliente = x.Cliente.Apellido,
                        NombreCliente = x.Cliente.Nombre,
                        DniCliente = x.Cliente.Dni,
                        Descuento = x.Descuento,
                        Items = x.DetalleComprobantes.Select(d => new DetalleComprobanteDto
                        {
                            ArticuloId = d.ArticuloId,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            PrecioUnitario = d.PrecioUnitario,
                            CodigoProducto = d.Codigo,
                            ComprobanteId = d.ComprobanteId
                        }).ToList()
                    }).FirstOrDefault();

            }

        }

        public IEnumerable<ComprobanteMesaDto> ObtenerComprobanteMesaPorCliente(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<ComprobanteSalon>().AsNoTracking()
                    .Where(x => x.ClienteId == clienteId
                                &&
                                x.EstadoComprobante == EstadoComprobanteSalon.Finalizado && x.Total!=0)
                    .Select(x =>
                        new ComprobanteMesaDto
                        {
                            Id=x.Id,
                            ClienteId = x.ClienteId,
                            UsuarioId = x.UsuarioId,
                            MesaId = x.MesaId,
                            MozoId = x.MozoId,
                            ComprobanteId = x.Id,
                            Fecha = x.Fecha,
                            Comensal = x.Comensal,
                        NumeroComprobante=x.Numero,
                            Legajo = x.MozoId.HasValue ? x.Mozo.Legajo : 0,
                            ApellidoMozo = x.MozoId.HasValue ? x.Mozo.Apellido : "NO",
                            NombreMozo = x.MozoId.HasValue ? x.Mozo.Nombre : "ASIGNADO",
                            ApellidoCliente = x.Cliente.Apellido,
                            NombreCliente = x.Cliente.Nombre,
                            DniCliente = x.Cliente.Dni,
                            Descuento = x.Descuento,
                            Items = context.DetalleComprobantes.Where(y => y.ComprobanteId == x.Id).Select(y =>
                                new DetalleComprobanteDto
                                {
                                    ArticuloId = y.ArticuloId,
                                    Descripcion = y.Descripcion,
                                    PrecioUnitario = y.PrecioUnitario,
                                    Cantidad = y.Cantidad,
                                    CodigoProducto = y.Codigo
                                }).ToList()

                        }).ToList();

            }

        }

        public void EliminarProducto(long mesaId, ArticuloDto dto, decimal cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                if (comprobante == null) throw new Exception("No se encontro la entidad");
                var detalle = comprobante.DetalleComprobantes.FirstOrDefault(x => x.Codigo == dto.Codigo && x.PrecioUnitario == dto.Precio);
                if (detalle == null) throw new Exception("No se encontro la entidad");

                
                    detalle.Cantidad -= cantidad;
                    detalle.SubTotal = detalle.Cantidad * detalle.PrecioUnitario;
               
                if (dto.DescuentaStock)
                {
                    var articulo = context.Articulos.FirstOrDefault(x => x.Id == dto.Id);
                    if (articulo == null) throw new Exception("No se encontro la entidad");

                    articulo.Stock += cantidad;

                }

                context.SaveChanges();
            }
        }

        public void AgregarArticulo(long mesaId, ArticuloDto dto, decimal cantidad)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                if (comprobante == null) throw new Exception("No se encontro la entidad");
                var detalle = comprobante.DetalleComprobantes.FirstOrDefault(x => x.Codigo == dto.Codigo && x.PrecioUnitario==dto.Precio);
                if (detalle == null)
                {
                    comprobante.DetalleComprobantes.Add(new AccesoDatos.DetalleComprobante
                    {
                        ArticuloId = dto.Id,
                        Cantidad = cantidad,
                        Codigo = dto.Codigo,
                        ComprobanteId = comprobante.Id,
                        Descripcion = dto.Descripcion,
                        PrecioUnitario =(decimal) dto.Precio,
                        SubTotal = cantidad * (decimal)dto.Precio
                    });
                }
                else
                {
                    detalle.Cantidad += cantidad;
                    detalle.SubTotal = detalle.Cantidad * detalle.PrecioUnitario;
                }

                if (dto.DescuentaStock)
                {
                    var articulo = context.Articulos.FirstOrDefault(x => x.Id == dto.Id);
                    if (articulo == null) throw new Exception("No se encontro la entidad");
                    
                        articulo.Stock -= cantidad;
                    
                }

                context.SaveChanges();
            }
        }

        public void AgregarMozo(long mesaId, long mozo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                if (comprobante == null) throw new Exception("No se encontro la entidad");
                comprobante.MozoId = mozo;
                context.SaveChanges();
            }

        }
        
        public void AgregarAlComprobante(long mesaId,int numero,decimal descuento,decimal total)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId && x.EstadoComprobante == EstadoComprobanteSalon.Proceso);
                if (comprobante == null) throw new Exception("No se encontro la entidad");

                comprobante.Comensal = numero;
                comprobante.Total = total;
                comprobante.Descuento = descuento;

                context.SaveChanges();

            }
        }
        
    }
}
