using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appbeneficiencia.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Patrocinadores");

            migrationBuilder.RenameColumn(
                name: "FechaCreaciom",
                table: "Puestos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Patrocinadores",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Patrocinadores",
                newName: "CodigoPais");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento_Beneficiario",
                table: "Patrocinadores",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreBeneficiario",
                table: "Patrocinadores",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soporte",
                table: "Patrocinadores",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoporteBenneficiariosRegistrados",
                table: "Patrocinadores",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DPIMadre",
                table: "PadresDeFamilia",
                type: "nchar(13)",
                fixedLength: true,
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DPIPadre",
                table: "PadresDeFamilia",
                type: "nchar(13)",
                fixedLength: true,
                maxLength: 13,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Modulo",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Beneficiarios",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdColaborador",
                table: "Beneficiarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Beneficiarios",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DPI",
                table: "AsignacionBeneficios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionBeneficio",
                table: "AsignacionBeneficios",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaRecibido",
                table: "AsignacionBeneficios",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "AsignacionBeneficios",
                type: "decimal(20,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parentesco",
                table: "AsignacionBeneficios",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_IdColaborador",
                table: "Beneficiarios",
                column: "IdColaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_Colaboradores",
                table: "Beneficiarios",
                column: "IdColaborador",
                principalTable: "Colaboradores",
                principalColumn: "IdColaborador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_Colaboradores",
                table: "Beneficiarios");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiarios_IdColaborador",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento_Beneficiario",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "NombreBeneficiario",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "Soporte",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "SoporteBenneficiariosRegistrados",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "DPIMadre",
                table: "PadresDeFamilia");

            migrationBuilder.DropColumn(
                name: "DPIPadre",
                table: "PadresDeFamilia");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "IdColaborador",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "DPI",
                table: "AsignacionBeneficios");

            migrationBuilder.DropColumn(
                name: "DescripcionBeneficio",
                table: "AsignacionBeneficios");

            migrationBuilder.DropColumn(
                name: "FirmaRecibido",
                table: "AsignacionBeneficios");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "AsignacionBeneficios");

            migrationBuilder.DropColumn(
                name: "Parentesco",
                table: "AsignacionBeneficios");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Puestos",
                newName: "FechaCreaciom");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Patrocinadores",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "CodigoPais",
                table: "Patrocinadores",
                newName: "Correo");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Patrocinadores",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Patrocinadores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Patrocinadores",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Modulo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "('0001-01-01T00:00:00.0000000')");
        }
    }
}
