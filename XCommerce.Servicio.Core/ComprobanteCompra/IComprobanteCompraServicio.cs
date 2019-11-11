using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.ComprobanteCompra.DTOs;

namespace XCommerce.Servicio.Core.ComprobanteCompra
{
    public interface IComprobanteCompraServicio
    {
        long GenerarComprobanteCompra(ComprobanteCompraDto dto);
        void CerrarComprobanteCompra(ComprobanteCompraDto comprobante);
        IEnumerable<ComprobanteCompraDto> ObtenerComprobantesCompra(string empty);
        ComprobanteCompraDto ObtenerComprobantesCompraPorId(long comprobanteId);
    }
}
