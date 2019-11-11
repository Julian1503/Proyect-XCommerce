using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Configuracion.DTOs
{
   public class ConfiguracionDto : BaseDto
    {
        public long? ListaDeliveryId { get; set; }
        public string ListaDeliveryDescripcion { get; set; }
        public string ListaKioscoDescripcion { get; set; }
        public long? ListaKioscoId { get; set; }
        public string CategoriaMozoDescripcion { get; set; }
        public long? MozoId { get; set; }
        public string CategoriaCadeteDescripcion { get; set; }
        public long? CadeteId { get; set; }
    }
}
