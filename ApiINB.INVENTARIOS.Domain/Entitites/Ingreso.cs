using ApiINB.INVENTARIOS.Domain.Common;

namespace ApiINB.INVENTARIOS.Domain.Entities
{
    public class Ingreso : AuditableEntity
    {
        public int InventarioId { get; set; }

        public string? FacturaActa { get; set; }

        public DateTime FacturaActaFecha { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Soporte { get; set; } = string.Empty;

        public string? Observaciones { get; set; }


        // RELACIÓN 1 A MUCHOS
        public ICollection<IngresoDetalle> Detalles { get; set; }
            = new List<IngresoDetalle>();
    }
}