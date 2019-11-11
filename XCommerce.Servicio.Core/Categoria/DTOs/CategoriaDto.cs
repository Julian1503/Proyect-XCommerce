
namespace XCommerce.Servicio.Core.Categoria.DTOs
{
    using XCommerce.Servicio.Core.Base;

    public class CategoriaDto : BaseDto
    {
        public string Descripcion { get; set; }
        public decimal SalarioCategoria { get; set; }
    }
}
