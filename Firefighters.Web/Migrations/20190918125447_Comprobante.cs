using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class Comprobante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementoComprobantes",
                columns: table => new
                {
                    ElementoComprobanteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComprobanteUrl = table.Column<string>(nullable: true),
                    ElementoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoComprobantes", x => x.ElementoComprobanteId);
                    table.ForeignKey(
                        name: "FK_ElementoComprobantes_Elementos_ElementoID",
                        column: x => x.ElementoID,
                        principalTable: "Elementos",
                        principalColumn: "ElementoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementoComprobantes_ElementoID",
                table: "ElementoComprobantes",
                column: "ElementoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementoComprobantes");
        }
    }
}
