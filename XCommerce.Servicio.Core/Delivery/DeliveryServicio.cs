using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.CuentaCorriente;
using XCommerce.Servicio.Core.Delivery.DTOs;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.Movimiento.DTOs;
using XCommerce.Servicio.Core.Operacion;

namespace XCommerce.Servicio.Core.Delivery
{
    public class DeliveryServicio : IDeliveryServicio
    {

        public int DeliveryDia()
        {
            using(var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().Where(x => x.Fecha.Day == DateTime.Now.Day && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Year == DateTime.Now.Year).Count();
            }
        }


        public void GenerarComprobante(DeliveryDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (dto == null)
                    throw new Exception("Comprobante null");
                long direccion = dto.DireccionId;

                if (dto.DireccionId == 0)
                {
                    direccion = context.Direcciones.FirstOrDefault(x=>x.Persona.Id==dto.ClienteId).Id;
                }

                var comprobante = new ComprobanteDelivery
                {
                    CadeteId = dto.CadeteId,
                    ClienteId = dto.ClienteId,
                    EstadoPedido = EstadoPedido.Pendiente,
                    Numero = NumeroDeComprobante.UltimoNumeroComprobante(),
                    Fecha = DateTime.Now,
                    SubTotal = dto.SubTotal,
                    Descuento = dto.Descuento,
                    Total = dto.Total,
                    UsuarioId = Entidad.Entidad.UsuarioId,
                    TipoComprobante = TipoComprobante.X,
                    DireccionId = direccion,
                    TipoPedido = TipoPedido.Telefono,
                    DetalleComprobantes = new List<AccesoDatos.DetalleComprobante>()
                };
                foreach (var x in dto.Items)
                {
                    var detalle = new AccesoDatos.DetalleComprobante()
                    {
                        Cantidad = x.Cantidad,
                        Codigo = x.CodigoProducto,
                        Descripcion = x.Descripcion,
                        PrecioUnitario = x.PrecioUnitario,
                        ArticuloId = x.ArticuloId,
                        SubTotal = x.SubTotal,
                        ComprobanteId = dto.Id
                    };
                    comprobante.DetalleComprobantes.Add(detalle);
                }
                context.Comprobantes.Add(comprobante);
                context.SaveChanges();
            }
        }
        //public void EditarComprobante(DeliveryDto dto)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //       var comprobante = context.Comprobantes.OfType<ComprobanteDelivery>().FirstOrDefault(x => x.Id == dto.Id);
        //        long direccion = dto.DireccionId;
        //        if (dto.DireccionId == 0)
        //        {
        //            direccion = context.Direcciones.FirstOrDefault(x => x.Persona.Id == dto.ClienteId).Id;
        //        }
        //        comprobante.Id = dto.Id;
        //            comprobante.Fecha = DateTime.Now;
        //            comprobante.CadeteId = dto.CadeteId;
        //            comprobante.ClienteId = dto.ClienteId;
        //            comprobante.Descuento = dto.Descuento;
        //            comprobante.CadeteId = dto.CadeteId;
        //            comprobante.DireccionId = direccion;
        //            comprobante.Numero = dto.Numero;
        //            comprobante.EstadoPedido = dto.Estado;
        //            comprobante.TipoPedido = dto.TipoPedido;
        //            comprobante.UsuarioId = dto.UsuarioId;
        //            comprobante.SubTotal = dto.SubTotal;
        //            comprobante.Total = dto.Total;
        //            comprobante.UsuarioId = Entidad.Entidad.UsuarioId;
        //            context.SaveChanges();
        //    }
        //}
        public void Enviar(long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
             var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().FirstOrDefault(x => x.Id == comprobanteId);
                comprobante.EstadoPedido = EstadoPedido.Enviado;
                context.SaveChanges();
            }
        }

        public DeliveryDto Reporte(long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().Select(x => new DeliveryDto
                {

                }).FirstOrDefault(x => x.Id == id);
            }
        }

        public void Cancelar(long comprobanteId)
        {
            using(var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().FirstOrDefault(x => x.Id == comprobanteId);
                comprobante.EstadoPedido = EstadoPedido.Cancelado;
                context.SaveChanges();
            }
        }

        public IEnumerable<DeliveryDto> ObtenerPorDia()
        {
            using(var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes
                    .AsNoTracking()
                    .OfType<ComprobanteDelivery>()
                    .Where(x => x.Fecha.CompareTo(DateTime.Today)==0 || x.Fecha.CompareTo(DateTime.Today) == 1)
                .Select(x => new DeliveryDto
                {
                    Id=x.Id,
                    Fecha=x.Fecha,
                    CadeteId=x.CadeteId,
                    ClienteId=x.ClienteId,
                    ClienteNombre=x.Cliente.Nombre,
                    ClienteApellido = x.Cliente.Apellido,
                    CadeteApellido = x.Cadete.Apellido,
                    CadeteNombre=x.Cadete.Nombre,
                    Descuento=x.Descuento,
                    Legajo=x.Cadete.Legajo,
                    DireccionId=x.DireccionId,
                    Calle = x.Direccion.Calle,
                    TipoComprobante=x.TipoComprobante,
                    Numero = x.Direccion.Numero,
                    NumeroComprobante = x.Numero,
                    Estado=x.EstadoPedido,
                    TipoPedido=x.TipoPedido,
                    UsuarioId=x.UsuarioId,
                    Items = x.DetalleComprobantes.Where(y => y.ComprobanteId == x.Id)
                    .Select(y => new DetalleComprobanteDto
                    {
                        ArticuloId = y.ArticuloId,
                        Cantidad = y.Cantidad,
                        CodigoProducto = y.Codigo,
                        Descripcion = y.Descripcion,
                        PrecioUnitario = y.PrecioUnitario
                    }).ToList(),
                }).ToList().OrderBy(x=>x.Fecha.Hour).OrderByDescending(x=>x.Estado == EstadoPedido.Pendiente);
            }
        }

        public IEnumerable<DeliveryDto> ObtenerTodos(string cadena)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes
                    .AsNoTracking()
                    .OfType<ComprobanteDelivery>()
                    .Where(x=>x.Cadete.Nombre.Contains(cadena) ||x.Cliente.Nombre.Contains(cadena)
                    || x.Cliente.Apellido.Contains(cadena) || x.Cadete.Apellido.Contains(cadena))
                    .Select(x => new DeliveryDto
                {
                        Id=x.Id,
                    CadeteApellido = x.Cadete.Apellido,
                    CadeteId=x.CadeteId,
                    CadeteNombre=x.Cadete.Nombre,
                    Calle=x.Direccion.Calle,
                    ClienteApellido=x.Cliente.Apellido,
                    ClienteId=x.ClienteId,
                    ClienteNombre=x.Cliente.Nombre,
                    TipoComprobante=x.TipoComprobante,
                    Descuento=x.Descuento,
                        Legajo =x.Cadete.Legajo,
                    DireccionId=x.DireccionId,
                    Estado =x.EstadoPedido,
                     Fecha=x.Fecha,
                     Numero=x.Direccion.Numero,
                     NumeroComprobante=x.Numero,
                     TipoPedido=x.TipoPedido,
                     UsuarioId=x.UsuarioId,
                     Items= x.DetalleComprobantes.Select(y=> new DetalleComprobanteDto
                     {
                         ArticuloId = y.ArticuloId,
                            Cantidad =y.Cantidad,
                         CodigoProducto=y.Codigo,
                         Descripcion=y.Descripcion,
                         PrecioUnitario=y.PrecioUnitario
                     }).ToList()
                }).OrderByDescending(x=>x.Fecha).ToList();
            }
        }

        public void Entregar(DeliveryDto comprobante)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var Comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().FirstOrDefault(x => x.Id == comprobante.Id);
                Comprobante.EstadoPedido = EstadoPedido.Entregado;
                Comprobante.TipoComprobante = comprobante.TipoComprobante;
                var movimiento = new MovimientoServicio();
                movimiento.GenerarMovimiento(new MovimientoDto
                {
                    Monto=comprobante.Total,
                    CajaId=Entidad.Entidad.CajaId,
                    ComprobanteId=comprobante.Id,
                    Fecha=DateTime.Now,
                    TipoMovimento=TipoMovimiento.Ingreso,
                    UsuarioId=Entidad.Entidad.UsuarioId,
                    Descripcion= $"FC_{ Comprobante.TipoComprobante }_{ comprobante.Numero.ToString("0000") }_{ comprobante.Fecha.ToString("ddmmyyyy") }"
                });


                foreach (var item in Comprobante.DetalleComprobantes)
                {
                    if (context.Articulos.FirstOrDefault(x => x.Id == item.ArticuloId).DescuentaStock)
                    {
                        var articulo = context.Articulos.FirstOrDefault(x => x.Id == item.ArticuloId);
                        if (articulo == null) throw new Exception("No se encontro la entidad");

                        articulo.Stock -= item.Cantidad;
                    }
                }

                //TODO
                MovimientoServicio m = new MovimientoServicio();

                if (comprobante.MontoEfectivo > 0)
                {
                    //GENERAR MOVIMIENTO
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoEfectivo,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"FC_{Comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                if (comprobante.MontoCtaCte > 0)
                {
                    //CUENTA CORRIENTE NO GENERA DETALLE DE CAJA AL INSTANTE(DEBE PAGAR PARA GENERARLO)
                    CuentaCorrienteServicio cta = new CuentaCorrienteServicio();
                    cta.Vender(comprobante.ClienteId, comprobante.Total);
                    OperacionServicio op = new OperacionServicio();
                    op.Agregar(new OperacionDto
                    {
                        TipoOperacion = TipoOperacion.Venta,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoCtaCte,
                        CuentaCorrienteId = cta.ObtenerCorrientePorClienteId(comprobante.ClienteId).Id
                    });
                    //GENERAR MOVIMIENTO
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoCtaCte,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"CC_{Comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                if (comprobante.MontoTarjeta > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoTarjeta,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"TC_{Comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                if (comprobante.MontoCheque > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoCheque,
                        TipoMovimento = TipoMovimiento.Ingreso,
                        Descripcion = $"CH_{Comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }
                context.SaveChanges();
            }
        }
        public void EditarComprobante(DeliveryDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (dto == null)
                    throw new Exception("Comprobante null");

                var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().FirstOrDefault(x => x.Id == dto.Id);
                    comprobante.CadeteId = dto.CadeteId;
                    comprobante.ClienteId = dto.ClienteId;
                    comprobante.EstadoPedido = EstadoPedido.Pendiente;
                    comprobante.Numero = NumeroDeComprobante.UltimoNumeroComprobante();
                    comprobante.Fecha = DateTime.Now;
                    comprobante.SubTotal = dto.SubTotal;
                    comprobante.Descuento = dto.Descuento;
                    comprobante.Total = dto.Total;
                    comprobante.UsuarioId = Entidad.Entidad.UsuarioId;
                    comprobante.TipoComprobante = TipoComprobante.C;
                    comprobante.DireccionId = dto.DireccionId;
                    comprobante.TipoPedido = TipoPedido.Telefono;
                context.DetalleComprobantes.RemoveRange(context.DetalleComprobantes.Where(x => x.ComprobanteId == comprobante.Id));
                comprobante.DetalleComprobantes = dto.Items.Select(item => new AccesoDatos.DetalleComprobante
                {
                    Cantidad = item.Cantidad,
                    Codigo = item.CodigoProducto,
                    Descripcion = item.Descripcion,
                    ComprobanteId = dto.Id,
                    PrecioUnitario = item.PrecioUnitario,
                    SubTotal = item.SubTotal,
                    ArticuloId = item.ArticuloId

                }).ToList();
                context.SaveChanges();
            }
        }

        public DeliveryDto ObtenerPorId(long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                return context.Comprobantes.OfType<AccesoDatos.ComprobanteDelivery>().Select(x => new DeliveryDto
                {
                    Id = x.Id,
                    CadeteApellido = x.Cadete.Apellido,
                    CadeteId = x.CadeteId,
                    CadeteNombre = x.Cadete.Nombre,
                    Calle = x.Direccion.Calle,
                    ClienteApellido = x.Cliente.Apellido,
                    ClienteId = x.ClienteId,
                    ClienteNombre = x.Cliente.Nombre,
                    Descuento = x.Descuento,
                    Legajo = x.Cadete.Legajo,
                    TipoComprobante=x.TipoComprobante,
                    DireccionId = x.DireccionId,
                    Estado = x.EstadoPedido,
                    Fecha = x.Fecha,
                    Numero = x.Direccion.Numero,
                    NumeroComprobante = x.Numero,
                    TipoPedido = x.TipoPedido,
                    UsuarioId = x.UsuarioId,
                    Items = x.DetalleComprobantes.Where(y=> y.ComprobanteId==id).Select(y => new DetalleComprobanteDto
                    {
                        ArticuloId = y.ArticuloId,
                        Cantidad = y.Cantidad,
                        ComprobanteId = y.ComprobanteId,
                        CodigoProducto = y.Codigo,
                        Descripcion = y.Descripcion,
                        PrecioUnitario = y.PrecioUnitario
                    }).ToList()
                }).FirstOrDefault(x => x.Id == id);
               
            }
        }
    }
}
