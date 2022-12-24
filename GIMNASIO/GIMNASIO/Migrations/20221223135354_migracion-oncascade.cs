using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class migraciononcascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMantencion_AspNetUsers_ClienteId",
                table: "tblMantencion");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPedido_AspNetUsers_ClienteId",
                table: "tblPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMantencion_AspNetUsers_ClienteId",
                table: "tblMantencion",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPedido_AspNetUsers_ClienteId",
                table: "tblPedido",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMantencion_AspNetUsers_ClienteId",
                table: "tblMantencion");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPedido_AspNetUsers_ClienteId",
                table: "tblPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMantencion_AspNetUsers_ClienteId",
                table: "tblMantencion",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPedido_AspNetUsers_ClienteId",
                table: "tblPedido",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
