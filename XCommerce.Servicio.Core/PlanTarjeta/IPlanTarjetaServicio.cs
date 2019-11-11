namespace XCommerce.Servicio.Core.PlanTarjeta
{
    using System.Collections.Generic;
    using DTOs;

    public interface IPlanTarjetaServicio
    {
        IEnumerable<PlanTarjetaDto> Obtener(string cadenaBuscar);
        PlanTarjetaDto ObtenerPorId(long? entidadId);
        long? Agregar(PlanTarjetaDto plan);
        void Modificar(PlanTarjetaDto plan);
        void Eliminar(long? entidadId);
    }
}
