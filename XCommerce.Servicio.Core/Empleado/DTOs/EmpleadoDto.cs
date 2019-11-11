using XCommerce.Servicio.Core.Persona.DTOs;

namespace XCommerce.Servicio.Core.Empleado.DTOs
{
    using System;
    using Base;

    public class EmpleadoDto : PersonaDto
    {
        public int Legajo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public long CategoriaId { get; set; }
        public int Pedidos { get; internal set; }
        public string CategoriaDescripcion { get; internal set; }
    }
}
