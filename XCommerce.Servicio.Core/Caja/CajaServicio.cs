using XCommerce.Servicio.Core.DetalleCaja;

namespace XCommerce.Servicio.Core.Caja
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class CajaServicio : ICajaServicio
    {
       
        public long Abrir(CajaDto caja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                //SI ES QUE EL MONTO CIERRE , MONTO APERTURA SON IGUALES
                //Y EL MONTO = 0 SIGNIFICA QUE TENGO UNA CAJA ABIERTA 
                if (context.Cajas.Any
                    (x => x.MontoCierre == 0 && x.FechaCierre == x.FechaApertura)) throw new Exception("No puede haber dos cajas abiertas");
                    var cajita = new AccesoDatos.Caja
                    {
                        UsuarioAperturaId = caja.UsuarioAperturaId,
                        MontoSistema = 0,
                        MontoApertura = caja.MontoApertura,
                        FechaApertura = DateTime.Now,
                        Diferencia = 0,
                        FechaCierre = DateTime.Now,
                        UsuarioCierreId = caja.UsuarioAperturaId,
                        MontoCierre = caja.MontoApertura
                    };
                    context.Cajas.Add(cajita);
                    context.SaveChanges();

                //RETORNO EL ID DE LA NUEVA APERTURA DE CAJA
                return cajita.Id;
            }
        }
        public void Cerrar(CajaDto caja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                //TRAIGO LA CAJA ABIERTA
                var cajaCerrar = context.Cajas.FirstOrDefault(x => x.FechaCierre == x.FechaApertura);
                if(cajaCerrar==null) throw new Exception("No se encontro la entidad");
                //RELLENO LOS DATOS DE CIERRE

                cajaCerrar.FechaCierre = DateTime.Now;
                cajaCerrar.UsuarioCierreId = caja.UsuarioCierreId;
                cajaCerrar.MontoCierre = caja.MontoCierre;
                cajaCerrar.Diferencia = caja.Diferencia;
                cajaCerrar.MontoSistema = caja.MontoSistema;
                context.SaveChanges();
            }
        }

        public bool EstadoCaja()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.Any(x => x.MontoCierre == x.MontoApertura && x.FechaCierre == x.FechaApertura);
            }
            
        }

        public CajaDto ObtenerCajaAbierta()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Cajas.Select(x=>new CajaDto
                {
                    FechaApertura = x.FechaApertura,
                    FechaCierre = x.FechaCierre,
                    MontoApertura = x.MontoApertura,
                    MontoCierre = x.MontoCierre,
                    UsuarioAperturaId = x.UsuarioAperturaId,
                    UsuarioCierreId = x.UsuarioCierreId
                }).FirstOrDefault(x => x.FechaApertura == x.FechaCierre);
            }
        }


        public long UltimaCaja()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                //RETORNA LA ID DE LA ULTIMA CAJA
                if (context.Cajas.Any())
                {
                    return context.Cajas.Max(x => x.Id);
                }
                else
                {
                    return 1;
                }
            }
        }

        public IEnumerable<DetalleCajaDto> ObtenerPorDetallesId(long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.DetalleCajas.Where(x => x.CajaId == cajaId).Select(x=>new DetalleCajaDto
                {
                    Monto = x.Monto,
                    TipoPago = x.TipoPago
                }).ToList();
            }
        }
    }
}
