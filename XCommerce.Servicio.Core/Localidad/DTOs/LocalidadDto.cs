﻿namespace XCommerce.Servicio.Core.Localidad.DTOs
{
    using Base;
    public class LocalidadDto : BaseDto
    {
        public long ProvinciaId { get; set; }

        public string Descripcion { get; set; }

        public string Provincia { get; set; }

    }
}
