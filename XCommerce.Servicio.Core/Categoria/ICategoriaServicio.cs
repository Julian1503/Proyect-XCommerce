namespace XCommerce.Servicio.Core.Categoria
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICategoriaServicio
    {
        long Insertar(CategoriaDto dto);

        void Modificar(CategoriaDto dto);

        void Eliminar(long? CategoriaId);

        //////////////////////////////////////

        IEnumerable<CategoriaDto> Obtener(string Nombre);

        CategoriaDto ObtenerPorId(long? EntidadId);

    }
}
