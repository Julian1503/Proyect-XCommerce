using XCommerce.Servicio.Core.Persona.DTOs;

namespace XCommerce.Servicio.Core.Cliente.DTOs
{
    using System;
    using Base;

    public class ClienteDto : PersonaDto
    {
       
        public decimal Saldo { get; set; }
        
        public bool PermiteCtaCte => Sobregiro > 0 ? true : false;

        public decimal Sobregiro { get; set; }

    }
}
