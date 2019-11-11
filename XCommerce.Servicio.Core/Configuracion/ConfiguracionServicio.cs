using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Configuracion.DTOs;
using System.Linq;

namespace XCommerce.Servicio.Core.Configuracion
{
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        //TODO
        public long Agregar(ConfiguracionDto dto)
        {
            using(var context = new ModeloXCommerceContainer())
            {
                var configuracionNueva = new AccesoDatos.Configuracion();
                configuracionNueva.ListaDeliveryId = dto.ListaDeliveryId;
                configuracionNueva.ListaKioscoId = dto.ListaKioscoId;
                configuracionNueva.CadeteId = dto.CadeteId;
                configuracionNueva.MozoId = dto.MozoId;
                context.Configuraciones.Add(configuracionNueva);
                context.SaveChanges();
                return configuracionNueva.Id;
            }
        }

        public void Modificar(ConfiguracionDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var configuracionModificacion =  context.Configuraciones.FirstOrDefault(x => x.Id == dto.Id);
                configuracionModificacion.ListaDeliveryId = dto.ListaDeliveryId;
                configuracionModificacion.ListaKioscoId = dto.ListaKioscoId;
                configuracionModificacion.CadeteId = dto.CadeteId;
                configuracionModificacion.MozoId = dto.MozoId;
                context.SaveChanges();
            }
        }

        public ConfiguracionDto Obtener()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Configuraciones.
                    Select(x=>new ConfiguracionDto
                    {
                        Id=x.Id,
                        ListaDeliveryDescripcion=x.ListaPrecioDelivery.Descripcion,
                        ListaDeliveryId= x.ListaDeliveryId,
                        ListaKioscoDescripcion=x.ListaPrecioKiosco.Descripcion,
                        ListaKioscoId = x.ListaKioscoId,
                        MozoId=x.MozoId,
                        CadeteId = x.CadeteId,
                        CategoriaMozoDescripcion = x.CategoriaMozo.Descripcion,
                        CategoriaCadeteDescripcion=x.CategoriaCadete.Descripcion
                    }).FirstOrDefault();
            }
        }
    }
}
