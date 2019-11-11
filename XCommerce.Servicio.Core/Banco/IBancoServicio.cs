namespace XCommerce.Servicio.Core.Banco
{
    using System.Collections.Generic;
    using DTOs;

    public interface IBancoServicio
    {
        IEnumerable<BancoDto> Obtener(string cadenaBuscar);
        BancoDto ObtenerPorId(long? entidadId);
        long? Agregar(BancoDto banco);
        void Modificar(BancoDto banco);
        void Eliminar(long? entidadId);
    }
}
