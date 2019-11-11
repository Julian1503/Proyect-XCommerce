namespace XCommerce.Servicio.Core.CuentaCorriente
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class CuentaCorrienteServicio : ICuentaCorrienteServicio
    {
        public long Agregar(long clienteId, decimal limite)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaCuenta = new AccesoDatos.CuentaCorriente
                {
                    ClienteId = clienteId,
                    Limite = limite,
                    NumeroCuenta = CalcularNumeroCuenta(),
                    Saldo = 0
                };
                context.CuentaCorrienteSet.Add(nuevaCuenta);
                context.SaveChanges();
                return nuevaCuenta.Id;
            }
        }

        private int CalcularNumeroCuenta()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.CuentaCorrienteSet.Any())
                {
                    return context.CuentaCorrienteSet.Max(x => x.NumeroCuenta) + 1;
                }
                else
                {
                    return 1;
                }
            }

        }
    

        public void Eliminar(long ctaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cta = context.CuentaCorrienteSet.FirstOrDefault(x => x.ClienteId == ctaId);
                if (cta == null) throw new Exception("No se encontro la entidad");
                cta.EstaEliminada = true;
                context.SaveChanges();
            }
        }

        public void Modificar(CuentaCorrienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cta = context.CuentaCorrienteSet.FirstOrDefault(x => x.ClienteId == dto.Id);
                if (cta == null) throw new Exception("No se encontro la entidad");
                cta.ClienteId = dto.ClienteId;
                cta.Limite = dto.Limite;
                cta.NumeroCuenta = dto.NumeroCuenta;
                cta.Saldo = dto.Saldo;
                context.SaveChanges();

            }
        }
        public void ModificarPorId(CuentaCorrienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cta = context.CuentaCorrienteSet.FirstOrDefault(x => x.Id == dto.Id);
                if (cta == null) throw new Exception("No se encontro la entidad");
                cta.ClienteId = dto.ClienteId;
                cta.Limite = dto.Limite;
                cta.NumeroCuenta = dto.NumeroCuenta;
                cta.Saldo = dto.Saldo;
                context.SaveChanges();

            }
        }

        public IEnumerable<CuentaCorrienteDto> Obtener(string cadena)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CuentaCorrienteSet.AsNoTracking().Include(x=>x.Cliente).Where(x => x.Cliente.Dni != "99999999" && x.Cliente.MontoMaximoCtaCte>0).
                    Select(x =>
                    new CuentaCorrienteDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminada,
                        ClienteId = x.ClienteId,
                        Saldo = x.Saldo,
                        NombreCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y=>y.Id==x.ClienteId).Nombre,
                        ApellidoCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y => y.Id == x.ClienteId).Apellido,
                        DniCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y => y.Id == x.ClienteId).Dni,
                        NumeroCuenta = x.NumeroCuenta,
                        Limite = x.Limite
                    }).ToList();
            }
        }

        public CuentaCorrienteDto ObtenerCorrientePorClienteId(long ctaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CuentaCorrienteSet.AsNoTracking().Select(x =>
                    new CuentaCorrienteDto
                    {
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminada,
                        ClienteId = x.ClienteId,
                        Saldo = x.Saldo,
                        NombreCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y => y.Id == ctaId).Nombre,
                        ApellidoCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y => y.Id == ctaId).Apellido,
                        DniCliente = context.Personas.OfType<AccesoDatos.Cliente>().FirstOrDefault(y => y.Id == ctaId).Dni,
                        NumeroCuenta = x.NumeroCuenta,
                        Limite = x.Limite
                    }).FirstOrDefault(x=>x.ClienteId==ctaId);
            }
        }

        public void Pagar(long clienteId, decimal monto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cuenta = context.CuentaCorrienteSet.FirstOrDefault(x => x.ClienteId == clienteId);
                if (cuenta == null) throw new Exception("No se encontro la entidad");
                cuenta.Saldo -= monto;
                context.SaveChanges();
            }
       }
        //public void Comprar(long proveedorId, decimal monto)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var cuenta = context.CuentaCorrienteSet.FirstOrDefault(x => x.Cliente.Id == clienteId);
        //        if (cuenta == null) throw new Exception("No se encontro la entidad");
        //        cuenta.Saldo += monto;
        //        context.SaveChanges();
        //    }
        //}

        public void Vender(long clienteId, decimal monto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var cuenta = context.CuentaCorrienteSet.FirstOrDefault(x => x.Cliente.Id == clienteId);
                if (cuenta == null) throw new Exception("No se encontro la entidad");
                cuenta.Saldo += monto;
                context.SaveChanges();
            }
        }

        public bool TieneCuenta(long entidadIdValue)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.CuentaCorrienteSet.Any(x => x.ClienteId == entidadIdValue);
            }
        }
    }
}
