
namespace XCommerce.Servicio.Core.CompranteMesa
{
using System.Collections.Generic;
using AccesoDatos;
using DTOs;
using XCommerce.Servicio.Core.Articulo.DTOs;
    public interface IComprobanteMesaServicio
    {
        //Acciones en el Comprobante
        void Abrir(long mesaId, long usuarioId, int comensales,long? mozoId = null);
        void Reservar(long mesaId, long usuarioId, long clienteId,decimal monto = 0, long? mozoId = null);
        void CancelarReserva(long mesaId);

        void CerrarMesa(ComprobanteMesaDto Comprobante, TipoComprobante tipoComprobante);
        void AgregarArticulo(long mesaId, ArticuloDto dto, decimal cantidad);
        void AgregarMozo(long mesaId, long mozo);
        void CancelarVenta(long mesaId);
        void AgregarAlComprobante(long mesaId, int numero, decimal descuento, decimal total);
        void EliminarProducto(long mesaId, ArticuloDto dto, decimal cantidad);
        bool ComprobantesCerrados();
        //Obtener
        ComprobanteMesaDto ObtenerComprobanteMesa(long mesaId);
        IEnumerable<ComprobanteMesaDto> ObtenerComprobanteMesaPorCliente(long clienteId);
        ComprobanteMesaDto ObtenerPorId(long id);
    }
}
