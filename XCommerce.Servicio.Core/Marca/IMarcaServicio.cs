namespace XCommerce.Servicio.Core.Marca
{
    using DTOs;
    using System.Collections.Generic;

    public interface IMarcaServicio
    {
        long Insertar(MarcaDto dto);

        void Modificar(MarcaDto dto);

        void Eliminar(long? RubroId);

        //////////////////////////////////////

        IEnumerable<MarcaDto> Obtener(string Nombre);

        MarcaDto ObtenerPorId(long? EntidadId);
    }
}
