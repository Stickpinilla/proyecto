using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class TablasEntrenamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEntrenamientoCategoria",
                columns: table => new
                {
                    EntrenamientoCategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrenamientoCategoria_Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntrenamientoCategoria", x => x.EntrenamientoCategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "tblEntrenamientoEstado",
                columns: table => new
                {
                    EntrenamientoEstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrenamiento_NombreEstado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntrenamientoEstado", x => x.EntrenamientoEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "tblEntrenamientoZona",
                columns: table => new
                {
                    EntrenamientoZonaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrenamientoZona_Nombre = table.Column<string>(nullable: true),
                    EntrenamientoZona_Disponibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntrenamientoZona", x => x.EntrenamientoZonaId);
                });

            migrationBuilder.CreateTable(
                name: "tblEntrenamiento",
                columns: table => new
                {
                    EntrenamientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrenamiento_CupoTotal = table.Column<int>(nullable: false),
                    Entrenamiento_CupoDisponible = table.Column<int>(nullable: false),
                    Entrenamiento_Descripcion = table.Column<string>(nullable: true),
                    EntrenamientoZonaId = table.Column<int>(nullable: false),
                    EntrenamientoEstadoId = table.Column<int>(nullable: false),
                    EntrenamientoCategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEntrenamiento", x => x.EntrenamientoId);
                    table.ForeignKey(
                        name: "FK_tblEntrenamiento_tblEntrenamientoCategoria_EntrenamientoCategoriaId",
                        column: x => x.EntrenamientoCategoriaId,
                        principalTable: "tblEntrenamientoCategoria",
                        principalColumn: "EntrenamientoCategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEntrenamiento_tblEntrenamientoEstado_EntrenamientoEstadoId",
                        column: x => x.EntrenamientoEstadoId,
                        principalTable: "tblEntrenamientoEstado",
                        principalColumn: "EntrenamientoEstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEntrenamiento_tblEntrenamientoZona_EntrenamientoZonaId",
                        column: x => x.EntrenamientoZonaId,
                        principalTable: "tblEntrenamientoZona",
                        principalColumn: "EntrenamientoZonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamiento_EntrenamientoCategoriaId",
                table: "tblEntrenamiento",
                column: "EntrenamientoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamiento_EntrenamientoEstadoId",
                table: "tblEntrenamiento",
                column: "EntrenamientoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamiento_EntrenamientoZonaId",
                table: "tblEntrenamiento",
                column: "EntrenamientoZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEntrenamiento");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoCategoria");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoEstado");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoZona");
        }
    }
}
