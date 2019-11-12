using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class ElementosModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Elementos");

            migrationBuilder.AddColumn<short>(
                name: "MarcaID",
                table: "Elementos",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ModeloID",
                table: "Elementos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComprobanteNombre",
                table: "ElementoComprobantes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarcaElemento = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModeloElemento = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_MarcaID",
                table: "Elementos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_ModeloID",
                table: "Elementos",
                column: "ModeloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Marcas_MarcaID",
                table: "Elementos",
                column: "MarcaID",
                principalTable: "Marcas",
                principalColumn: "MarcaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Elementos_Modelos_ModeloID",
                table: "Elementos",
                column: "ModeloID",
                principalTable: "Modelos",
                principalColumn: "ModeloID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Marcas_MarcaID",
                table: "Elementos");

            migrationBuilder.DropForeignKey(
                name: "FK_Elementos_Modelos_ModeloID",
                table: "Elementos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_MarcaID",
                table: "Elementos");

            migrationBuilder.DropIndex(
                name: "IX_Elementos_ModeloID",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "MarcaID",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "ModeloID",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "ComprobanteNombre",
                table: "ElementoComprobantes");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Elementos",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Elementos",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Elementos",
                maxLength: 50,
                nullable: true);
        }
    }
}
