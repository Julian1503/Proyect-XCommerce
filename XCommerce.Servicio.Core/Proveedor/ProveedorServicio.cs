namespace XCommerce.Servicio.Core.Proveedor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class ProveedorServicio : IProveedorServicio
    {
        public long? Agregar(ProveedorDto prove)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var proveedorNuevo = new AccesoDatos.Proveedor
                {
                    CondicionIvaId = prove.CondicionIvaId,
                    Contacto = prove.Contacto,
                    Email = prove.Email,
                    RazonSocial = prove.RazonSocial,
                    Telefono = prove.Telefono
                };
                context.Proveedores.Add(proveedorNuevo);
                context.SaveChanges();
                return proveedorNuevo.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var proveedorElim = context.Proveedores.FirstOrDefault(x => x.Id == entidadId);
                if (proveedorElim == null) throw new Exception("No se encontro el Proveedor");
                proveedorElim.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(ProveedorDto prove)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var proveedorMod = context.Proveedores.FirstOrDefault(x => x.Id == prove.Id);
                if (proveedorMod == null) throw new Exception("No se encontro el Proveedor");
                proveedorMod.Id=prove.Id;
                proveedorMod.CondicionIvaId = prove.CondicionIvaId;
                proveedorMod.Contacto = prove.Contacto;
                proveedorMod.Email = prove.Email;
                proveedorMod.RazonSocial = prove.RazonSocial;
                proveedorMod.Telefono = prove.Telefono;

                context.SaveChanges();
            }
        }

        public IEnumerable<ProveedorDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Proveedores.AsNoTracking().Where(x => x.RazonSocial.Contains(cadenaBuscar)).Select(x =>
                    new ProveedorDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado,
                        Telefono = x.Telefono,
                        RazonSocial = x.RazonSocial,
                        CondicionIvaId = x.CondicionIvaId,
                        Email = x.Email,
                        Contacto = x.Contacto
                    }).ToList();
            }
        }

        public IEnumerable<ProveedorDto> ObtenerSinEliminados(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Proveedores.AsNoTracking().Where(x => x.RazonSocial.Contains(cadenaBuscar)).Select(x =>
                    new ProveedorDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado,
                        Telefono = x.Telefono,
                        RazonSocial = x.RazonSocial,
                        CondicionIvaId = x.CondicionIvaId,
                        Email = x.Email,
                        Contacto = x.Contacto
                    }).ToList();
            }
        }

        public ProveedorDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Proveedores.AsNoTracking().Select(x =>
                    new ProveedorDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado,
                        Telefono = x.Telefono,
                        RazonSocial = x.RazonSocial,
                        CondicionIvaId = x.CondicionIvaId,
                        Email = x.Email,
                        Contacto = x.Contacto
                    }).FirstOrDefault(x=>x.Id==entidadId);
            }
        }
    }
}
