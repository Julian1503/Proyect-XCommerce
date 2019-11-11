using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace XCommerce.Servicio.Core.FormaPago
{
    public class FormaPagoServicioCheque : FormaPagoServicioBase
    {
        public override long? Agregar(FormaPagoDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var dtox = dto as FormaPagoChequeDto;
                var nuevo = new FormaPagoCheque()
                {
                    TipoFormaPago = dtox.TipoFormaPago,
                    Monto = dtox.Monto,
                    ComprobanteId = dtox.ComprobanteId,
                    BancoId = dtox.BancoId,
                    Dias = dtox.Dias,
                    EnteEmisor = dtox.EnteEmisor,
                    FechaEmision = dtox.FechaEmision,
                    Numero = dtox.Numero,
                    EstadoCheque = dtox.EstadoCheque
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
