namespace XCommerce.Servicio.Core.Salon
{
    using System.Collections.Generic;
    using DTOs;

    public interface ISalonServicio
    {
        IEnumerable<SalonDto> Obtener(string cadenaBuscar);
        SalonDto ObtenerPorId(long? entidadId);
        long? Agregar(SalonDto salon);
        void Modificar(SalonDto salon);
        void Eliminar(long? entidadId);
    }
}
