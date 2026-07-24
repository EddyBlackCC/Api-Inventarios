namespace ApiINB.INVENTARIOS.Application.DTOs.Ingreso
{
    public class CreateIngresoDto
    {
        public string? FacturaActa { get; set; }

        public DateTime FacturaActaFecha { get; set; }

        public string Soporte { get; set; } = string.Empty;

        public string? Observaciones { get; set; }

        public List<CreateIngresoDetalleDto> Detalles { get; set; }
            = new();
    }
}