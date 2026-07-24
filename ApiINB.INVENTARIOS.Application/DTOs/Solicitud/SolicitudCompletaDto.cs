namespace ApiINB.INVENTARIOS.Application.DTOs.Solicitud
{
    public class SolicitudCompletaDto
    {
        public int SolicitudId { get; set; }

        public int DependenciaId { get; set; }

        public int EstadoSolicitudId { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public string? LugarEntrega { get; set; }

        public string? PersonaRecibe { get; set; }

        public List<SolicitudDetalleCompletoDto> Detalles { get; set; }
            = new();
    }
}