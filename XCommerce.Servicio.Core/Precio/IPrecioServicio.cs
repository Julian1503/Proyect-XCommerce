namespace XCommerce.Servicio.Core.Precio
{
    using System.Collections.Generic;
    using DTOs;

    public interface IPrecioServicio
    {
        IEnumerable<PrecioDto> Obtener(string cadenaBuscar);
        long Agregar(PrecioDto precioNuevo);
        PrecioDto Obtener(long mesaId,long id);

    }
}
