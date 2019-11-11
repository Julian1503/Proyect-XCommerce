using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
   public class FormaPagoServicio :IFormaPago
   {
       private readonly Dictionary<Type, string> diccionario;
        public FormaPagoServicio()
        {
             diccionario = new Dictionary<Type, string>();
             Inicializar(ref diccionario);
        }

        private void Inicializar(ref Dictionary<Type, string> dictionary)
        {
            dictionary.Add(typeof(FormaPagoChequeDto), "XCommerce.Servicio.Core.FormaPago.FormaPagoServicioCheque");
            dictionary.Add(typeof(FormaPagoCtaCteDto), "XCommerce.Servicio.Core.FormaPago.FormaPagoServicioCtaCte");
            dictionary.Add(typeof(FormaPagoTarjetaDto), "XCommerce.Servicio.Core.FormaPago.FormaPagoServicioTarjeta");
            dictionary.Add(typeof(FormaPagoEfectivoDto), "XCommerce.Servicio.Core.FormaPago.FormaPagoServicioEfectivo");
        }

        public void AgregarAlDiccionario(Type clave, string llave)
        {
            diccionario.Add(clave,llave);
        }

        public long? Agregar(FormaPagoDto dto)
        {
                if (!diccionario.TryGetValue(dto.GetType(), out var pagos))
                    throw new Exception("Ocurrio un error grave");
                var objeto = InstanciarObj(pagos);
                return objeto.Agregar(dto);
        }

        private FormaPagoServicioBase InstanciarObj(string pagos)
        {
            var tipo = Type.GetType(pagos);
            if (tipo == null)
                throw new Exception("Ocurrio un error grave");
            var obj = Activator.CreateInstance(tipo) as FormaPagoServicioBase;
            return obj;
        }

        public void Eliminar(FormaPagoDto dto)
        {
            if (!diccionario.TryGetValue(dto.GetType(), out var pagos))
                throw new Exception("Ocurrio un error grave");
            var objeto = InstanciarObj(pagos);
            objeto.Eliminar(dto.Id);
        }

        public void Modificar(FormaPagoDto dto)
        {
            if (!diccionario.TryGetValue(dto.GetType(), out var pagos))
                throw new Exception("Ocurrio un error grave");
            var objeto = InstanciarObj(pagos);
            objeto.Modificar(dto);
        }
    }
}
