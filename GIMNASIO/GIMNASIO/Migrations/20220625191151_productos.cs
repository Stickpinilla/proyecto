using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoNombre = table.Column<string>(nullable: true),
                    ProductoPrecio = table.Column<int>(nullable: false),
                    ProductoDesc = table.Column<string>(nullable: true),
                    imagen = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_tblProductos_tblCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tblCategorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProductos_tblEstados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "tblEstados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_CategoriaId",
                table: "tblProductos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_EstadoId",
                table: "tblProductos",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductos");
        }
    }
}
