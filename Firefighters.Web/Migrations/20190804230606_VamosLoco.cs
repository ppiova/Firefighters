using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firefighters.Web.Migrations
{
    public partial class VamosLoco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacions",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UbicacionElemento = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elementos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(maxLength: 50, nullable: true),
                    Marca = table.Column<string>(maxLength: 50, nullable: true),
                    NroSerie = table.Column<string>(maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    FabricacionFecha = table.Column<DateTime>(nullable: true),
                    CompraFecha = table.Column<DateTime>(nullable: true),
                    VencimientoFecha = table.Column<DateTime>(nullable: true),
                    Observaciones = table.Column<string>(maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    BajaFecha = table.Column<DateTime>(nullable: true),
                    AreaId = table.Column<short>(nullable: true),
                    UbicacionId = table.Column<short>(nullable: true),
                    IdEstado = table.Column<short>(nullable: false),
                    IdTitular = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elementos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elementos_Ubicacions_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_AreaId",
                table: "Elementos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elementos_UbicacionId",
                table: "Elementos",
                column: "UbicacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elementos");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Ubicacions");
        }
    }
}
