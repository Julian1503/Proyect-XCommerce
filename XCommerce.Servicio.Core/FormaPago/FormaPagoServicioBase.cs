using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public class FormaPagoServicioBase : IFormaPagoServicio
    {

        public virtual long? Agregar(FormaPagoDto dto)
        {
            return 0;
        }

        public virtual void Eliminar(long id)
        {
           
        }

        public virtual void Modificar(FormaPagoDto dto)
        {
            
        }

        public virtual IEnumerable<FormaPagoDto> Obtener(string cadena)
        {
            return null;
        }

        public virtual FormaPagoDto ObtenerPorId(long id)
        {
            return null;
        }
    }
}
