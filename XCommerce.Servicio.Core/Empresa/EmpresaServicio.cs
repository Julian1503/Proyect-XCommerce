namespace XCommerce.Servicio.Core.Empresa
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class EmpresaServicio : IEmpresaServicio
    {
        public long? Agregar(EmpresaDto empresa)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empresaNueva = new AccesoDatos.Empresa
                {
                    
                    CondicionIvaId = empresa.CondicionIvaId,
                    Cuit = empresa.Cuit,
                    Logo = empresa.Logo,
                    Mail = empresa.Mail,
                    ProductoBruto ="",
                    NombreFantasia = empresa.NombreFantasia,
                    RazonSocial = empresa.RazonSocial,
                    Sucursal = empresa.Sucursal,
                    Telefono = empresa.Telefono,
                    Direccion = new Direccion
                    {
                        Calle = empresa.Calle,
                        Numero = empresa.Numero,
                        Piso = empresa.Piso,
                        Dpto = empresa.Dpto,
                        Casa = empresa.Casa,
                        Lote = empresa.Lote,
                        Barrio = empresa.Barrio,
                        Mza = empresa.Mza,
                        LocalidadId = empresa.LocalidadId
                    
                    }
                };
                context.Empresas.Add(empresaNueva);
            
                context.SaveChanges();
               
                return empresaNueva.Id;
            }
        }

        public bool HayDatos()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Empresas.Any();
            }
        }

        public void Modificar(EmpresaDto empresa)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empresaMod = context.Empresas.FirstOrDefault();
                if (empresaMod == null) throw new Exception("Error no se encuentra la entidad");
                empresaMod.CondicionIvaId = empresa.CondicionIvaId;
                empresaMod.Cuit = empresa.Cuit;
                empresaMod.Logo = empresa.Logo;
                empresaMod.Mail = empresa.Mail;
                empresaMod.NombreFantasia = empresa.NombreFantasia;
                empresaMod.RazonSocial = empresa.RazonSocial;
                empresaMod.Sucursal = empresa.Sucursal;
                empresaMod.Telefono = empresa.Telefono;
                empresaMod.Direccion = new Direccion
                {
                    Calle = empresa.Calle,
                    Numero = empresa.Numero,
                    Piso = empresa.Piso,
                    Dpto = empresa.Dpto,
                    Casa = empresa.Casa,
                    Lote = empresa.Lote,
                    Barrio = empresa.Barrio,
                    Mza = empresa.Mza,
                    LocalidadId = empresa.LocalidadId
                };
                context.SaveChanges();
            };
        }

        public EmpresaDto Obtener()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.
                    Empresas.
                    Include(x => x.Direccion).
                    Include(x => x.Direccion.Localidad).
                    AsNoTracking().Select(x => new EmpresaDto
                    {
                        Id = x.Id,
                        Numero = x.Direccion.Numero,
                        CondicionIvaId = x.CondicionIvaId,
                        CondicionIvaIdDescripcion = x.CondicionIva.Descripcion,
                    Telefono = x.Telefono,
                    RazonSocial = x.RazonSocial,
                    Mail = x.Mail,
                    Sucursal = x.Sucursal,
                    Cuit = x.Cuit,
                    Logo = x.Logo,
                    NombreFantasia = x.NombreFantasia,
                    Barrio = x.Direccion.Barrio,
                    Calle = x.Direccion.Calle,
                    Casa = x.Direccion.Casa,
                    Dpto = x.Direccion.Dpto,
                    LocalidadId = x.Direccion.LocalidadId,
                    Lote = x.Direccion.Lote,
                    Mza = x.Direccion.Mza,
                    Piso = x.Direccion.Piso,
                    ProvinciaId = x.Direccion.Localidad.ProvinciaId
                }).FirstOrDefault();
            }
        }
    }
}