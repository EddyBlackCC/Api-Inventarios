namespace ApiINB.INVENTARIOS.Application.DTOs.CategoriaProducto
{
    public class CreateCategoriaProductoDto
    {
        public string NombreCategoria { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
    }
}