namespace ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega
{
    public class CreateTramiteEntregaDto
    {
        public int SolicitudId { get; set; }

        public string TipoEntrega { get; set; } = string.Empty;

        public DateTime FechaTramite { get; set; }

        public DateTime FechaEntrega { get; set; }

        public int UsuarioEntrega { get; set; }

        public string PersonaRecibe { get; set; } = string.Empty;

        public string? LugarEntrega { get; set; }

        public string? FirmaEntregaBase64 { get; set; }

        public string? FirmaRecibeBase64 { get; set; }

        public int AudCreaUsuario { get; set; }

        public List<CreateTramiteEntregaDetailDto> Detalles { get; set; }
            = new();
    }
}