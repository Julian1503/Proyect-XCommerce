using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Core.FormaPago
{
    public static class Vuelto
    {
        public static decimal CambiarVuelto(decimal total, decimal pago)
        {
            var vuelto = pago - total;
            if (vuelto >= 0)
                return vuelto;
            else
                return 0m;
        }
    }
}
