using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class db_segurosContext : DbContext
    {
        public db_segurosContext()
        {
        }

        public db_segurosContext(DbContextOptions<db_segurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Porcentaje> Porcentajes { get; set; }
        public virtual DbSet<Rango> Rangos { get; set; }
        public virtual DbSet<Seguro> Seguros { get; set; }
        public virtual DbSet<SegurosPersona> SegurosPersonas { get; set; }
        public virtual DbSet<TipoSeguro> TipoSeguros { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=db_seguros; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK_personas");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.ApellidoPersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido_persona");

                entity.Property(e => e.CedulaPersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cedula_persona");

                entity.Property(e => e.EstadoPersona).HasColumnName("estado_persona");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_persona");

                entity.Property(e => e.TelefonoPersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono_persona");
            });

            modelBuilder.Entity<Porcentaje>(entity =>
            {
                entity.HasKey(e => e.IdPorcentaje)
                    .HasName("PK_porcentajes");

                entity.ToTable("porcentaje");

                entity.Property(e => e.IdPorcentaje).HasColumnName("id_porcentaje");

                entity.Property(e => e.Porcentaje1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("porcentaje");
            });

            modelBuilder.Entity<Rango>(entity =>
            {
                entity.HasKey(e => e.IdRango)
                    .HasName("PK_rengos");

                entity.ToTable("rangos");

                entity.Property(e => e.IdRango).HasColumnName("id_rango");

                entity.Property(e => e.Fin)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("fin");

                entity.Property(e => e.Inicio)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("inicio");

                entity.Property(e => e.Porcentaje)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("porcentaje");
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.HasKey(e => e.IdSeguro);

                entity.ToTable("seguros");

                entity.Property(e => e.IdSeguro)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_seguro");

                entity.Property(e => e.CodigoSeguro)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("codigo_seguro")
                    .IsFixedLength(true);

                entity.Property(e => e.EstadoSeguro).HasColumnName("estado_seguro");

                entity.Property(e => e.FechaCreacionSeguro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion_seguro");

                entity.Property(e => e.FechaModificacionSeguro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion_seguro");

                entity.Property(e => e.IdTipoSeguro).HasColumnName("id_tipo_seguro");

                entity.Property(e => e.NombreSeguro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre_seguro")
                    .IsFixedLength(true);

                entity.Property(e => e.PorcentajeSeguro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("porcentaje_seguro")
                    .IsFixedLength(true);

                entity.Property(e => e.Prima)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("prima");

                entity.Property(e => e.RangoEdadSeguro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("rango_edad_seguro")
                    .IsFixedLength(true);

                entity.Property(e => e.ValorSeguro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor_seguro");
            });

            modelBuilder.Entity<SegurosPersona>(entity =>
            {
                entity.HasKey(e => e.IdSeguroPersona);

                entity.ToTable("seguros_persona");

                entity.Property(e => e.IdSeguroPersona)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id_seguro_persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdSeguro)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("id_seguro");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.SegurosPersonas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_seguros_clientes_cliente");

                entity.HasOne(d => d.IdSeguroNavigation)
                    .WithMany(p => p.SegurosPersonas)
                    .HasForeignKey(d => d.IdSeguro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_seguros_clientes_seguros");
            });

            modelBuilder.Entity<TipoSeguro>(entity =>
            {
                entity.HasKey(e => e.IdTipoSeguro);

                entity.ToTable("tipo_seguros");

                entity.Property(e => e.IdTipoSeguro).HasColumnName("id_tipo_seguro");

                entity.Property(e => e.EstadoSeguro).HasColumnName("estado_seguro");

                entity.Property(e => e.TipoSeguro1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_seguro");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.ToTable("ventas");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdPorcentajeVenta).HasColumnName("id_porcentaje_venta");

                entity.Property(e => e.IdRangoVenta).HasColumnName("id_rango_venta");

                entity.Property(e => e.IdSeguroVenta).HasColumnName("id_seguro_venta");

                entity.Property(e => e.Prima)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prima");

                entity.Property(e => e.ValorVenta)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor_venta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
