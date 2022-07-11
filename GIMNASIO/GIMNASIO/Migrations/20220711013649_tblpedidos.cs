using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class tblpedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPedidoEstado",
                columns: table => new
                {
                    PedidoEstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoEstadoNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPedidoEstado", x => x.PedidoEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "tblPedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoFecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<string>(nullable: true),
                    PedidoTotal = table.Column<int>(nullable: false),
                    MetodoPagoId = table.Column<int>(nullable: true),
                    PedidoEstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_tblPedido_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPedido_tblMetodoPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "tblMetodoPago",
                        principalColumn: "MetodoPagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblPedido_tblPedidoEstado_PedidoEstadoId",
                        column: x => x.PedidoEstadoId,
                        principalTable: "tblPedidoEstado",
                        principalColumn: "PedidoEstadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPedidoDetalle",
                columns: table => new
                {
                    PedidoDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPedidoDetalle", x => x.PedidoDetalleId);
                    table.ForeignKey(
                        name: "FK_tblPedidoDetalle_tblPedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "tblPedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPedidoDetalle_tblProductos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "tblProductos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPedido_ClienteId",
                table: "tblPedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPedido_MetodoPagoId",
                table: "tblPedido",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPedido_PedidoEstadoId",
                table: "tblPedido",
                column: "PedidoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPedidoDetalle_PedidoId",
                table: "tblPedidoDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPedidoDetalle_ProductoId",
                table: "tblPedidoDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPedidoDetalle");

            migrationBuilder.DropTable(
                name: "tblPedido");

            migrationBuilder.DropTable(
                name: "tblPedidoEstado");
        }
    }
}
