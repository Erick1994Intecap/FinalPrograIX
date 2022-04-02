using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class HOOVERSContext : DbContext
    {
        public HOOVERSContext()
        {
        }

        public HOOVERSContext(DbContextOptions<HOOVERSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<MetodoHttp> MetodoHttps { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }
        public virtual DbSet<VwPrimerVistum> VwPrimerVista { get; set; }
        public virtual DbSet<VwViajeCliente> VwViajeClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=HOOVERS;Integrated Security=True;Pooling=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.ToTable("BITACORA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMetodo).HasColumnName("ID_METODO");

                entity.Property(e => e.IdModulo).HasColumnName("ID_MODULO");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO")
                    .HasDefaultValueSql("(user_name())");

                entity.HasOne(d => d.IdMetodoNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdMetodo)
                    .HasConstraintName("FK_BITA_METODO");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK_BITA_MODULO");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ACTUALIZACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_CREACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ACTUALIZACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_CREACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<MetodoHttp>(entity =>
            {
                entity.ToTable("METODO_HTTP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("MODULO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TIPO_VEHICULO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ACTUALIZACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_CREACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("VEHICULO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ACTUALIZACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_CREACION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTipo)
                    .HasColumnName("ID_TIPO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Modelo).HasColumnName("MODELO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_TIPO");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.ToTable("VIAJE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DescripcionViaje)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_VIAJE")
                    .HasDefaultValueSql("('VIAJE DE NEGOCIO')");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_FIN")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaViaje)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_VIAJE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdDeptoViaje)
                    .HasColumnName("ID_DEPTO_VIAJE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_VEHICULO");

                entity.Property(e => e.PrecioViaje)
                    .HasColumnType("numeric(16, 2)")
                    .HasColumnName("PRECIO_VIAJE");

                entity.Property(e => e.ViajeRealizado)
                    .HasColumnName("VIAJE_REALIZADO")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_CLIENTE");

                entity.HasOne(d => d.IdDeptoViajeNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdDeptoViaje)
                    .HasConstraintName("FK_DEPARTAMENTO");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_VEHICULO");
            });

            modelBuilder.Entity<VwPrimerVistum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_PRIMER_VISTA");

                entity.Property(e => e.DescripcionViaje)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_VIAJE");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaViaje)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_VIAJE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdDeptoViaje).HasColumnName("ID_DEPTO_VIAJE");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_VEHICULO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(501)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.PrecioViaje)
                    .HasColumnType("numeric(16, 2)")
                    .HasColumnName("PRECIO_VIAJE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.ViajeRealizado).HasColumnName("VIAJE_REALIZADO");
            });

            modelBuilder.Entity<VwViajeCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_VIAJE_CLIENTE");

                entity.Property(e => e.DescripcionViaje)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_VIAJE");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaViaje)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_VIAJE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdDeptoViaje).HasColumnName("ID_DEPTO_VIAJE");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_VEHICULO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(501)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.PrecioViaje)
                    .HasColumnType("numeric(16, 2)")
                    .HasColumnName("PRECIO_VIAJE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.ViajeRealizado).HasColumnName("VIAJE_REALIZADO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
