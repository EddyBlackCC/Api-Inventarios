using ApiINB.INVENTARIOS.Domain.Common;
using ApiINB.INVENTARIOS.Domain.Entities;
public class TramiteEntregaDetalle : AuditableEntity
{
    public int DetalleEntregaId { get; set; }

    public int EntregaId { get; set; }

    public int DetalleSolicitudId { get; set; }

    public int ProductoId { get; set; }

    public int CantidadEntregadaId { get; set; }

    public TramiteEntrega? TramiteEntrega { get; set; }

public Producto? Producto { get; set; }

public SolicitudDetalle? SolicitudDetalle { get; set; }
}