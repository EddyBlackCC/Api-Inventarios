using ApiINB.INVENTARIOS.Domain.Common;

namespace ApiINB.INVENTARIOS.Domain.Entities;

public class CategoriaProducto : AuditableEntity
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    // Relación 1:N
    public ICollection<Producto> Productos { get; set; }
        = new List<Producto>();
}