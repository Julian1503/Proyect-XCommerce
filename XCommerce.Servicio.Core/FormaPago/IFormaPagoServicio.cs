using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public interface IFormaPagoServicio
    {
        long? Agregar(FormaPagoDto dto);
        void Eliminar(long id);
        void Modificar(FormaPagoDto dto);
        IEnumerable<FormaPagoDto> Obtener(string cadena);
        FormaPagoDto ObtenerPorId(long id);
    }
}
