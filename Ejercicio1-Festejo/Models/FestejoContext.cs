using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1_Festejo.Models;

public partial class FestejoContext : DbContext
{
    public FestejoContext()
    {
    }

    public FestejoContext(DbContextOptions<FestejoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menor> Menor { get; set; }

    public virtual DbSet<Vwcumplenhoy> Vwcumplenhoy { get; set; }

    public virtual DbSet<Vwcumplenmes> Vwcumplenmes { get; set; }

    public virtual DbSet<Vwmenores12> Vwmenores12 { get; set; }

    public virtual DbSet<Vwmenoresdoce> Vwmenoresdoce { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=festejo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Menor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwcumplenhoy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwcumplenhoy");

            entity.Property(e => e.Domicilio)
                .HasColumnType("text")
                .HasColumnName("DOMICILIO");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwcumplenmes>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwcumplenmes");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmenores12>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmenores12");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmenoresdoce>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmenoresdoce");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
