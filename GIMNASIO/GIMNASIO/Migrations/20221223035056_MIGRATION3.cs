using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class MIGRATION3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMembresia_AspNetUsers_ClienteId",
                table: "tblMembresia",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
