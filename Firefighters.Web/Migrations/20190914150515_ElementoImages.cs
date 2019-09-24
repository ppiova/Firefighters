using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class ElementoImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "IdTitular",
                table: "Elementos");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Elementos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Titular",
                table: "Elementos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElementoImages",
                columns: table => new
                {
                    ElementoImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    ElementoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoImages", x => x.ElementoImageId);
                    table.ForeignKey(
                        name: "FK_ElementoImages_Elementos_ElementoID",
                        column: x => x.ElementoID,
                        principalTable: "Elementos",
                        principalColumn: "ElementoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementoImages_ElementoID",
                table: "ElementoImages",
                column: "ElementoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementoImages");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Elementos");

            migrationBuilder.DropColumn(
                name: "Titular",
                table: "Elementos");

            migrationBuilder.AddColumn<short>(
                name: "IdEstado",
                table: "Elementos",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "IdTitular",
                table: "Elementos",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
