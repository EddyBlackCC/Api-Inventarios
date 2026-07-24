using ApiINB.INVENTARIOS.Domain.Common;
using ApiINB.INVENTARIOS.Domain.Entities;
public class IngresoDetalle
{
    public int DetalleIngresoId { get; set; }

    public int ProductoId { get; set; }

    public int InventarioId { get; set; }

    public int Cantidad { get; set; }

    public string? Observaciones { get; set; }

    public bool Activo { get; set; } = true;

    // navegación
    public Ingreso? Ingreso { get; set; }

    public Producto? Producto { get; set; }
}