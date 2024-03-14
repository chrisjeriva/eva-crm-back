using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prospectos.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
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
                name: "DocumentosProspectos",
                columns: table => new
                {
                    nDocumentoProspecto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nProspecto = table.Column<int>(type: "INTEGER", nullable: false),
                    cDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    cDocumentoB64 = table.Column<string>(type: "TEXT", nullable: false),
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
                    bActivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    cObservacionesRechazo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospectos", x => x.nProspecto);
                    table.ForeignKey(
                        name: "FK_Prospectos_Estatus_nEstatus",
                        column: x => x.nEstatus,
                        principalTable: "Estatus",
                        principalColumn: "nEstatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospectos_nEstatus",
                table: "Prospectos",
                column: "nEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Users_nAuthority",
                table: "Users",
                column: "nAuthority");

            migrationBuilder.Sql("INSERT INTO Authorities(name) Values('ROLE_ADMIN')");
            migrationBuilder.Sql("INSERT INTO Authorities(name) Values('ROLE_PROMOTOR')");
            migrationBuilder.Sql("INSERT INTO Authorities(name) Values('ROLE_EVALUADOR')");

            migrationBuilder.Sql("INSERT INTO Users(login, firstName, lastName, email, activated, langKey, nAuthority, password, imageUrl) " +
                                            "Values('admin', 'Christian', 'Rivera', 'iscchristianrivera@gmail.com', true, 'es', 1, 'admin', '')");
            migrationBuilder.Sql("INSERT INTO Users(login, firstName, lastName, email, activated, langKey, nAuthority, password, imageUrl) " +
                                            "Values('promotor', 'Armando', 'Varela', 'promotor@mail.com', true, 'es', 1, 'promotor00', '')");
            migrationBuilder.Sql("INSERT INTO Users(login, firstName, lastName, email, activated, langKey, nAuthority, password, imageUrl) " +
                                            "Values('evaluador', 'Jessica', 'Castro', 'evaluadora@mail.com', true, 'es', 1, 'evaluador00', '')");

            migrationBuilder.Sql("INSERT INTO Estatus(cEstatus, bActivo) Values('Enviado', true)");
            migrationBuilder.Sql("INSERT INTO Estatus(cEstatus, bActivo) Values('Autorizado', true)");
            migrationBuilder.Sql("INSERT INTO Estatus(cEstatus, bActivo) Values('Rechazado', true)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentosProspectos");

            migrationBuilder.DropTable(
                name: "Prospectos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "Authorities");
        }
    }
}
