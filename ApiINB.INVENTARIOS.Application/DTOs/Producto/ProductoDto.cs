namespace ApiINB.INVENTARIOS.Application.DTOs.Producto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }

        public string CodigoProducto { get; set; } = string.Empty;

        public string NombreProducto { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public string UnidadMedida { get; set; } = string.Empty;

        public int StockMinimo { get; set; }

        public int? StockMaximo { get; set; }

        public bool Activo { get; set; }
    }
}