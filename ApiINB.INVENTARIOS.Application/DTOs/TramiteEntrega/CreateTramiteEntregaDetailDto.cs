namespace ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega
{
    public class CreateTramiteEntregaDetailDto
    {
        public int DetalleSolicitudId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadEntregadaId { get; set; }
    }
}