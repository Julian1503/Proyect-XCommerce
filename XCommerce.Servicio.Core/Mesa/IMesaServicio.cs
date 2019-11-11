namespace XCommerce.Servicio.Core.Mesa
{
    using System.Collections.Generic;
    using DTOs;

    public interface IMesaServicio
    {
        IEnumerable<MesaDto> Obtener(string cadenaBuscar);
        MesaDto ObtenerPorId(long? entidadId);
        long? Agregar(MesaDto mesa);
        void Modificar(MesaDto mesa);
        void Eliminar(long? entidadId);
        int ObtenerSiguienteNumero();
        IEnumerable<MesaDto> ObtenerPorSalon(long id, string cadena);
        IEnumerable<MesaDto> ObtenerSinReservas(long? mesaId = null);
    }
}
