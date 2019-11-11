
namespace XCommerce.Servicio.Core.Cliente
{
using System.Collections.Generic;
using DTOs;

    public interface IClienteServicio
    {
        long Insertar(ClienteDto dto);

        void Modificar(ClienteDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<ClienteDto> Obtener(string cadenaBuscar);

        IEnumerable<ClienteDto> ObtenerPorCtaCte(string cadenaBuscar);

        decimal SaldoCtaCte(long clienteId);

        ClienteDto ObtenerPorId(long entidadId);
        ClienteDto ObtenerConsumidorFinal();
    }
}
