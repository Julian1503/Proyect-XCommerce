using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Configuracion.DTOs;

namespace XCommerce.Servicio.Core.Configuracion
{
    public interface IConfiguracionServicio
    {
        long Agregar(ConfiguracionDto dto);
        void Modificar(ConfiguracionDto dto);
        ConfiguracionDto Obtener();
    }
}
