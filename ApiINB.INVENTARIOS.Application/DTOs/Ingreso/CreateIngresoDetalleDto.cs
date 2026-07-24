namespace ApiINB.INVENTARIOS.Application.DTOs.Ingreso
{
    public class CreateIngresoDetalleDto
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public string? Observaciones { get; set; }
    }
}