namespace XCommerce.Servicio.Core.Localidad
{
    using System.Collections.Generic;
    using DTOs;

    public interface ILocalidadServicio
    {
        long Insertar(LocalidadDto dto);

        void Modificar(LocalidadDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<LocalidadDto> Obtener(string cadenaBuscar);

        IEnumerable<LocalidadDto> ObtenerPorProvincia(long provinciaId, string cadenaBuscar);

        LocalidadDto ObtenerPorId(long entidadId);
    }
}
