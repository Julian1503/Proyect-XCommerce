namespace XCommerce.Servicio.Core.Rubro
{
    using System.Collections.Generic;
    using DTOs;

    public interface IRubroServicio
    {
        long Insertar(RubroDto dto);

        void Modificar(RubroDto dto);

        void Eliminar(long? RubroId);

        //////////////////////////////////////

        IEnumerable<RubroDto> Obtener(string Nombre);

        RubroDto ObtenerPorId(long? EntidadId);

        
    }
}
