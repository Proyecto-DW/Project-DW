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

    public virtual DbSet<Patrocinadore> Patrocinadores { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<RolOperacion> RolOperacions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionBeneficio>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__Asignaci__A7235DFF8A358FB8");

            entity.Property(e => e.IdAsignacion).HasComment("Id Asignación");
            entity.Property(e => e.Comentarios).HasColumnType("text");
            entity.Property(e => e.DescripcionBeneficio)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Descripcion Beneficio");
            entity.Property(e => e.Dpi)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasComment("DPI Recibe")
                .HasColumnName("DPI");
            entity.Property(e => e.FechaAsignacion)
                .HasComment("Fecha Asignación")
                .HasColumnType("date");
            entity.Property(e => e.IdBeneficiario).HasComment("Id Beneficiario");
            entity.Property(e => e.IdBeneficio).HasComment("Id Beneficio");
            entity.Property(e => e.Monto).HasColumnType("decimal(20, 0)");
            entity.Property(e => e.Parentesco)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Parentesco");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.AsignacionBeneficios)
                .HasForeignKey(d => d.IdBeneficiario)
                .HasConstraintName("FK_AsignacionBeneficios_Beneficiario");

            entity.HasOne(d => d.IdBeneficioNavigation).WithMany(p => p.AsignacionBeneficios)
                .HasForeignKey(d => d.IdBeneficio)
                .HasConstraintName("FK_AsignacionBeneficios_Beneficio");
        });

        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiario).HasName("PK_Beneficiario2");

            entity.ToTable("Beneficiario");

            entity.Property(e => e.CodigoBeneficiario)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.DireccionMadre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionPadre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dpimadre)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DPIMadre");
            entity.Property(e => e.Dpipadre)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DPIPadre");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.NombreMadre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombrePadre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoBeneficiario)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoMadre)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoPadre)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoPrincipal)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoSecundario)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.Beneficiarios)
                .HasForeignKey(d => d.IdColaborador)
                .HasConstraintName("FK_Beneficiario_Colaboradores");
        });

        modelBuilder.Entity<Beneficio>(entity =>
        {
            entity.HasKey(e => e.IdBeneficio);

            entity.ToTable("Beneficio");

            entity.Property(e => e.DetalleBeneficio)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Soporte)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdPatrocinadorNavigation).WithMany(p => p.Beneficios)
                .HasForeignKey(d => d.IdPatrocinador)
                .HasConstraintName("FK_Beneficio_Patrocinadores");
        });

        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__3D2CA512B04CA523");

            entity.Property(e => e.IdColaborador).HasComment("Id Colaborador");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasComment("Correo Electrónico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasComment("Dirección");
            entity.Property(e => e.Dpi)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasComment("DPI Colaborador")
                .HasColumnName("DPI");
            entity.Property(e => e.FechaNacimiento)
                .HasComment("Fecha Nacimiento")
                .HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasComment("Género");
            entity.Property(e => e.IdPuesto).HasComment("Id Puesto");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasComment("Nombre Completo");
            entity.Property(e => e.Profesion)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasComment("Teléfono");

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

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Operacions)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK_Operacion_Modulo");
        });

        modelBuilder.Entity<Patrocinadore>(entity =>
        {
            entity.HasKey(e => e.IdPatrocinador).HasName("PK__Patrocin__FCC34B4F45E077C3");

            entity.Property(e => e.CodigoPais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Código Pais");
            entity.Property(e => e.CodigoReferencia)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasComment("Código Referencia");
            entity.Property(e => e.Estado).HasComment("Estado");
            entity.Property(e => e.FechaRegistro)
                .HasComment("Fecha Registro")
                .HasColumnType("date");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto);

            entity.Property(e => e.IdPuesto).HasComment("Id Puesto");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha Creación")
                .HasColumnType("date");
            entity.Property(e => e.NombrePuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre Puesto");
        });

        modelBuilder.Entity<RolOperacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionRol);

            entity.ToTable("Rol_operacion");

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
