using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class SiniestroCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarcaElemento",
                table: "Emergencias",
                newName: "TipoEmergencia");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Siniestros",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelDamnificado",
                table: "Siniestros",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelDeununciante",
                table: "Siniestros",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Siniestros");

            migrationBuilder.DropColumn(
                name: "TelDamnificado",
                table: "Siniestros");

            migrationBuilder.DropColumn(
                name: "TelDeununciante",
                table: "Siniestros");

            migrationBuilder.RenameColumn(
                name: "TipoEmergencia",
                table: "Emergencias",
                newName: "MarcaElemento");
        }
    }
}
