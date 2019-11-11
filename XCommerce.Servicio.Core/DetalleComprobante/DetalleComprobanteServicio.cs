namespace XCommerce.Servicio.Core.DetalleComprobante
{
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using CompranteMesa.DTOs;

    public class DetalleComprobanteServicio : IDetalleComprobanteServicio
    {
        public IEnumerable<DetalleComprobanteDto>Obtener (long comprobanteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.DetalleComprobantes.AsNoTracking()
                    .Where(x => x.ComprobanteId == comprobanteId && x.Cantidad>0).Select(x=>new DetalleComprobanteDto
                    {
                        ArticuloId = x.ArticuloId,
                        Descripcion = x.Descripcion,
                        PrecioUnitario = x.PrecioUnitario,
                        Cantidad = x.Cantidad,
                        CodigoProducto=x.Codigo
                    }).ToList();
            }
        }
    }
}
