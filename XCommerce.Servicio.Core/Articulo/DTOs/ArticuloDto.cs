namespace XCommerce.Servicio.Core.Articulo.DTOs
{
    using Base;
    public class ArticuloDto : BaseDto
    {

        public string Codigo { get; set; }

        public string CodigoBarra { get; set; }

        public string Abreviatura { get; set; }

        public decimal? Precio { get; set; }

        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        public byte[] Foto { get; set; }

        public bool ActivarLimiteVenta { get; set; }

        public decimal LimiteVenta { get; set; }

        public bool PermiteStockNegativo { get; set; }

        public bool EstaDiscontinuado { get; set; }

        public string DiscontinuadoStg => EstaDiscontinuado ? "SI" : "NO";
            
        public decimal StockMaximo { get; set; }

        public decimal StockMinimo { get; set; }

        public bool DescuentaStock { get; set; }
       
        public long MarcaId { get; set; }

        public long RubroId { get; set; }

        public decimal Stock { get; set; }

        public decimal? PrecioCosto { get; set; }
    }
}
