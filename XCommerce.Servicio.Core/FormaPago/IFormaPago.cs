using System;
using System.Collections.Generic;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public interface IFormaPago
    {
        long? Agregar(FormaPagoDto dto);
        void Modificar(FormaPagoDto dto);
        void Eliminar(FormaPagoDto dto);
        void AgregarAlDiccionario(Type clave, string llave);
    }
}