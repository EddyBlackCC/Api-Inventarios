using ApiINB.INVENTARIOS.Domain.Common;

namespace ApiINB.INVENTARIOS.Domain.Entities;

public class Producto : AuditableEntity
{
    public int ProductoId { get; set; }

    public string CodigoProducto { get; set; } = string.Empty;

    public string NombreProducto { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public int CategoriaId { get; set; }

    public string UnidadMedida { get; set; } = string.Empty;

    public int? StockMinimo { get; set; }

    public int? StockMaximo { get; set; }

    public int StockActual { get; set; }

    public string? UsoExclusivo { get; set; }

    // Relación N:1
public CategoriaProducto CategoriaProducto { get; set; } = null!;}