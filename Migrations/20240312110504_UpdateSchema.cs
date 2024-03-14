using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos",
                column: "nEstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos",
                column: "nEstatus");
        }
    }
}
