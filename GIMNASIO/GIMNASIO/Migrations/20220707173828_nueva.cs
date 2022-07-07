using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCarroItem_tblMetodoPago_MetodoPagoId",
                table: "tblCarroItem");

            migrationBuilder.DropIndex(
                name: "IX_tblCarroItem_MetodoPagoId",
                table: "tblCarroItem");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "tblCarroItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "tblCarroItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCarroItem_MetodoPagoId",
                table: "tblCarroItem",
                column: "MetodoPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCarroItem_tblMetodoPago_MetodoPagoId",
                table: "tblCarroItem",
                column: "MetodoPagoId",
                principalTable: "tblMetodoPago",
                principalColumn: "MetodoPagoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
