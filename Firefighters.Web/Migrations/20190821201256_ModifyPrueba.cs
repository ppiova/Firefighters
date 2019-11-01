using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class ModifyPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Areas_AreaId1",
                table: "Elementos");

            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId1",
                table: "Elementos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_AreaId1",
                table: "Elementos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_UbicacionId1",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "AreaId1",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "UbicacionId1",
                table: "Elementos");

            migrationBuilder.AlterColumn<short>(
                name: "UbicacionId",
                table: "Elementos",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "AreaId",
                table: "Elementos",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_AreaId",
                table: "Elementos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_UbicacionId",
                table: "Elementos",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Areas_AreaId",
                table: "Elementos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId",
                table: "Elementos",
                column: "UbicacionId",
                principalTable: "Ubicacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Areas_AreaId",
                table: "Elementos");

            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId",
                table: "Elementos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_AreaId",
                table: "Elementos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_UbicacionId",
                table: "Elementos");

            migrationBuilder.AlterColumn<int>(
                name: "UbicacionId",
                table: "Elementos",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Elementos",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<short>(
                name: "AreaId1",
                table: "Elementos",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "UbicacionId1",
                table: "Elementos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_AreaId1",
                table: "Elementos",
                column: "AreaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_UbicacionId1",
                table: "Elementos",
                column: "UbicacionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Areas_AreaId1",
                table: "Elementos",
                column: "AreaId1",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Ubicacions_UbicacionId1",
                table: "Elementos",
                column: "UbicacionId1",
                principalTable: "Ubicacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
