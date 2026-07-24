using Microsoft.EntityFrameworkCore;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // =========================
        // MAESTROS
        // =========================

        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        // =========================
        // INGRESOS
        // =========================

        public DbSet<Ingreso> Ingresos { get; set; }

        public DbSet<IngresoDetalle> IngresoDetalles { get; set; }

        // =========================
        // SOLICITUDES
        // =========================

        public DbSet<Solicitud> Solicitudes { get; set; }

        public DbSet<SolicitudDetalle> SolicitudDetalles { get; set; }

        public DbSet<Autorizador> Autorizadores { get; set; }

        // =========================
        // ENTREGAS
        // =========================

        public DbSet<TramiteEntrega> TramiteEntregas { get; set; }

        public DbSet<TramiteEntregaDetalle> TramiteEntregaDetalles { get; set; }

        // =========================
        // NOTIFICACIONES
        // =========================

        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // ESQUEMA
            // =========================

            modelBuilder.HasDefaultSchema("Inventario");

            // =====================================================
            // CATEGORIA PRODUCTO
            // =====================================================

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.ToTable("CategoriaProducto", "Inventario");

                entity.HasKey(x => x.CategoriaId);
            });

            // =====================================================
            // PRODUCTO
            // =====================================================

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto", "Inventario");

                entity.HasKey(x => x.ProductoId);

                entity.HasOne(x => x.CategoriaProducto)
                      .WithMany(x => x.Productos)
                      .HasForeignKey(x => x.CategoriaId);
            });

            // =====================================================
            // INGRESO
            // =====================================================

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.ToTable("Ingreso", "Inventario");

                entity.HasKey(x => x.InventarioId);

                entity.HasMany(x => x.Detalles)
                      .WithOne(x => x.Ingreso)
                      .HasForeignKey(x => x.InventarioId);
            });

            // =====================================================
            // INGRESO DETALLE
            // =====================================================

            modelBuilder.Entity<IngresoDetalle>(entity =>
            {
                entity.ToTable("IngresoDetalle", "Inventario");

                entity.HasKey(x => x.DetalleIngresoId);

                entity.HasOne(x => x.Ingreso)
                      .WithMany(x => x.Detalles)
                      .HasForeignKey(x => x.InventarioId);

                entity.HasOne(x => x.Producto)
                      .WithMany()
                      .HasForeignKey(x => x.ProductoId);
            });

            // =====================================================
            // AUTORIZADOR
            // =====================================================

            modelBuilder.Entity<Autorizador>(entity =>
            {
                entity.ToTable("Autorizador", "Inventario");

                entity.HasKey(x => x.AutorizadorId);
            });

            // =====================================================
            // SOLICITUD
            // =====================================================

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("Solicitud", "Inventario");

                entity.HasKey(x => x.SolicitudId);

                entity.HasMany(x => x.Detalles)
                      .WithOne(x => x.Solicitud)
                      .HasForeignKey(x => x.SolicitudId);
            });

            // =====================================================
            // SOLICITUD DETALLE
            // =====================================================

            modelBuilder.Entity<SolicitudDetalle>(entity =>
            {
                entity.ToTable("SolicitudDetalle", "Inventario");

                entity.HasKey(x => x.DetalleSolicitudId);

                entity.HasOne(x => x.Solicitud)
                      .WithMany(x => x.Detalles)
                      .HasForeignKey(x => x.SolicitudId);

                entity.HasOne(x => x.Producto)
                      .WithMany()
                      .HasForeignKey(x => x.ProductoId);

                entity.HasOne(x => x.Autorizador)
                      .WithMany()
                      .HasForeignKey(x => x.AutorizadorId);
            });

            // =====================================================
            // TRAMITE ENTREGA
            // =====================================================

            modelBuilder.Entity<TramiteEntrega>(entity =>
            {
                entity.ToTable("TramiteEntrega", "Inventario");

                entity.HasKey(x => x.EntregaId);

                entity.HasOne(x => x.Solicitud)
                      .WithMany()
                      .HasForeignKey(x => x.SolicitudId);

                entity.HasMany(x => x.Detalles)
                      .WithOne(x => x.TramiteEntrega)
                      .HasForeignKey(x => x.EntregaId);
            });

            // =====================================================
            // TRAMITE ENTREGA DETALLE
            // =====================================================

          modelBuilder.Entity<TramiteEntregaDetalle>(entity =>
{
    entity.ToTable("TramiteEntregaDetalle", "Inventario");

    entity.HasKey(x => x.DetalleEntregaId);

    entity.Property(x => x.CantidadEntregadaId)
        .IsRequired();

    entity.HasOne(x => x.TramiteEntrega)
        .WithMany(x => x.Detalles)
        .HasForeignKey(x => x.EntregaId);

    entity.HasOne(x => x.SolicitudDetalle)
        .WithMany()
        .HasForeignKey(x => x.DetalleSolicitudId);

    entity.HasOne(x => x.Producto)
        .WithMany()
        .HasForeignKey(x => x.ProductoId);
});

            // =====================================================
            // NOTIFICACION
            // =====================================================

            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.ToTable("Notificaciones", "Inventario");

                entity.HasKey(x => x.NotificacionId);

                entity.HasOne(x => x.Solicitud)
                      .WithMany()
                      .HasForeignKey(x => x.SolicitudId);
            });
        }
    }
}