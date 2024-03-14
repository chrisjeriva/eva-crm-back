using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos");

            migrationBuilder.AddColumn<string>(
                name: "cDocumentoB64",
                table: "DocumentosProspectos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos",
                column: "nEstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos");

            migrationBuilder.DropColumn(
                name: "cDocumentoB64",
                table: "DocumentosProspectos");

            migrationBuilder.CreateIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos",
                column: "nEstatus",
                unique: true);
        }
    }
}
