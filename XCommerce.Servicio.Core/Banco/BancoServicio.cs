namespace XCommerce.Servicio.Core.Banco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class BancoServicio : IBancoServicio
    {
        public long? Agregar(BancoDto banco)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var bancoNuevo = new AccesoDatos.Banco
                {
                    Descripcion = banco.Descripcion,
                    EstaEliminado = banco.EstaEliminado
                };
                context.Bancos.Add(bancoNuevo);
                context.SaveChanges();
                return bancoNuevo.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var banco = context.Bancos.FirstOrDefault(x => x.Id == entidadId);
                if (banco == null) throw new Exception("Error no se encuentra la entidad");
                banco.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(BancoDto banco)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var bancoMod = context.Bancos.FirstOrDefault(x => x.Id == banco.Id);
                if (bancoMod == null) throw new Exception("Error no se encuentra la entidad");
                bancoMod.Id = banco.Id;
                bancoMod.EstaEliminado = banco.EstaEliminado;
                bancoMod.Descripcion = banco.Descripcion;
                context.SaveChanges();
            }
        }

        public IEnumerable<BancoDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Bancos.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar)).Select(x =>
                    new BancoDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public BancoDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Bancos.AsNoTracking().Select(x => new BancoDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaEliminado = x.EstaEliminado
                }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }

}
