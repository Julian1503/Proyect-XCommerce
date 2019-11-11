namespace XCommerce.Servicio.Core.Proveedor
{
    using System.Collections.Generic;
    using DTOs;

    public interface IProveedorServicio
    {
        IEnumerable<ProveedorDto> ObtenerSinEliminados(string cadenaBuscar);
        IEnumerable<ProveedorDto> Obtener(string cadenaBuscar);
        ProveedorDto ObtenerPorId(long? entidadId);
        long? Agregar(ProveedorDto prove);
        void Modificar(ProveedorDto prove);
        void Eliminar(long? entidadId);
    }
}
