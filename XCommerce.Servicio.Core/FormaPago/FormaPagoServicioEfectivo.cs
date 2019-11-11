using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public class FormaPagoServicioEfectivo : FormaPagoServicioBase
    {
        public override long? Agregar(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevo = new FormaPagoEfectivo
                {
                    TipoFormaPago = dto.TipoFormaPago,
                    Monto = dto.Monto,
                    ComprobanteId = dto.ComprobanteId
                };
                context.FormasPagos.Add(nuevo);
                context.SaveChanges();
                return nuevo.Id;
            }
        }

        public override void Modificar(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {

            }
        }

        public override void Eliminar(long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {

            }
        }
    }
}
