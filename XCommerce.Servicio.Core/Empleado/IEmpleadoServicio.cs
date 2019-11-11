
namespace XCommerce.Servicio.Core.Empleado
{
    using System.Collections.Generic;
    using DTOs;

    public interface IEmpleadoServicio
    {
        long Insertar(EmpleadoDto dto);

        void Modificar(EmpleadoDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar);
        EmpleadoDto ObtenerPorUsuarioId(long usuarioId);
        EmpleadoDto ObtenerPorId(long entidadId);
        IEnumerable<EmpleadoDto> ObtenerEmpleadosActuales(string cadenaBuscar,string categoria);

        int ObtenerSiguienteLegajo();
        EmpleadoDto ObtenerIdPorLegajo(string legajo,string categoria);
    }
}
