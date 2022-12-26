using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class basenube26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "tblEntrenamiento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamiento_ClienteId",
                table: "tblEntrenamiento",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEntrenamiento_AspNetUsers_ClienteId",
                table: "tblEntrenamiento",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEntrenamiento_AspNetUsers_ClienteId",
                table: "tblEntrenamiento");

            migrationBuilder.DropIndex(
                name: "IX_tblEntrenamiento_ClienteId",
                table: "tblEntrenamiento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "tblEntrenamiento");
        }
    }
}
