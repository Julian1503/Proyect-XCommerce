namespace XCommerce.Servicio.Core.Tarjeta
{
    using System.Collections.Generic;
    using DTOs;

    public interface ITarjetaServicio
    {
        IEnumerable<TarjetaDto> Obtener(string cadenaBuscar);
        TarjetaDto ObtenerPorId(long? entidadId);
        long? Agregar(TarjetaDto tarjeta);
        void Modificar(TarjetaDto tarjeta);
        void Eliminar(long? entidadId);
    }
}
