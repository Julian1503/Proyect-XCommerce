namespace XCommerce.Servicio.Core.Articulo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class ArticuloServicio : IArticuloServicio
    {
        public long? Agregar(ArticuloDto articulo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var ArticuloNuevo = new AccesoDatos.Articulo
                {
                    Descripcion = articulo.Descripcion,
                    Abreviatura = articulo.Abreviatura,
                    Codigo = articulo.Codigo,
                    CodigoBarra = articulo.CodigoBarra,
                    ActivarLimiteVenta = articulo.ActivarLimiteVenta,
                    DescuentaStock = articulo.DescuentaStock,
                    Detalle = articulo.Detalle,
                    EstaDiscontinuado = articulo.EstaDiscontinuado,
                    EstaEliminado = articulo.EstaEliminado,
                    Foto = articulo.Foto,
                    LimiteVenta = articulo.LimiteVenta,
                    MarcaId = articulo.MarcaId,
                    PermiteStockNegativo = articulo.PermiteStockNegativo,
                    RubroId = articulo.RubroId,
                    Stock = articulo.Stock,
                    StockMaximo = articulo.StockMaximo,
                    StockMinimo = articulo.StockMinimo
                };
                context.Articulos.Add(ArticuloNuevo);
                context.SaveChanges();
                return articulo.Id;
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empleadoEliminado = context.Articulos.FirstOrDefault(x => x.Id == entidadId);
                if (empleadoEliminado == null) throw new Exception("No se encontro el articulo");

                empleadoEliminado.EstaEliminado = true;
                context.SaveChanges();
            }
        }

        public void Modificar(ArticuloDto articulo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var articuloModificar = context.Articulos
                    .Include(x => x.Rubro)
                    .Include(x => x.Marca)
                    .FirstOrDefault(x => x.Id == articulo.Id);

                    if (articuloModificar == null)
                    throw new Exception("No se encontro el articulo");

                    articuloModificar.Descripcion = articulo.Descripcion;
                    articuloModificar.Abreviatura = articulo.Abreviatura;
                    articuloModificar.Codigo = articulo.Codigo;
                    articuloModificar.CodigoBarra = articulo.CodigoBarra;
                    articuloModificar.ActivarLimiteVenta = articulo.ActivarLimiteVenta;
                    articuloModificar.DescuentaStock = articulo.DescuentaStock;
                    articuloModificar.Detalle = articulo.Detalle;
                    articuloModificar.EstaDiscontinuado = articulo.EstaDiscontinuado;
                    articuloModificar.EstaEliminado = articulo.EstaEliminado;
                    articuloModificar.Foto = articulo.Foto;
                    articuloModificar.Id = articulo.Id;
                    articuloModificar.LimiteVenta = articulo.LimiteVenta;
                    articuloModificar.MarcaId = articulo.MarcaId;
                    articuloModificar.PermiteStockNegativo = articulo.PermiteStockNegativo;
                    articuloModificar.RubroId = articulo.RubroId;
                    articuloModificar.Stock = articulo.Stock;
                    articuloModificar.StockMaximo = articulo.StockMaximo;
                    articuloModificar.StockMinimo = articulo.StockMinimo;
                context.SaveChanges();

            }
        }

        public IEnumerable<ArticuloDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Include(x=>x.Rubro)
                    .Include(x=>x.Marca)
                    .AsNoTracking().Where(x =>
                        x.Abreviatura.Contains(cadenaBuscar) || x.Codigo == cadenaBuscar ||
                        x.CodigoBarra == cadenaBuscar || x.Marca.Descripcion == cadenaBuscar ||
                        x.Rubro.Descripcion == cadenaBuscar)
                    .Select(x=>new ArticuloDto
                    {
                        Descripcion = x.Descripcion,
                        Abreviatura = x.Abreviatura,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        ActivarLimiteVenta = x.ActivarLimiteVenta,
                        DescuentaStock = x.DescuentaStock,
                        Detalle = x.Detalle,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        EstaEliminado = x.EstaEliminado,
                        Foto = x.Foto,
                        Id = x.Id,
                        LimiteVenta = x.LimiteVenta,
                        MarcaId=x.MarcaId,
                        PermiteStockNegativo = x.PermiteStockNegativo,
                        RubroId = x.RubroId,
                        Stock = x.Stock,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo
                    }).ToList();
            }
        }

        public ArticuloDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Include(x => x.Rubro)
                    .Include(x => x.Marca)
                    .AsNoTracking()
                    .Select(x => new ArticuloDto
                    {
                        Descripcion = x.Descripcion,
                        Abreviatura = x.Abreviatura,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        ActivarLimiteVenta = x.ActivarLimiteVenta,
                        DescuentaStock = x.DescuentaStock,
                        Detalle = x.Detalle,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        EstaEliminado = x.EstaEliminado,
                        Foto = x.Foto,
                        Id = x.Id,
                        LimiteVenta = x.LimiteVenta,
                        MarcaId = x.MarcaId,
                        PermiteStockNegativo = x.PermiteStockNegativo,
                        RubroId = x.RubroId,
                        Stock = x.Stock,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public ArticuloDto ObtenerPorCodigo(long? mesaId, string codigo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                
                return context.Articulos
                    .Include(x => x.Precios)
                    .Include("Precios.ListaPrecio")
                    .Include("Precios.ListaPrecio.Salon")
                    .Include("Precios.ListaPrecio.Salon.Mesas")
                    .AsNoTracking()
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        DescuentaStock = x.DescuentaStock,
                        CodigoBarra = x.CodigoBarra,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        Stock = x.Stock,
                        PermiteStockNegativo = x.PermiteStockNegativo,
                        EstaEliminado = x.EstaEliminado,
                        Precio = context.Precios.FirstOrDefault(l =>
                                l.ListaPrecio.Salon.Any(s => s.Mesas.Any(y => y.Id == mesaId))
                                && l.ArticuloId == x.Id
                                && l.FechaActualizacion == context.Precios
                                    .Where(l2 => l2.ListaPrecio.Salon.Any(
                                                     s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                                                 && l2.ArticuloId == x.Id).Max(max => max.FechaActualizacion))
                            .PrecioPublico
                    }).FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);

            }
        }

        public string SiguienteCodigoArticulo()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                if (context.Articulos.Any())
                {
                    return (Convert.ToInt32(context.Articulos.AsNoTracking().Max(x => x.Codigo))+1).ToString();
                }
                else
                {
                    return "1";
                }
            }
        }

        public IEnumerable<ArticuloDto> ObtenerSinEliminados(string cadenaBuscar,long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Include(x => x.Precios)
                    .Include("Precios.ListaPrecio")
                    .Include("Precios.ListaPrecio.Salon")
                    .Include("Precios.ListaPrecio.Salon.Mesas")
                    .Include(x => x.Rubro)
                    .Include(x => x.Marca)
                    .AsNoTracking().Where(x =>x.Descripcion.Contains(cadenaBuscar)&&
                    x.Precios.Any(n=>n.ListaPrecio.Salon.Any(y=>y.Mesas.Any(o=>o.Id == mesaId))))
                    .Select(x => new ArticuloDto
                    {
                        Precio = context.Precios.FirstOrDefault(l =>
                            l.ListaPrecio.Salon.Any(s => s.Mesas.Any(y => y.Id == mesaId))
                            && l.ArticuloId == x.Id
                            && l.FechaActualizacion == context.Precios
                                .Where(l2 => l2.ListaPrecio.Salon.Any(
                                                 s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                                             && l2.ArticuloId == x.Id).
                                Max(max => max.FechaActualizacion)).PrecioPublico,
                        PrecioCosto = context.Precios.FirstOrDefault(l =>
                           l.ListaPrecio.Salon.Any(s => s.Mesas.Any(y => y.Id == mesaId))
                           && l.ArticuloId == x.Id
                           && l.FechaActualizacion == context.Precios
                               .Where(l2 => l2.ListaPrecio.Salon.Any(
                                                s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
                                            && l2.ArticuloId == x.Id).
                               Max(max => max.FechaActualizacion)).PrecioCosto,
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        Stock=x.Stock,
                        DescuentaStock = x.DescuentaStock,
                        CodigoBarra = x.CodigoBarra
                    }).ToList();
            }
        }

        public ArticuloDto ObtenerProductoPorCodigo(string codigo,long listaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos
                    .Include(x => x.Precios)
                    .Include("Precios.ListaPrecio")
                    .AsNoTracking()
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        DescuentaStock = x.DescuentaStock,
                        CodigoBarra = x.CodigoBarra,
                        Stock = x.Stock,
                        PrecioCosto = context.Precios.FirstOrDefault(l => l.ListaPrecio.Id == listaId && l.ArticuloId == x.Id
                        && l.FechaActualizacion ==
                        context.Precios.Where(l2 => l2.ListaPrecio.Id == listaId && l2.ArticuloId == x.Id).
                        Max(max => max.FechaActualizacion)).PrecioCosto,
                        Precio = context.Precios.FirstOrDefault(l => l.ListaPrecio.Id == listaId && l.ArticuloId == x.Id 
                        && l.FechaActualizacion ==
                        context.Precios.Where(l2 => l2.ListaPrecio.Id == listaId && l2.ArticuloId == x.Id).
                        Max(max => max.FechaActualizacion)).PrecioPublico,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Codigo == codigo || x.CodigoBarra == codigo);
            }
        }

        public IEnumerable<ArticuloDto> ObtenerProducto(string codigo,long listaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.AsNoTracking()
                    .Where(x => x.Precios.Any(y => y.ListaPrecio.Id == listaId))
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        DescuentaStock = x.DescuentaStock,
                        CodigoBarra = x.CodigoBarra,
                        Stock = x.Stock,
                        Precio = context.Precios.FirstOrDefault(l => l.ListaPrecio.Id == listaId && l.ArticuloId == x.Id && l.FechaActualizacion == context.Precios.Where(l2 => l2.ListaPrecio.Id == listaId && l2.ArticuloId == x.Id).Max(max => max.FechaActualizacion)).PrecioPublico,
                        PrecioCosto = context.Precios.FirstOrDefault(l => l.ListaPrecio.Id == listaId && l.ArticuloId == x.Id
&& l.FechaActualizacion ==
context.Precios.Where(l2 => l2.ListaPrecio.Id == listaId && l2.ArticuloId == x.Id).
Max(max => max.FechaActualizacion)).PrecioCosto,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public IEnumerable<ArticuloDto> ReporteReponerStock()
        {
            using(var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.Where(x=>x.Stock<=x.StockMinimo)
                    .Select(x => new ArticuloDto
                {
                    Descripcion = x.Descripcion,
                    Abreviatura = x.Abreviatura,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    ActivarLimiteVenta = x.ActivarLimiteVenta,
                    DescuentaStock = x.DescuentaStock,
                    Detalle = x.Detalle,
                    EstaDiscontinuado = x.EstaDiscontinuado,
                    EstaEliminado = x.EstaEliminado,
                    Foto = x.Foto,
                    Id = x.Id,
                    LimiteVenta = x.LimiteVenta,
                    MarcaId = x.MarcaId,
                    PermiteStockNegativo = x.PermiteStockNegativo,
                    RubroId = x.RubroId,
                    Stock = x.Stock,
                    StockMaximo = x.StockMaximo,
                    StockMinimo = x.StockMinimo
                }).ToList();
            }
        }
    }
}
