namespace XCommerce.Servicio.Core.Provincia
{
    using System.Collections.Generic;
    using DTOs;

    public interface IProvinciaServicio
    {
        long Insertar(ProvinciaDto dto);

        void Modificar(ProvinciaDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar);

        ProvinciaDto ObtenerPorId(long entidadId);
    }
}
