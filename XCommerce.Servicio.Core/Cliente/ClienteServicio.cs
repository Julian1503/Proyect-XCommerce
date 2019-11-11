
namespace XCommerce.Servicio.Core.Cliente
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using CuentaCorriente;
    using DTOs;

    public class ClienteServicio : IClienteServicio
    {
        public void Eliminar(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var clienteEliminar = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == clienteId);

                if (clienteEliminar == null)
                    throw new Exception("No se encontro el Cliente");

                clienteEliminar.EstaEliminado = true;


                context.SaveChanges();
            }
        }

        public long Insertar(ClienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoCliente = new AccesoDatos.Cliente
                {
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Celular = dto.Celular,
                    Email = dto.Email,
                    Cuil = dto.Cuil,
                    FechaNacimiento = dto.FechaNacimiento,
                    Foto = dto.Foto,
                    MontoMaximoCtaCte = dto.Sobregiro,
                    Direccion = new Direccion
                    {
                        Calle = dto.Calle,
                        Numero = dto.Numero,
                        Piso = dto.Piso,
                        Dpto = dto.Dpto,
                        Casa = dto.Casa,
                        Lote = dto.Lote,
                        Barrio = dto.Barrio,
                        Mza = dto.Mza,
                        LocalidadId = dto.LocalidadId
                    }
                };


                context.Personas.Add(nuevoCliente);
                
                context.SaveChanges();
                if (nuevoCliente.MontoMaximoCtaCte > 0)
                {
                    CuentaCorrienteServicio cta = new CuentaCorrienteServicio();
                    cta.Agregar(nuevoCliente.Id, nuevoCliente.MontoMaximoCtaCte);
                }
                return nuevoCliente.Id;
            }
        }

        public void Modificar(ClienteDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var clienteModificar = context.Personas.OfType<AccesoDatos.Cliente>()
                    .Include(x => x.Direccion)
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (clienteModificar == null)
                    throw new Exception("No se encontro el Cliente");

                clienteModificar.Apellido = dto.Apellido;
                clienteModificar.Nombre = dto.Nombre;
                clienteModificar.Dni = dto.Dni;
                clienteModificar.Telefono = dto.Telefono;
                clienteModificar.Celular = dto.Celular;
                clienteModificar.Email = dto.Email;
                clienteModificar.Cuil = dto.Cuil;
                clienteModificar.FechaNacimiento = dto.FechaNacimiento;
                clienteModificar.Foto = dto.Foto;

                clienteModificar.Direccion.Calle = dto.Calle;
                clienteModificar.Direccion.Numero = dto.Numero;
                clienteModificar.Direccion.Piso = dto.Piso;
                clienteModificar.Direccion.Dpto = dto.Dpto;
                clienteModificar.Direccion.Casa = dto.Casa;
                clienteModificar.Direccion.Lote = dto.Lote;
                clienteModificar.Direccion.Barrio = dto.Barrio;
                clienteModificar.Direccion.Mza = dto.Mza;
                clienteModificar.Direccion.LocalidadId = dto.LocalidadId;

                CuentaCorrienteServicio cta = new CuentaCorrienteServicio();

                if (clienteModificar.MontoMaximoCtaCte == 0  && dto.Sobregiro > 0)
                {
                    cta.Agregar(clienteModificar.Id, dto.Sobregiro);
                }
                if (clienteModificar.MontoMaximoCtaCte > 0 && dto.Sobregiro == 0 )
                {
                    cta.Eliminar(clienteModificar.Id);
                }

                if (clienteModificar.MontoMaximoCtaCte > 0 && dto.Sobregiro > 0)
                {
                    var cuenta = cta.ObtenerCorrientePorClienteId(clienteModificar.Id);
                    cuenta.Limite = dto.Sobregiro;
                    cta.ModificarPorId(cuenta);
                }
                    clienteModificar.MontoMaximoCtaCte = dto.Sobregiro;
                context.SaveChanges();


            }
        }

        public IEnumerable<ClienteDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => (x.Nombre.Contains(cadenaBuscar)
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                || x.Email == cadenaBuscar) && !x.Dni.Equals("99999999") )
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        Sobregiro=x.MontoMaximoCtaCte,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).ToList();
            }
        }

        public ClienteDto ObtenerConsumidorFinal()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Sobregiro = x.MontoMaximoCtaCte,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Dni == "99999999");
            }
        }

        public IEnumerable<ClienteDto> ObtenerPorCtaCte(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Where(x => (x.Nombre.Contains(cadenaBuscar)
                                 || x.Apellido.Contains(cadenaBuscar)
                                 || x.Dni == cadenaBuscar
                                 || x.Email == cadenaBuscar) && !x.Dni.Equals("99999999") && x.MontoMaximoCtaCte>0)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        Sobregiro = x.MontoMaximoCtaCte,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }).ToList();
            }
        }

        public ClienteDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Include(x => x.Direccion)
                    .Include(x => x.Direccion.Localidad)
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        Sobregiro=x.MontoMaximoCtaCte,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Direccion.Calle,
                        Numero = x.Direccion.Numero,
                        Piso = x.Direccion.Piso,
                        Dpto = x.Direccion.Dpto,
                        Casa = x.Direccion.Casa,
                        Lote = x.Direccion.Lote,
                        Barrio = x.Direccion.Barrio,
                        Mza = x.Direccion.Mza,
                        LocalidadId = x.Direccion.LocalidadId,
                        ProvinciaId = x.Direccion.Localidad.ProvinciaId
                    }
                    ).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public decimal SaldoCtaCte(long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var saldo = context.Movimientos.Include(x => x.Comprobante).AsNoTracking()
                    .Where(x => x.Comprobante.ClienteId == clienteId && x.ComprobanteId==x.Comprobante.Id);
                if (saldo.Any(x=>x.Monto>0))
                {
                    return saldo.Sum(x => x.Monto); 
                }
                else
                {
                    return 0m;
                }
            }
        }
    }
}
