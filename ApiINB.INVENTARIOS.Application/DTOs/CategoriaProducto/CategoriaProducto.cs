namespace ApiINB.INVENTARIOS.Application.DTOs.CategoriaProducto
{
    public class CategoriaProductoDto
    {
        public int CategoriaId { get; set; }

        public string NombreCategoria { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}