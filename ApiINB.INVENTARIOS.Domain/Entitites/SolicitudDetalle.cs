using ApiINB.INVENTARIOS.Domain.Common;
using ApiINB.INVENTARIOS.Domain.Entities;
public class SolicitudDetalle : AuditableEntity
{
    public int DetalleSolicitudId { get; set; }

    public int SolicitudId { get; set; }

    public int ProductoId { get; set; }

    public int CantidadSolicitada { get; set; }

    public int? CantidadAprobada { get; set; }

    public int EstadoSolicitudDetalleId { get; set; }
    public int? EstadoEntregaDetalleId { get; set; }

    public int AutorizadorId { get; set; }

    public DateTime? FechaAprobo { get; set; }

    // Navigation
    public Solicitud Solicitud { get; set; } = null!;

    public Producto Producto { get; set; } = null!;

    public Autorizador Autorizador { get; set; } = null!;
}