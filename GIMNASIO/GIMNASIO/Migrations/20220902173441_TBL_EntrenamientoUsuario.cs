using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class TBL_EntrenamientoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEntrenamientoUsuario",
                columns: table => new
                {
                    EntrenamientoUsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(nullable: true),
                    EntrenamientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntrenamientoUsuario", x => x.EntrenamientoUsuarioId);
                    table.ForeignKey(
                        name: "FK_tblEntrenamientoUsuario_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblEntrenamientoUsuario_tblEntrenamiento_EntrenamientoId",
                        column: x => x.EntrenamientoId,
                        principalTable: "tblEntrenamiento",
                        principalColumn: "EntrenamientoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamientoUsuario_ClienteId",
                table: "tblEntrenamientoUsuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamientoUsuario_EntrenamientoId",
                table: "tblEntrenamientoUsuario",
                column: "EntrenamientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEntrenamientoUsuario");
        }
    }
}
