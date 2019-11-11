using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Articulo.DTOs;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.ComprobanteKiosco.DTOs;

namespace XCommerce.Servicio.Core.Kiosco
{
    public interface IKioscoServicio
    {
        long CerrarKiosco(ComprobanteKioscoDto kiosco, TipoComprobante tipo);
        void AgregarProducto(DetalleComprobanteDto _articulo, long articuloId);
        ComprobanteKioscoDto ObtenerComprobante(long comprobanteId);
    }
}