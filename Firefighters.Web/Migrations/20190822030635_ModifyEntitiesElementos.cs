using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class ModifyEntitiesElementos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTitular",
                table: "Elementos",
                newName: "IdTitulares");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Elementos",
                newName: "IdEstados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTitulares",
                table: "Elementos",
                newName: "IdTitular");

            migrationBuilder.RenameColumn(
                name: "IdEstados",
                table: "Elementos",
                newName: "IdEstado");
        }
    }
}
