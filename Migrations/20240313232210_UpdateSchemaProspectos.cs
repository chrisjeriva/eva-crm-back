using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaProspectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cObservacionesRechazo",
                table: "Prospectos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cObservacionesRechazo",
                table: "Prospectos");
        }
    }
}
