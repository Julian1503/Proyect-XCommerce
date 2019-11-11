namespace XCommerce.Servicio.Core.MotivoBaja
{
    using DTOs;
    using System.Collections.Generic;

    public interface IMotivoBajaServicio
    {
        IEnumerable<MotivoBajaDto> Obtener(string cadenaBuscar);

        MotivoBajaDto ObtenerPorId(long? entidadId);

        long? Agregar(MotivoBajaDto motivoBaja);

        void Eliminar(long? entidadId);

        void Modificar(MotivoBajaDto motivoBaja);
    }
}
