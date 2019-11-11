namespace XCommerce.Servicio.Core.Reserva
{
    using System.Collections.Generic;
    using DTOs;

    public interface IReservaServicio
    {
        long Agregar(ReservaDto dto);

        void Modificar(ReservaDto dto);

        void Eliminar(long entidadId);

        IEnumerable<ReservaDto> Obtener(string cadenaBuscar);

        ReservaDto ObtenerPorId(long entidadId);
    }
}
