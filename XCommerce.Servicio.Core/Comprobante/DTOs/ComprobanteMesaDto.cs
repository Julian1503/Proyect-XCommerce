

namespace XCommerce.Servicio.Core.CompranteMesa.DTOs
{
using System;
using System.Collections.Generic;
using System.Linq;
using Base;
    public class ComprobanteMesaDto: ComprobanteBase
    {
        public long MesaId { get; set; }
        public long ComprobanteId { get; set; }
        public long? MozoId { get; set; }
        public int Comensal { get; set; }

        public int Legajo { get; set; }
        public string ApellidoMozo { get; set; }
        public string NombreMozo { get; set; }
        public string ApyNomMozo => $"{ApellidoMozo} {NombreMozo}";

        public string DniCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApyNomCl => $"{ApellidoCliente} {NombreCliente}";
        public string ContactoCliente => $"Apellido y Nombre : {ApellidoCliente} {NombreCliente}          DNI: {DniCliente}";



    }
}
