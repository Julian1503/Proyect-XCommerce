namespace XCommerce.Servicio.Core.BajaArticulo
{
    using System.Collections.Generic;
    using DTOs;

    public interface IBajaArticuloServicio
    {
        IEnumerable<BajaArticuloDto> Obtener(string cadenaBuscar);
        BajaArticuloDto ObtenerPorId(long? entidadId);
        long? Agregar(BajaArticuloDto baja);
        void Modificar(BajaArticuloDto baja);
        void Eliminar(long? entidadId);

    }
}
