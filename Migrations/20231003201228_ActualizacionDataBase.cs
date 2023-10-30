using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appbeneficiencia.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficios",
                columns: table => new
                {
                    IdBeneficio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Benefici__14B7CA0CCD1E7583", x => x.IdBeneficio);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdModulo);
                });

            migrationBuilder.CreateTable(
                name: "PadresDeFamilia",
                columns: table => new
                {
                    IdPadre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApellidoPadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TelefonoPadre = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    NombreMadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ApellidosMadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TelefonoMadre = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DireccionPadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DireccionMadre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PadresDe__045356902EEAB2E3", x => x.IdPadre);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinadores",
                columns: table => new
                {
                    IdPatrocinador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Contacto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patrocin__FCC34B4F45E077C3", x => x.IdPatrocinador);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePuesto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaCreaciom = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__2A49584C9A0BFE90", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdModulo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.IdOperacion);
                    table.ForeignKey(
                        name: "FK_Operacion_Modulo",
                        column: x => x.IdModulo,
                        principalTable: "Modulo",
                        principalColumn: "IdModulo");
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    IdBeneficiario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    IdPadre = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Benefici__3D23355FCE2D3011", x => x.IdBeneficiario);
                    table.ForeignKey(
                        name: "FK__Beneficia__IdPad__30C33EC3",
                        column: x => x.IdPadre,
                        principalTable: "PadresDeFamilia",
                        principalColumn: "IdPadre");
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    IdColaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DPI = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdPuesto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Colabora__3D2CA512B04CA523", x => x.IdColaborador);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Puestos",
                        column: x => x.IdPuesto,
                        principalTable: "Puestos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Clave = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__5B65BF97B476837D", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Rol_operacion",
                columns: table => new
                {
                    IdAsignacionRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdOperacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_operacion", x => x.IdAsignacionRol);
                    table.ForeignKey(
                        name: "FK_Rol_operacion_Operacion",
                        column: x => x.IdOperacion,
                        principalTable: "Operacion",
                        principalColumn: "IdOperacion");
                    table.ForeignKey(
                        name: "FK_Rol_operacion_Roles",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "AsignacionBeneficios",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBeneficiario = table.Column<int>(type: "int", nullable: true),
                    IdBeneficio = table.Column<int>(type: "int", nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asignaci__A7235DFF8A358FB8", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK__Asignacio__IdBen__3B40CD36",
                        column: x => x.IdBeneficiario,
                        principalTable: "Beneficiarios",
                        principalColumn: "IdBeneficiario");
                    table.ForeignKey(
                        name: "FK__Asignacio__IdBen__3C34F16F",
                        column: x => x.IdBeneficio,
                        principalTable: "Beneficios",
                        principalColumn: "IdBeneficio");
                });

            migrationBuilder.CreateTable(
                name: "Patrocinio",
                columns: table => new
                {
                    IdPatrocinio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatrocinador = table.Column<int>(type: "int", nullable: true),
                    IdBeneficiario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patrocin__C2F5DE5E7D4509C1", x => x.IdPatrocinio);
                    table.ForeignKey(
                        name: "FK__Patrocini__IdBen__367C1819",
                        column: x => x.IdBeneficiario,
                        principalTable: "Beneficiarios",
                        principalColumn: "IdBeneficiario");
                    table.ForeignKey(
                        name: "FK__Patrocini__IdPat__3587F3E0",
                        column: x => x.IdPatrocinador,
                        principalTable: "Patrocinadores",
                        principalColumn: "IdPatrocinador");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionBeneficios_IdBeneficiario",
                table: "AsignacionBeneficios",
                column: "IdBeneficiario");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionBeneficios_IdBeneficio",
                table: "AsignacionBeneficios",
                column: "IdBeneficio");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_IdPadre",
                table: "Beneficiarios",
                column: "IdPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_IdPuesto",
                table: "Colaboradores",
                column: "IdPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_IdModulo",
                table: "Operacion",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Patrocinio_IdBeneficiario",
                table: "Patrocinio",
                column: "IdBeneficiario");

            migrationBuilder.CreateIndex(
                name: "IX_Patrocinio_IdPatrocinador",
                table: "Patrocinio",
                column: "IdPatrocinador");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_operacion_IdOperacion",
                table: "Rol_operacion",
                column: "IdOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_operacion_IdRol",
                table: "Rol_operacion",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionBeneficios");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Patrocinio");

            migrationBuilder.DropTable(
                name: "Rol_operacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Beneficios");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Patrocinadores");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PadresDeFamilia");

            migrationBuilder.DropTable(
                name: "Modulo");
        }
    }
}
