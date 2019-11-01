using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class InventarioAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Areas_AreaId",
                table: "Elementos");

            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId",
                table: "Elementos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicacions",
                table: "Ubicacions");

            migrationBuilder.RenameTable(
                name: "Ubicacions",
                newName: "Ubicaciones");

            migrationBuilder.RenameColumn(
                name: "UbicacionId",
                table: "Elementos",
                newName: "UbicacionID");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Elementos",
                newName: "AreaID");

            migrationBuilder.RenameColumn(
                name: "IdTitulares",
                table: "Elementos",
                newName: "IdTitular");

            migrationBuilder.RenameColumn(
                name: "IdEstados",
                table: "Elementos",
                newName: "IdEstado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Elementos",
                newName: "ElementoID");

            migrationBuilder.RenameIndex(
                name: "IX_Elementos_UbicacionId",
                table: "Elementos",
                newName: "IX_Elementos_UbicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_Elementos_AreaId",
                table: "Elementos",
                newName: "IX_Elementos_AreaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Areas",
                newName: "AreaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ubicaciones",
                newName: "UbicacionID");

            migrationBuilder.AddColumn<bool>(
                name: "LlevaInventario",
                table: "Areas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicaciones",
                table: "Ubicaciones",
                column: "UbicacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Areas_AreaID",
                table: "Elementos",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Ubicaciones_UbicacionID",
                table: "Elementos",
                column: "UbicacionID",
                principalTable: "Ubicaciones",
                principalColumn: "UbicacionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Areas_AreaID",
                table: "Elementos");

            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Ubicaciones_UbicacionID",
                table: "Elementos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicaciones",
                table: "Ubicaciones");

            migrationBuilder.DropColumn(
                name: "LlevaInventario",
                table: "Areas");

            migrationBuilder.RenameTable(
                name: "Ubicaciones",
                newName: "Ubicacions");

            migrationBuilder.RenameColumn(
                name: "UbicacionID",
                table: "Elementos",
                newName: "UbicacionId");

            migrationBuilder.RenameColumn(
                name: "AreaID",
                table: "Elementos",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "IdTitular",
                table: "Elementos",
                newName: "IdTitulares");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Elementos",
                newName: "IdEstados");

            migrationBuilder.RenameColumn(
                name: "ElementoID",
                table: "Elementos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Elementos_UbicacionID",
                table: "Elementos",
                newName: "IX_Elementos_UbicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Elementos_AreaID",
                table: "Elementos",
                newName: "IX_Elementos_AreaId");

            migrationBuilder.RenameColumn(
                name: "AreaID",
                table: "Areas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UbicacionID",
                table: "Ubicacions",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicacions",
                table: "Ubicacions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Areas_AreaId",
                table: "Elementos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId",
                table: "Elementos",
                column: "UbicacionId",
                principalTable: "Ubicacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
