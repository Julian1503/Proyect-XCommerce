namespace XCommerce.Servicio.Core.Precio
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class PrecioServicio : IPrecioServicio
    {
        public long Agregar(PrecioDto precioNuevo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoPrecio = new AccesoDatos.Precio
                {
                    PrecioCosto = precioNuevo.PrecioCosto,
                    ActivarHoraVenta = precioNuevo.ActivarHoraVenta,
                    ArticuloId = precioNuevo.ArticuloId,
                    ListaPrecioId = precioNuevo.ListaPrecioId,
                    FechaActualizacion = precioNuevo.FechaActualizacion,
                    HoraVenta = precioNuevo.HoraVenta,
                    PrecioPublico = precioNuevo.PrecioPublico
                };
                context.Precios.Add(nuevoPrecio);
                context.SaveChanges();
                return nuevoPrecio.Id;
            }
        }

        public PrecioDto Obtener(long mesaId,long id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios
                    .Include(x=>x.ListaPrecio)
                    .AsNoTracking().Select(x=> new PrecioDto
                {
                    Id = x.Id,
                    ArticuloId = x.ArticuloId,
                    ActivarHoraVenta = x.ActivarHoraVenta,
                    HoraVenta = x.HoraVenta,
                    FechaActualizacion = x.FechaActualizacion,
                    ListaPrecioId = x.ListaPrecioId,
                    PrecioCosto = x.PrecioCosto,
                    PrecioPublico = x.PrecioPublico
                }).FirstOrDefault(y=> context.Precios.Any(l =>
                        l.ListaPrecio.Salon.Any(s => s.Mesas.Any(z => z.Id == mesaId))
                        && y.ArticuloId==id && y.FechaActualizacion== context.Precios
                                         .Where(l2 => l2.ListaPrecio.Salon.Any(
                                                          s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                                                      && l2.ArticuloId == id).Max(max => max.FechaActualizacion)));
            }
        }

        public IEnumerable<PrecioDto> Obtener(string cadenaBuscar)
        {


            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios
                    .Include(x=>x.Articulo)
                    .AsNoTracking()
                    .Where(x =>x.Articulo.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new PrecioDto
                    {
                        Id = x.Id,
                        ActivarHoraVenta = x.ActivarHoraVenta,
                        ArticuloId = x.ArticuloId,
                        HoraVenta = x.HoraVenta,
                        ListaPrecioId = x.ListaPrecioId,
                        PrecioCosto = x.PrecioCosto,
                        PrecioPublico = x.PrecioPublico,
                        FechaActualizacion = x.FechaActualizacion,
                        DescripcionArticulo = x.Articulo.Descripcion,
                        NombreLista = x.ListaPrecio.Descripcion
                    }).OrderByDescending(x=>x.FechaActualizacion)
                    .ToList();
            }
        }
    }
}
