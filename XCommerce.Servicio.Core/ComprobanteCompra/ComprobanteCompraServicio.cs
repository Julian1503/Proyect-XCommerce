using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.Comprobante;
using XCommerce.Servicio.Core.ComprobanteCompra.DTOs;
using XCommerce.Servicio.Core.CuentaCorriente;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.Movimiento.DTOs;
using XCommerce.Servicio.Core.Operacion;

namespace XCommerce.Servicio.Core.ComprobanteCompra
{
    public class ComprobanteCompraServicio : IComprobanteCompraServicio
    {
        public void CerrarComprobanteCompra(ComprobanteCompraDto comprobante)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                ArticuloServicio art = new ArticuloServicio();
                //DetalleComprobante
                var Comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteCompra>().FirstOrDefault(x => x.Id == comprobante.Id);
                Comprobante.TipoComprobante = comprobante.TipoComprobante;
                foreach (var item in comprobante.Items)
                {
                    var articulo = art.ObtenerPorId(item.ArticuloId);
                    articulo.Stock += item.Cantidad;
                    art.Modificar(articulo);
                }
                Comprobante.DetalleComprobantes = comprobante.Items.Select(x => new AccesoDatos.DetalleComprobante
                {
                    ArticuloId = x.ArticuloId,
                    Cantidad = x.Cantidad,
                    ComprobanteId = comprobante.Id,
                    PrecioUnitario = x.PrecioUnitario,
                    SubTotal = x.SubTotal,
                    Descripcion = x.Descripcion,
                    Codigo = x.CodigoProducto
                }).ToList();
                context.SaveChanges();
                //Movimiento
                MovimientoServicio m = new MovimientoServicio();
                FormaPagoServicio fp = new FormaPagoServicio();

                if (comprobante.MontoEfectivo > 0)
                {
                    //GENERAR MOVIMIENTO
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = Comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoEfectivo,
                        TipoMovimento = TipoMovimiento.Egreso,
                        Descripcion = $"FC_{Comprobante.TipoComprobante}_{Comprobante.Numero.ToString("0000")}_{Comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                //if (dto.MontoCtaCte > 0)
                //{
                //    //CUENTA CORRIENTE NO GENERA DETALLE DE CAJA AL INSTANTE(DEBE PAGAR PARA GENERARLO)
                //    CuentaCorrienteServicio cta = new CuentaCorrienteServicio();
                //    cta.Vender(comprobante.ClienteId, comprobante.Total);
                //    OperacionServicio op = new OperacionServicio();
                //    op.Agregar(new OperacionDto
                //    {
                //        TipoOperacion = TipoOperacion.Venta,
                //        ComprobanteId = comprobante.Id,
                //        Fecha = DateTime.Now,
                //        Monto = dto.MontoCtaCte,
                //        CuentaCorrienteId = cta.ObtenerCorrientePorClienteId(comprobante.ClienteId).Id
                //    });
                //    //GENERAR MOVIMIENTO
                //    m.GenerarMovimiento(new MovimientoDto
                //    {
                //        CajaId = Entidad.Entidad.CajaId,
                //        ComprobanteId = comprobante.Id,
                //        Fecha = DateTime.Now,
                //        Monto = dto.MontoCtaCte,
                //        TipoMovimento = TipoMovimiento.Egreso,
                //        Descripcion = $"CC_{comprobante.TipoComprobante}_{comprobante.Numero.ToString("0000")}_{comprobante.Fecha.ToString("ddmmyyyy")}",
                //        UsuarioId = Entidad.Entidad.UsuarioId
                //    });
                //}

                if (comprobante.MontoTarjeta > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = Comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoTarjeta,
                        TipoMovimento = TipoMovimiento.Egreso,
                        Descripcion = $"TC_{Comprobante.TipoComprobante}_{Comprobante.Numero.ToString("0000")}_{Comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }

                if (comprobante.MontoCheque > 0)
                {
                    m.GenerarMovimiento(new MovimientoDto
                    {
                        CajaId = Entidad.Entidad.CajaId,
                        ComprobanteId = Comprobante.Id,
                        Fecha = DateTime.Now,
                        Monto = comprobante.MontoCheque,
                        TipoMovimento = TipoMovimiento.Egreso,
                        Descripcion = $"CH_{Comprobante.TipoComprobante}_{Comprobante.Numero.ToString("0000")}_{Comprobante.Fecha.ToString("ddmmyyyy")}",
                        UsuarioId = Entidad.Entidad.UsuarioId
                    });
                }
            }
        }

        public long GenerarComprobanteCompra(ComprobanteCompraDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                
                //Comprobante
                var cliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(x =>
                  x.Dni == "99999999");
                if (cliente == null) throw new Exception("no se encontro la entidad");

                var comprobante = new AccesoDatos.ComprobanteCompra
                {
                    Fecha = DateTime.Now,
                    Numero = NumeroDeComprobante.UltimoNumeroComprobante(),
                    ProveedorId = dto.ProveedorId,
                    Total = dto.Total,
                    SubTotal = dto.SubTotal,
                    TipoComprobante = TipoComprobante.X,
                    ClienteId = cliente.Id,
                    Descuento = dto.Descuento,
                    UsuarioId = Entidad.Entidad.UsuarioId,
                    DetalleComprobantes = new List<AccesoDatos.DetalleComprobante>()
                  };
                context.Comprobantes.Add(comprobante);
                context.SaveChanges();
                return comprobante.Id;
            }
        }



        public IEnumerable<ComprobanteCompraDto> ObtenerComprobantesCompra(string empty)
        {
          using(var context= new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.ComprobanteCompra>().Where(x => x.Fecha.ToString().Contains(empty)).Select(x => new ComprobanteCompraDto
                {
                    Id=x.Id,
                    Fecha=x.Fecha,
                    ClienteId=x.ClienteId,
                    Descuento=x.Descuento,
                    TipoComprobante =x.TipoComprobante,
                    Items=x.DetalleComprobantes.Select(y=>new CompranteMesa.DTOs.DetalleComprobanteDto
                    {
                        ArticuloId=y.ArticuloId,
                        Cantidad= y.Cantidad,
                        CodigoProducto=y.Codigo,
                        Descripcion = y.Descripcion,
                        PrecioUnitario = y.PrecioUnitario
                    }).ToList(),
                    NumeroComprobante = x.Numero,
                     ProveedorId=x.ProveedorId,
                     ProveedorRazonSocial = context.Proveedores.FirstOrDefault(t=>t.Id==x.ProveedorId).RazonSocial,
                     UsuarioId=x.UsuarioId,
                    
                }).OrderBy(x=>x.Fecha).ToList();
            }
        }

        public ComprobanteCompraDto ObtenerComprobantesCompraPorId(long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.ComprobanteCompra>().Select(x => new ComprobanteCompraDto
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    ClienteId = x.ClienteId,
                    TipoComprobante =x.TipoComprobante,
                    Descuento = x.Descuento,
                    Items = x.DetalleComprobantes.Select(d => new DetalleComprobanteDto
                    {
                        ArticuloId = d.ArticuloId,
                        Descripcion = d.Descripcion,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        CodigoProducto = d.Codigo,
                    }).ToList(),
                    NumeroComprobante = x.Numero,
                    ProveedorId = x.ProveedorId,
                    ProveedorRazonSocial = context.Proveedores.FirstOrDefault(t => t.Id == x.ProveedorId).RazonSocial,
                    UsuarioId = x.UsuarioId
                }).OrderBy(x => x.Fecha).FirstOrDefault(x=>x.Id == comprobanteId);
            }
        }
    }
}
