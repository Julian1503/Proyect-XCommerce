namespace XCommerce.Servicio.Core.ListaPrecio
{
    using System.Collections.Generic;
    using DTOs;

    public interface IListaPreciosServicio
    {
        long Agregar(ListaPreciosDto dto);

        void Modificar(ListaPreciosDto dto);

        void Eliminar(long? entidadId);

        IEnumerable<ListaPreciosDto> Obtener(string cadenaBuscar);

        ListaPreciosDto ObtenerPorId(long? entidadId);
        bool HayListas();
    }
}
