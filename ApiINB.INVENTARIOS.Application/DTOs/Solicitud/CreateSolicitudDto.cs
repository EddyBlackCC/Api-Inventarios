namespace ApiINB.INVENTARIOS.Application.DTOs.Solicitud
{
    public class CreateSolicitudDto
    {
        public int DependenciaId { get; set; }

        public string? LugarEntrega { get; set; }

        public DateTime? FechaEntregaSolicitada { get; set; }

        public string? PersonaRecibe { get; set; }

        public string? ObservacionesSolicitud { get; set; }

        public List<CreateSolicitudDetalleDto> Detalles { get; set; }
            = new();
    }
}