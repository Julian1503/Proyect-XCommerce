using System.Collections.Generic;

namespace XCommerce.Servicio.Core.Operacion
{
    public interface IOperacionServicio
    {
        long Agregar(OperacionDto dto);
      //  void Modificar(OperacionDto dto);
        IEnumerable<OperacionDto> Obtener(long Cta);
        OperacionDto ObtenerPorId(long id);
    }
}
