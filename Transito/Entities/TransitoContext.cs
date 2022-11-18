using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Transito.Entities
{
    public partial class TransitoContext : DbContext
    {
        public TransitoContext()
        {
        }
        public TransitoContext(DbContextOptions<TransitoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductore> Conductores { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Sancione> Sanciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=FOSORIO\\MSSQLSERVER01;user=FABIANOSORIO;password=12345;database=Transito");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductore>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Conductores)
                    .HasForeignKey(d => d.MatriculaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Matricula");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.Property(e => e.FechaExpedicion).HasColumnType("date");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidaHasta).HasColumnType("date");
            });

            modelBuilder.Entity<Sancione>(entity =>
            {
                entity.Property(e => e.FechaActual).HasColumnType("date");

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.Property(e => e.Sancion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Conductores)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.ConductoresId)
                    .HasConstraintName("fk_Conductor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
