public class ProductoFiltroDto
{
    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public int? CategoriaId { get; set; }

    public int? StockMinimo { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 50;
}