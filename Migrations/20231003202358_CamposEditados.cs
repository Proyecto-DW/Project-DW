using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appbeneficiencia.Migrations
{
    /// <inheritdoc />
    public partial class CamposEditados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBeneficiario",
                table: "Patrocinadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrocinadores_IdBeneficiario",
                table: "Patrocinadores",
                column: "IdBeneficiario");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrocinadores_Beneficiarios",
                table: "Patrocinadores",
                column: "IdBeneficiario",
                principalTable: "Beneficiarios",
                principalColumn: "IdBeneficiario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrocinadores_Beneficiarios",
                table: "Patrocinadores");

            migrationBuilder.DropIndex(
                name: "IX_Patrocinadores_IdBeneficiario",
                table: "Patrocinadores");

            migrationBuilder.DropColumn(
                name: "IdBeneficiario",
                table: "Patrocinadores");
        }
    }
}
