namespace XCommerce.Servicio.Core.CuentaCorriente
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICuentaCorrienteServicio
    {
        long Agregar(long clienteId, decimal limite);
        void Modificar(CuentaCorrienteDto dto);
        void Eliminar(long ctaId);
        IEnumerable<CuentaCorrienteDto> Obtener(string cadena);
        CuentaCorrienteDto ObtenerCorrientePorClienteId(long ctaId);
        void Pagar(long clienteId, decimal monto);
        void Vender(long clienteId, decimal monto);
        bool TieneCuenta(long entidadIdValue);
        void ModificarPorId(CuentaCorrienteDto dto);
    }
}
