namespace ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega
{
    public class TramiteEntregaResponseDto
    {
        public int EntregaId { get; set; }

        public int SolicitudId { get; set; }

        public string TipoEntrega { get; set; } = string.Empty;

        public DateTime? FechaEntrega { get; set; }

        public string PersonaRecibe { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}