using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class Siniestros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emergencias",
                columns: table => new
                {
                    EmergenciaID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarcaElemento = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencias", x => x.EmergenciaID);
                });

            migrationBuilder.CreateTable(
                name: "Siniestros",
                columns: table => new
                {
                    SiniestroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaSiniestro = table.Column<DateTime>(nullable: false),
                    Denunciante = table.Column<string>(maxLength: 50, nullable: true),
                    Damnificado = table.Column<string>(maxLength: 50, nullable: true),
                    DirLocalidad = table.Column<string>(maxLength: 50, nullable: true),
                    EmergenciaID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniestros", x => x.SiniestroID);
                    table.ForeignKey(
                        name: "FK_Siniestros_Emergencias_EmergenciaID",
                        column: x => x.EmergenciaID,
                        principalTable: "Emergencias",
                        principalColumn: "EmergenciaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiniestroComprobantes",
                columns: table => new
                {
                    SiniestroComprobanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiniestroNombre = table.Column<string>(nullable: true),
                    ComprobanteUrl = table.Column<string>(nullable: true),
                    SiniestroID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiniestroComprobantes", x => x.SiniestroComprobanteId);
                    table.ForeignKey(
                        name: "FK_SiniestroComprobantes_Siniestros_SiniestroID",
                        column: x => x.SiniestroID,
                        principalTable: "Siniestros",
                        principalColumn: "SiniestroID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiniestroComprobantes_SiniestroID",
                table: "SiniestroComprobantes",
                column: "SiniestroID");

            migrationBuilder.CreateIndex(
                name: "IX_Siniestros_EmergenciaID",
                table: "Siniestros",
                column: "EmergenciaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiniestroComprobantes");

            migrationBuilder.DropTable(
                name: "Siniestros");

            migrationBuilder.DropTable(
                name: "Emergencias");
        }
    }
}
