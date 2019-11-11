using XCommerce.Servicio.Core.CompranteMesa.DTOs;

namespace XCommerce.Servicio.Core.Kiosco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using Comprobante;
    using ComprobanteKiosco.DTOs;
    using Movimiento;
    using Movimiento.DTOs;

    public class KioscoServicio : IKioscoServicio
    {

        public void GenerarDetalle(ComprobanteKioscoDto kiosco, ModeloXCommerceContainer context)
        {
            //TODO
            var nuevoDetalle = new AccesoDatos.DetalleCaja
            {
                CajaId = Entidad.Entidad.CajaId,
                Monto = kiosco.Total,
                TipoPago = TipoPago.Efectivo
            };
            context.DetalleCajas.Add(nuevoDetalle);
        }

        public long CerrarKiosco(ComprobanteKioscoDto kiosco,TipoComprobante tipo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                    //GENERO DETALLE DE CAJA
                var cfId = context.Personas.OfType<Cliente>().FirstOrDefault(x=>x.Dni=="99999999").Id;
                if (cfId == null) throw new Exception("Falta consumidor final");
                var comp = new ComprobanteFactura
                {
                    ClienteId = cfId,
                    Descuento = kiosco.Descuento,
                   Fecha = DateTime.Now,
                    Numero = NumeroDeComprobante.UltimoNumeroComprobante(),
                    TipoComprobante = tipo,
                    UsuarioId = Entidad.Entidad.UsuarioId,
                    SubTotal = kiosco.SubTotal,
                    Total = kiosco.Total,
                    DetalleComprobantes = new List<DetalleComprobante>()
                };
                context.Comprobantes.Add(comp);
                var list = new List<DetalleComprobante>();
                foreach (var items in kiosco.Items)
                {
                    var detComp = new DetalleComprobante
                    {

                        ComprobanteId = comp.Id,
                        SubTotal = items.SubTotal,
                        Codigo = items.CodigoProducto,
                        Cantidad = items.Cantidad,
                        PrecioUnitario = items.PrecioUnitario,
                        Descripcion = items.Descripcion,
                        ArticuloId = items.ArticuloId
                    };
                    list.Add(detComp);
                    context.DetalleComprobantes.Add(detComp);
                }
                comp.DetalleComprobantes = list;
                context.SaveChanges();
                //GENERAR MOVIMIENTO
                MovimientoServicio m = new MovimientoServicio();
                m.GenerarMovimiento(new MovimientoDto
                {
                    CajaId = Entidad.Entidad.CajaId,
                    ComprobanteId =comp.Id,
                    Fecha = DateTime.Now,
                    Monto = kiosco.Total,
                    TipoMovimento = TipoMovimiento.Ingreso,
                    UsuarioId = Entidad.Entidad.UsuarioId,
                    Descripcion = $"FC_{comp.TipoComprobante}_{comp.Numero.ToString("0000")}_{comp.Fecha.ToString("ddmmyyyy")}"
                });
                return comp.Id;
            }
        }

        public void AgregarProducto(DetalleComprobanteDto _articulo, long articuloId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                
                    var articulos = context.Articulos.FirstOrDefault(x => x.Id == articuloId);
                    if (articulos == null) throw new Exception("No se encontro la entidad");
                if (articulos.DescuentaStock)
                {
                    articulos.Stock -= _articulo.Cantidad;
                }
                context.SaveChanges();
            }
        }

        public ComprobanteKioscoDto ObtenerComprobante(long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                return context.Comprobantes.OfType<AccesoDatos.ComprobanteFactura>().Select(x => new ComprobanteKioscoDto
                {
                    Id = x.Id,
                    ClienteApellido = x.Cliente.Apellido,
                    ClienteId = x.ClienteId,
                    ClienteNombre = x.Cliente.Nombre,
                    Descuento = x.Descuento,
                    TipoComprobante = x.TipoComprobante,
                    Fecha = x.Fecha,
                    NumeroComprobante = x.Numero,
                    UsuarioId = x.UsuarioId,
                    Items = x.DetalleComprobantes.Where(y => y.ComprobanteId == comprobanteId).Select(y => new DetalleComprobanteDto
                    {
                        ArticuloId = y.ArticuloId,
                        Cantidad = y.Cantidad,
                        ComprobanteId = y.ComprobanteId,
                        CodigoProducto = y.Codigo,
                        Descripcion = y.Descripcion,
                        PrecioUnitario = y.PrecioUnitario
                    }).ToList()
                }).FirstOrDefault(x=>x.Id==comprobanteId);
            }
        }
    }
}
