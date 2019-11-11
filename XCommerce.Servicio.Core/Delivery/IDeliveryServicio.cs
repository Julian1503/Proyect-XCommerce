using System.Collections.Generic;
using XCommerce.Servicio.Core.Delivery.DTOs;

namespace XCommerce.Servicio.Core.Delivery
{
    public interface IDeliveryServicio
    {
        void GenerarComprobante(DeliveryDto dto);
        void Enviar(long comprobanteId);
        void Cancelar(long comprobanteId);
        IEnumerable<DeliveryDto> ObtenerPorDia();
        IEnumerable<DeliveryDto> ObtenerTodos(string cadena);
        void EditarComprobante(DeliveryDto dto);
        void Entregar(DeliveryDto comprobante);
        DeliveryDto ObtenerPorId(long id);
    }
}
