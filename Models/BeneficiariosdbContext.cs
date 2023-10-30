using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Models;

public partial class BeneficiariosdbContext : DbContext
{
    public BeneficiariosdbContext()
    {
    }

    public BeneficiariosdbContext(DbContextOptions<BeneficiariosdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionBeneficio> AsignacionBeneficios { get; set; }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<Beneficio> Beneficios { get; set; }

    public virtual DbSet<Colaboradore> Colaboradores { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<PadresDeFamilium> PadresDeFamilia { get; set; }

    public virtual DbSet<Patrocinadore> Patrocinadores { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<RolOperacion> RolOperacions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionBeneficio>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__Asignaci__A7235DFF8A358FB8");

            entity.HasIndex(e => e.IdBeneficiario, "IX_AsignacionBeneficios_IdBeneficiario");

            entity.HasIndex(e => e.IdPatrocinador, "IX_AsignacionBeneficios_IdBeneficio");

            entity.Property(e => e.DescripcionBeneficio)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dpi).HasColumnName("DPI");
            entity.Property(e => e.FechaAsignacion).HasColumnType("date");
            entity.Property(e => e.FirmaRecibido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(20, 0)");
            entity.Property(e => e.Parentesco)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.AsignacionBeneficios)
                .HasForeignKey(d => d.IdBeneficiario)
                .HasConstraintName("FK_AsignacionBeneficios_Beneficiarios");

            entity.HasOne(d => d.IdPatrocinadorNavigation).WithMany(p => p.AsignacionBeneficios)
                .HasForeignKey(d => d.IdPatrocinador)
                .HasConstraintName("FK_AsignacionBeneficios_Patrocinadores");
        });

        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiario).HasName("PK__Benefici__3D23355FCE2D3011");

            entity.HasIndex(e => e.IdPadre, "IX_Beneficiarios_IdPadre");

            entity.Property(e => e.CodigoBeneficiario)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("Telefono del Beneficiario");

            entity.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.Beneficiarios)
                .HasForeignKey(d => d.IdColaborador)
                .HasConstraintName("FK_Beneficiarios_Colaboradores");

            entity.HasOne(d => d.IdPadreNavigation).WithMany(p => p.Beneficiarios)
                .HasForeignKey(d => d.IdPadre)
                .HasConstraintName("FK_Beneficiarios_PadresDeFamilia");
        });

        modelBuilder.Entity<Beneficio>(entity =>
        {
            entity.HasKey(e => e.IdBeneficio).HasName("PK__Benefici__14B7CA0CCD1E7583");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__3D2CA512B04CA523");

            entity.HasIndex(e => e.IdPuesto, "IX_Colaboradores_IdPuesto");

            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dpi)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DPI");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK_Colaboradores_Puestos");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo);

            entity.ToTable("Modulo");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.Modulo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modulo");
        });

        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.IdOperacion);

            entity.ToTable("Operacion");

            entity.HasIndex(e => e.IdModulo, "IX_Operacion_IdModulo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Operacions)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK_Operacion_Modulo");
        });

        modelBuilder.Entity<PadresDeFamilium>(entity =>
        {
            entity.HasKey(e => e.IdPadre).HasName("PK__PadresDe__045356902EEAB2E3");

            entity.Property(e => e.DireccionPrincipal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DireccionSecundaria)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dpimadre)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("DPIMadre");
            entity.Property(e => e.Dpipadre)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("DPIPadre");
            entity.Property(e => e.NombreCompletoMadre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompletoPadre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoMadre)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoPadre)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patrocinadore>(entity =>
        {
            entity.HasKey(e => e.IdPatrocinador).HasName("PK__Patrocin__FCC34B4F45E077C3");

            entity.Property(e => e.CodigoPais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Soporte)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoBeneficioNavigation).WithMany(p => p.Patrocinadores)
                .HasForeignKey(d => d.TipoBeneficio)
                .HasConstraintName("FK_Patrocinadores_Beneficios");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.NombrePuesto)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolOperacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionRol);

            entity.ToTable("Rol_operacion");

            entity.HasIndex(e => e.IdOperacion, "IX_Rol_operacion_IdOperacion");

            entity.HasIndex(e => e.IdRol, "IX_Rol_operacion_IdRol");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.RolOperacions)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK_Rol_operacion_Operacion");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolOperacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Rol_operacion_Roles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C9A0BFE90");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97B476837D");

            entity.HasIndex(e => e.IdRol, "IX_Usuarios_IdRol");

            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
