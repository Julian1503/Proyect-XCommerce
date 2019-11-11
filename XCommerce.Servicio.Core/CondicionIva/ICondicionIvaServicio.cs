
namespace XCommerce.Servicio.Core.CondicionIva
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICondicionIvaServicio
    {
        IEnumerable<CondicionIvaDto> Obtener(string cadenaBuscar);
        CondicionIvaDto ObtenerPorId(long? entidadId);
        long? Agregar(CondicionIvaDto Ci);
        void Modificar(CondicionIvaDto Ci);
        void Eliminar(long? entidadId);
    }
}
