namespace ApiINB.INVENTARIOS.Application.DTOs.Producto
{
    public class CreateProductoDto
    {
        public string CodigoProducto { get; set; } = string.Empty;

        public string NombreProducto { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public int StockMinimo { get; set; }

        public int? StockMaximo { get; set; }

        public string? UsoExclusivo { get; set; }
    }
}