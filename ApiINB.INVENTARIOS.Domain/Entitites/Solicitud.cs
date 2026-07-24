using ApiINB.INVENTARIOS.Domain.Common;
public class Solicitud : AuditableEntity
{
    public int SolicitudId { get; set; }

    public int DependenciaId { get; set; }

    public int EstadoSolicitudId { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public string? LugarEntrega { get; set; }

    public DateTime? FechaEntregaSolicitada { get; set; }

    public string? PersonaRecibe { get; set; }

    public string? ObservacionesSolicitud { get; set; }

    public ICollection<SolicitudDetalle> Detalles { get; set; }
        = new List<SolicitudDetalle>();
}