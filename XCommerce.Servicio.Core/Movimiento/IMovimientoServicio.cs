namespace XCommerce.Servicio.Core.Movimiento
{
    using DTOs;
    using System;
    using System.Collections.Generic;

    public interface IMovimientoServicio
    {
        void GenerarMovimiento(MovimientoDto movimiento);
        IEnumerable<MovimientoDto> Obtener(string cadena);
       IEnumerable<MovimientoDto> Obtener(DateTime fechaApertura, DateTime fechaCierre);
        bool HayMovimientos(DateTime p,DateTime u);
        int ObtenerVentasHoy();
        IEnumerable<MovimientoDto> ObtenerPorCaja(long cajaId);
    }
}
