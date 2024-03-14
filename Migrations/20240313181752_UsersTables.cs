using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class UsersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    nAuthority = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.nAuthority);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    nUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    activated = table.Column<bool>(type: "INTEGER", nullable: false),
                    langKey = table.Column<string>(type: "TEXT", nullable: false),
                    nAuthority = table.Column<int>(type: "INTEGER", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.nUsuario);
                    table.ForeignKey(
                        name: "FK_Users_Authorities_nAuthority",
                        column: x => x.nAuthority,
                        principalTable: "Authorities",
                        principalColumn: "nAuthority",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_nAuthority",
                table: "Users",
                column: "nAuthority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authorities");
        }
    }
}
