using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentosProspectos",
                columns: table => new
                {
                    nDocumentoProspecto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nProspecto = table.Column<int>(type: "INTEGER", nullable: false),
                    cDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    bActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosProspectos", x => x.nDocumentoProspecto);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    nEstatus = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cEstatus = table.Column<string>(type: "TEXT", nullable: false),
                    bActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.nEstatus);
                });

            migrationBuilder.CreateTable(
                name: "Prospectos",
                columns: table => new
                {
                    nProspecto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cNombre = table.Column<string>(type: "TEXT", nullable: false),
                    cApellidoPaterno = table.Column<string>(type: "TEXT", nullable: false),
                    cApellidoMaterno = table.Column<string>(type: "TEXT", nullable: false),
                    cCalle = table.Column<string>(type: "TEXT", nullable: false),
                    cNoExt = table.Column<string>(type: "TEXT", nullable: false),
                    cColonia = table.Column<string>(type: "TEXT", nullable: false),
                    cCodigoPostal = table.Column<string>(type: "TEXT", nullable: false),
                    cTelefono = table.Column<string>(type: "TEXT", nullable: false),
                    cRFC = table.Column<string>(type: "TEXT", nullable: false),
                    nEstatus = table.Column<int>(type: "INTEGER", nullable: false),
                    bActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospectos", x => x.nProspecto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentosProspectos");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "Prospectos");
        }
    }
}
