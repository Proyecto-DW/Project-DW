﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appbeneficiencia.Models;

#nullable disable

namespace appbeneficiencia.Migrations
{
    [DbContext(typeof(BeneficiariosdbContext))]
    [Migration("20231003201228_ActualizacionDataBase")]
    partial class ActualizacionDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("appbeneficiencia.Models.AsignacionBeneficio", b =>
                {
                    b.Property<int>("IdAsignacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsignacion"));

                    b.Property<DateTime?>("FechaAsignacion")
                        .HasColumnType("date");

                    b.Property<int?>("IdBeneficiario")
                        .HasColumnType("int");

                    b.Property<int?>("IdBeneficio")
                        .HasColumnType("int");

                    b.HasKey("IdAsignacion")
                        .HasName("PK__Asignaci__A7235DFF8A358FB8");

                    b.HasIndex("IdBeneficiario");

                    b.HasIndex("IdBeneficio");

                    b.ToTable("AsignacionBeneficios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Beneficiario", b =>
                {
                    b.Property<int>("IdBeneficiario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBeneficiario"));

                    b.Property<string>("Apellidos")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int?>("IdPadre")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdBeneficiario")
                        .HasName("PK__Benefici__3D23355FCE2D3011");

                    b.HasIndex("IdPadre");

                    b.ToTable("Beneficiarios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Beneficio", b =>
                {
                    b.Property<int>("IdBeneficio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBeneficio"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdBeneficio")
                        .HasName("PK__Benefici__14B7CA0CCD1E7583");

                    b.ToTable("Beneficios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Colaboradore", b =>
                {
                    b.Property<int>("IdColaborador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColaborador"));

                    b.Property<string>("Apellidos")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Correo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Dpi")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("DPI");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Genero")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("IdPuesto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdColaborador")
                        .HasName("PK__Colabora__3D2CA512B04CA523");

                    b.HasIndex("IdPuesto");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Modulo", b =>
                {
                    b.Property<int>("IdModulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModulo"));

                    b.Property<string>("Modulo1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Modulo");

                    b.HasKey("IdModulo");

                    b.ToTable("Modulo", (string)null);
                });

            modelBuilder.Entity("appbeneficiencia.Models.Operacion", b =>
                {
                    b.Property<int>("IdOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOperacion"));

                    b.Property<int?>("IdModulo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdOperacion");

                    b.HasIndex("IdModulo");

                    b.ToTable("Operacion", (string)null);
                });

            modelBuilder.Entity("appbeneficiencia.Models.PadresDeFamilium", b =>
                {
                    b.Property<int>("IdPadre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPadre"));

                    b.Property<string>("ApellidoPadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApellidosMadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DireccionMadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DireccionPadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreMadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombrePadre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TelefonoMadre")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("TelefonoPadre")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdPadre")
                        .HasName("PK__PadresDe__045356902EEAB2E3");

                    b.ToTable("PadresDeFamilia");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Patrocinadore", b =>
                {
                    b.Property<int>("IdPatrocinador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatrocinador"));

                    b.Property<string>("Contacto")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Correo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdPatrocinador")
                        .HasName("PK__Patrocin__FCC34B4F45E077C3");

                    b.ToTable("Patrocinadores");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Patrocinio", b =>
                {
                    b.Property<int>("IdPatrocinio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatrocinio"));

                    b.Property<int?>("IdBeneficiario")
                        .HasColumnType("int");

                    b.Property<int?>("IdPatrocinador")
                        .HasColumnType("int");

                    b.HasKey("IdPatrocinio")
                        .HasName("PK__Patrocin__C2F5DE5E7D4509C1");

                    b.HasIndex("IdBeneficiario");

                    b.HasIndex("IdPatrocinador");

                    b.ToTable("Patrocinio", (string)null);
                });

            modelBuilder.Entity("appbeneficiencia.Models.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreaciom")
                        .HasColumnType("datetime");

                    b.Property<string>("NombrePuesto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("appbeneficiencia.Models.RolOperacion", b =>
                {
                    b.Property<int>("IdAsignacionRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsignacionRol"));

                    b.Property<int?>("IdOperacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdAsignacionRol");

                    b.HasIndex("IdOperacion");

                    b.HasIndex("IdRol");

                    b.ToTable("Rol_operacion", (string)null);
                });

            modelBuilder.Entity("appbeneficiencia.Models.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRol")
                        .HasName("PK__Roles__2A49584C9A0BFE90");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Correo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuarios__5B65BF97B476837D");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.AsignacionBeneficio", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Beneficiario", "IdBeneficiarioNavigation")
                        .WithMany("AsignacionBeneficios")
                        .HasForeignKey("IdBeneficiario")
                        .HasConstraintName("FK__Asignacio__IdBen__3B40CD36");

                    b.HasOne("appbeneficiencia.Models.Beneficio", "IdBeneficioNavigation")
                        .WithMany("AsignacionBeneficios")
                        .HasForeignKey("IdBeneficio")
                        .HasConstraintName("FK__Asignacio__IdBen__3C34F16F");

                    b.Navigation("IdBeneficiarioNavigation");

                    b.Navigation("IdBeneficioNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Beneficiario", b =>
                {
                    b.HasOne("appbeneficiencia.Models.PadresDeFamilium", "IdPadreNavigation")
                        .WithMany("Beneficiarios")
                        .HasForeignKey("IdPadre")
                        .HasConstraintName("FK__Beneficia__IdPad__30C33EC3");

                    b.Navigation("IdPadreNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Colaboradore", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Puesto", "IdPuestoNavigation")
                        .WithMany("Colaboradores")
                        .HasForeignKey("IdPuesto")
                        .HasConstraintName("FK_Colaboradores_Puestos");

                    b.Navigation("IdPuestoNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Operacion", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Modulo", "IdModuloNavigation")
                        .WithMany("Operacions")
                        .HasForeignKey("IdModulo")
                        .HasConstraintName("FK_Operacion_Modulo");

                    b.Navigation("IdModuloNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Patrocinio", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Beneficiario", "IdBeneficiarioNavigation")
                        .WithMany("Patrocinios")
                        .HasForeignKey("IdBeneficiario")
                        .HasConstraintName("FK__Patrocini__IdBen__367C1819");

                    b.HasOne("appbeneficiencia.Models.Patrocinadore", "IdPatrocinadorNavigation")
                        .WithMany("Patrocinios")
                        .HasForeignKey("IdPatrocinador")
                        .HasConstraintName("FK__Patrocini__IdPat__3587F3E0");

                    b.Navigation("IdBeneficiarioNavigation");

                    b.Navigation("IdPatrocinadorNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.RolOperacion", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Operacion", "IdOperacionNavigation")
                        .WithMany("RolOperacions")
                        .HasForeignKey("IdOperacion")
                        .HasConstraintName("FK_Rol_operacion_Operacion");

                    b.HasOne("appbeneficiencia.Models.Role", "IdRolNavigation")
                        .WithMany("RolOperacions")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK_Rol_operacion_Roles");

                    b.Navigation("IdOperacionNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Usuario", b =>
                {
                    b.HasOne("appbeneficiencia.Models.Role", "IdRolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK_Usuarios_Roles");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Beneficiario", b =>
                {
                    b.Navigation("AsignacionBeneficios");

                    b.Navigation("Patrocinios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Beneficio", b =>
                {
                    b.Navigation("AsignacionBeneficios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Modulo", b =>
                {
                    b.Navigation("Operacions");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Operacion", b =>
                {
                    b.Navigation("RolOperacions");
                });

            modelBuilder.Entity("appbeneficiencia.Models.PadresDeFamilium", b =>
                {
                    b.Navigation("Beneficiarios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Patrocinadore", b =>
                {
                    b.Navigation("Patrocinios");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Puesto", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("appbeneficiencia.Models.Role", b =>
                {
                    b.Navigation("RolOperacions");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
