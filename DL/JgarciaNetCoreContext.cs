using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JgarciaNetCoreContext : DbContext
{
    public JgarciaNetCoreContext()
    {
    }

    public JgarciaNetCoreContext(DbContextOptions<JgarciaNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RecetasMedica> RecetasMedicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-2POFP3ID; Database= JGarciaNetCore; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B79DF9895");

            entity.ToTable("Paciente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecetasMedica>(entity =>
        {
            entity.HasKey(e => e.IdRecetas).HasName("PK__RecetasM__042B26DF13F39C08");

            entity.Property(e => e.Diagnostico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaConsulta).HasColumnType("date");
            entity.Property(e => e.NombreMedico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.RecetasMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__RecetasMe__Notas__1273C1CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
