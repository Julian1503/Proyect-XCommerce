namespace XCommerce.Servicio.Core.Caja
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICajaServicio
    {
        long Abrir(CajaDto caja);

        void Cerrar(CajaDto caja);

        CajaDto ObtenerCajaAbierta();

        long UltimaCaja();

        IEnumerable<DetalleCajaDto> ObtenerPorDetallesId(long cajaId);
    }
}
