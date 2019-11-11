using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.CompranteMesa;

namespace XCommerce.Servicio.Core.Operacion
{
    public class OperacionServicio :IOperacionServicio
    {
        public long Agregar(OperacionDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaOp = new AccesoDatos.Operacion();

                if (dto.TipoOperacion == TipoOperacion.Venta)
                {
                        nuevaOp.Comprobante = context.Comprobantes.OfType<ComprobanteSalon>().FirstOrDefault(x=>x.Id==dto.ComprobanteId);
                        nuevaOp.CuentaCorrienteId = dto.CuentaCorrienteId;
                        nuevaOp.Fecha = dto.Fecha;
                        nuevaOp.Monto = dto.Monto;
                        nuevaOp.TipoOperacion = TipoOperacion.Venta;
                        nuevaOp.SubSaldo = context.Operaciones.Any(x => x.CuentaCorrienteId == dto.CuentaCorrienteId)
                        ?
                        context.Operaciones.FirstOrDefault(x => x.Fecha == context.Operaciones.Max(y => y.Fecha)).SubSaldo + dto.Monto
                        : 
                        dto.Monto;
                }
                else
                {
                    nuevaOp.Fecha = dto.Fecha;
                    nuevaOp.Monto = dto.Monto;
                    nuevaOp.TipoOperacion = TipoOperacion.Cobranza;
                    nuevaOp.CuentaCorrienteId = dto.CuentaCorrienteId;
                    nuevaOp.SubSaldo = context.Operaciones.FirstOrDefault(x=>x.Fecha==context.Operaciones.Max(y=>y.Fecha)).SubSaldo - dto.Monto;
                }

                context.Operaciones.Add(nuevaOp);


                context.SaveChanges();
                return nuevaOp.Id;

            }
        }
        public IEnumerable<OperacionDto> Obtener(long Cta)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Operaciones.AsNoTracking().Where(x => x.CuentaCorrienteId == Cta)
                    .Select(x => new OperacionDto
                    {
                        Id = x. Id,
                        TipoOperacion = x.TipoOperacion,
                        CuentaCorrienteId = x.CuentaCorrienteId,
                        Fecha = x.Fecha,
                        ComprobanteId = x.Comprobante ==null? 0 : x.Comprobante.Id,
                        Monto = x.Monto,
                        Saldo = x.SubSaldo
                    }).ToList();
            }
        }

        public OperacionDto ObtenerPorId(long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Operaciones.AsNoTracking()
                    .Select(x => new OperacionDto
                    {
                        Id = x.Id,
                        TipoOperacion = x.TipoOperacion,
                        CuentaCorrienteId = x.CuentaCorrienteId,
                        Fecha = x.Fecha,
                        ComprobanteId = x.Comprobante == null ? 0 : x.Comprobante.Id,
                        Monto = x.Monto,
                        Saldo =x.SubSaldo
                    }).FirstOrDefault(x=>x.Id==id);
            }
        }
    }
}
