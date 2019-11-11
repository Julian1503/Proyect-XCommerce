namespace XCommerce.Servicio.Core.Caja.DTOs
{
    using System;

    public class CajaDto
    {
        public long Id { get; set; }
        public decimal MontoApertura { get; set; }
        public DateTime FechaApertura { get; set; }
        public long UsuarioAperturaId { get; set; }

        public DateTime FechaCierre { get; set; }
        public decimal MontoCierre { get; set; }
        public decimal MontoSistema { get; set; }
        public decimal Diferencia =>  MontoSistema- MontoCierre;
        public long UsuarioCierreId { get; set; }

    }
}
