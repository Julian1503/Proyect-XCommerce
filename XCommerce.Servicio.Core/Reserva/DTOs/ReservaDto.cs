namespace XCommerce.Servicio.Core.Reserva.DTOs
{
    using System;
    using AccesoDatos;
    using Base;

    public class ReservaDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        
        public DateTime Tiempo { get; set; }

        public decimal Senia { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        public string EstadoReservaStr => EstadoReserva == EstadoReserva.Confirmada ? "Confirmada" :
            EstadoReserva == EstadoReserva.NoConfirmada ? "No Confirmada" : "Cancelada";

        public string ApellidoCliente { get; set; }

        public string NombreCliente { get; set; }

        public string ApyNom => $"{ApellidoCliente} {NombreCliente}";

        public string NumeroMesa { get; set; }

        public string Motivo { get; set; }

        public string Usuario { get; set; }

        public long MesaId { get; set; }

        public long ClienteId { get; set; }

        public long UsuarioId { get; set; }

        public long MotivoReservaId { get; set; }
    }
}
