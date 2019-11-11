namespace XCommerce.Servicio.Core.DetalleComprobante
{
    using System.Collections.Generic;
    using CompranteMesa.DTOs;

    public interface IDetalleComprobanteServicio
   {
       IEnumerable<DetalleComprobanteDto> Obtener(long comprobanteId);
   }
}
