namespace XCommerce.Servicio.Core.Articulo
{
    using System.Collections.Generic;
    using DTOs;

    public interface IArticuloServicio
    {
        IEnumerable<ArticuloDto> Obtener(string cadenaBuscar);

        ArticuloDto ObtenerPorId(long? entidadId);

        ArticuloDto ObtenerPorCodigo(long? mesaId, string codigo);

        IEnumerable<ArticuloDto>ObtenerProducto(string codigo,long listaId);

        ArticuloDto ObtenerProductoPorCodigo(string codigo, long listaId);

        IEnumerable<ArticuloDto> ObtenerSinEliminados(string cadenaBuscar,long mesaId);

        IEnumerable<ArticuloDto> ReporteReponerStock();


        string SiguienteCodigoArticulo();

        long? Agregar(ArticuloDto articulo);

        void  Modificar(ArticuloDto articulo);

        void Eliminar(long? entidadId);

    }
}
