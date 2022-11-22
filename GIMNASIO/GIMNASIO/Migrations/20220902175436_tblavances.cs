using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class tblavances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAvanceCliente",
                columns: table => new
                {
                    AvanceClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvanceCliente_Peso = table.Column<double>(nullable: false),
                    AvanceCliente_Altura = table.Column<double>(nullable: false),
                    AvanceCliente_IMC = table.Column<float>(nullable: false),
                    AvanceCliente_Situacion = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAvanceCliente", x => x.AvanceClienteId);
                    table.ForeignKey(
                        name: "FK_tblAvanceCliente_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAvanceCliente_ClienteId",
                table: "tblAvanceCliente",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAvanceCliente");
        }
    }
}
