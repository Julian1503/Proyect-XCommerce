namespace XCommerce.Servicio.Core.BajaArticulo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using AccesoDatos;
    using DTOs;

    public class BajaArticuloServicio : IBajaArticuloServicio
    {
        public IEnumerable<BajaArticuloDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.BajaArticulos.Include(x => x.Articulo).Include(x => x.MotivoBaja)
                    .AsNoTracking()
                    .Where(x => x.Articulo.Descripcion.Contains(cadenaBuscar) || x.Observacion.Contains(cadenaBuscar))
                    .Select(x=> new BajaArticuloDto
                    {
                        Id = x.Id,
                        ArticuloId = x.ArticuloId,
                        Cantidad = x.Cantidad,
                        EstaEliminado = x.EstaEliminado,
                        Fecha = x.Fecha,
                        Articulo = x.Articulo.Descripcion,
                        Motivo = x.MotivoBaja.Descripcion,
                        MotivoBajaId = x.MotivoBajaId,
                        Observacion = x.Observacion
                    }).ToList();
            }
        }

        public BajaArticuloDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.BajaArticulos.Include(x => x.Articulo).Include(x => x.MotivoBaja).AsNoTracking()
                    .Select(x => new BajaArticuloDto
                    {
                        Id = x.Id,
                        ArticuloId = x.ArticuloId,
                        EstaEliminado = x.EstaEliminado,
                        Cantidad = x.Cantidad,
                        Fecha = x.Fecha,
                        Articulo = x.Articulo.Descripcion,
                        Motivo = x.MotivoBaja.Descripcion,
                        MotivoBajaId = x.MotivoBajaId,
                        Observacion = x.Observacion
                    }).FirstOrDefault(x => x.Id == entidadId);

            }
        }

        public long? Agregar(BajaArticuloDto baja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var BajaAgregar = new AccesoDatos.BajaArticulo();
                BajaAgregar.Id = baja.Id;
                BajaAgregar.ArticuloId = baja.ArticuloId;
                BajaAgregar.Cantidad = baja.Cantidad;
                BajaAgregar.Fecha = baja.Fecha;
                BajaAgregar.MotivoBajaId = baja.MotivoBajaId;
                BajaAgregar.Observacion = baja.Observacion;

                context.BajaArticulos.Add(BajaAgregar);
                var art = context.Articulos.FirstOrDefault(x => x.Id == BajaAgregar.ArticuloId);
                if (art.DescuentaStock)
                {
                    art.Stock -= BajaAgregar.Cantidad;

                }
                context.SaveChanges();
                return BajaAgregar.Id;
            }
        }

        public void Modificar(BajaArticuloDto baja)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var BajaModificar = context.BajaArticulos.Include(x => x.Articulo)
                    .FirstOrDefault(x => x.Id == baja.Id);
                BajaModificar.Id = baja.Id;
                BajaModificar.ArticuloId = baja.ArticuloId;
                BajaModificar.Fecha = baja.Fecha;
                BajaModificar.MotivoBajaId = baja.MotivoBajaId;
                BajaModificar.Observacion = baja.Observacion;
                var art = context.Articulos.FirstOrDefault(x => x.Id == BajaModificar.ArticuloId);
                if (art.DescuentaStock)
                {
                    if (baja.Cantidad > BajaModificar.Cantidad)
                    {
                        art.Stock -= (baja.Cantidad - BajaModificar.Cantidad);
                    }
                    else
                    {
                        art.Stock += (BajaModificar.Cantidad - baja.Cantidad);
                    }
                }

                BajaModificar.Cantidad = baja.Cantidad;
                context.SaveChanges();
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var BajaEliminar = context.BajaArticulos.FirstOrDefault(x => x.Id == entidadId);
                if (BajaEliminar == null) throw new Exception("Error no se encuentra la entidad");

                BajaEliminar.EstaEliminado = true;
                var art = context.Articulos.FirstOrDefault(x => x.Id == BajaEliminar.ArticuloId);
                art.Stock += BajaEliminar.Cantidad;
                context.SaveChanges();
            }
        }
    }
}
