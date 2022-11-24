using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GIMNASIO.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Rut = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    ApellidoP = table.Column<string>(nullable: true),
                    ApellidoM = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCategorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategorias", x => x.CategoriaId);
                });

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
                name: "tblEstadoMantencion",
                columns: table => new
                {
                    EstadoMantencionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoMantencionNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEstadoMantencion", x => x.EstadoMantencionId);
                });

            migrationBuilder.CreateTable(
                name: "tblEstadoMaquinaria",
                columns: table => new
                {
                    EstadoMaquinariaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoMaquinariaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEstadoMaquinaria", x => x.EstadoMaquinariaId);
                });

            migrationBuilder.CreateTable(
                name: "tblEstadoMembresia",
                columns: table => new
                {
                    EstadoMembresiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoMembresiaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEstadoMembresia", x => x.EstadoMembresiaId);
                });

            migrationBuilder.CreateTable(
                name: "tblEstados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEstados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "tblMetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "tblMetodoPagoMembresia",
                columns: table => new
                {
                    MetodoPagoMembresiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPagoMembresiaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMetodoPagoMembresia", x => x.MetodoPagoMembresiaId);
                });

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
                name: "tblTipoMaquinaria",
                columns: table => new
                {
                    TipoMaquinariaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMaquinariaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipoMaquinaria", x => x.TipoMaquinariaId);
                });

            migrationBuilder.CreateTable(
                name: "tblTipoMembresia",
                columns: table => new
                {
                    TipoMembresiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMembresiaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipoMembresia", x => x.TipoMembresiaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAvanceCliente",
                columns: table => new
                {
                    AvanceClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvanceCliente_Peso = table.Column<double>(nullable: false),
                    AvanceCliente_Altura = table.Column<double>(nullable: false),
                    AvanceCliente_IMC = table.Column<float>(nullable: false),
                    AvanceCliente_Fecha = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "tblEntrenamiento",
                columns: table => new
                {
                    EntrenamientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrenamientoCupoTotal = table.Column<int>(nullable: false),
                    EntrenamientoCupoDisponible = table.Column<int>(nullable: false),
                    EntrenamientoDescripcion = table.Column<string>(nullable: true),
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
                    PedidoEstadoId = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMaquinaria",
                columns: table => new
                {
                    MaquinariaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaquinariaNombre = table.Column<string>(nullable: true),
                    MaquinariaNumeroSerie = table.Column<string>(nullable: true),
                    MaquinariaEstadoId = table.Column<int>(nullable: false),
                    EstadoMaquinariaId = table.Column<int>(nullable: true),
                    MaquinariaTipoId = table.Column<int>(nullable: false),
                    TipoMaquinariaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaquinaria", x => x.MaquinariaId);
                    table.ForeignKey(
                        name: "FK_tblMaquinaria_tblEstadoMaquinaria_EstadoMaquinariaId",
                        column: x => x.EstadoMaquinariaId,
                        principalTable: "tblEstadoMaquinaria",
                        principalColumn: "EstadoMaquinariaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMaquinaria_tblTipoMaquinaria_TipoMaquinariaId",
                        column: x => x.TipoMaquinariaId,
                        principalTable: "tblTipoMaquinaria",
                        principalColumn: "TipoMaquinariaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblMembresia",
                columns: table => new
                {
                    MembresiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaComienzo = table.Column<DateTime>(nullable: false),
                    FechaTermino = table.Column<DateTime>(nullable: false),
                    EstadoMembresiaId = table.Column<int>(nullable: true),
                    TipoMembresiaId = table.Column<int>(nullable: true),
                    MetodoPagoMembresiaId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMembresia", x => x.MembresiaId);
                    table.ForeignKey(
                        name: "FK_tblMembresia_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMembresia_tblEstadoMembresia_EstadoMembresiaId",
                        column: x => x.EstadoMembresiaId,
                        principalTable: "tblEstadoMembresia",
                        principalColumn: "EstadoMembresiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMembresia_tblMetodoPagoMembresia_MetodoPagoMembresiaId",
                        column: x => x.MetodoPagoMembresiaId,
                        principalTable: "tblMetodoPagoMembresia",
                        principalColumn: "MetodoPagoMembresiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMembresia_tblTipoMembresia_TipoMembresiaId",
                        column: x => x.TipoMembresiaId,
                        principalTable: "tblTipoMembresia",
                        principalColumn: "TipoMembresiaId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "tblCarroItem",
                columns: table => new
                {
                    CarroItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroCantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    CarroCompraId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarroItem", x => x.CarroItemId);
                    table.ForeignKey(
                        name: "FK_tblCarroItem_tblProductos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "tblProductos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "tblMantencion",
                columns: table => new
                {
                    MantencionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MantencionFechaIngreso = table.Column<DateTime>(nullable: false),
                    MantencionFechaFin = table.Column<DateTime>(nullable: false),
                    MantencionProcedimiento = table.Column<string>(nullable: true),
                    MantencionEstadoId = table.Column<int>(nullable: false),
                    EstadoMantencionId = table.Column<int>(nullable: true),
                    MantencionMaquinariaId = table.Column<int>(nullable: false),
                    MaquinariaId = table.Column<int>(nullable: true),
                    MantencionEncargadoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMantencion", x => x.MantencionId);
                    table.ForeignKey(
                        name: "FK_tblMantencion_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMantencion_tblEstadoMantencion_EstadoMantencionId",
                        column: x => x.EstadoMantencionId,
                        principalTable: "tblEstadoMantencion",
                        principalColumn: "EstadoMantencionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMantencion_tblMaquinaria_MaquinariaId",
                        column: x => x.MaquinariaId,
                        principalTable: "tblMaquinaria",
                        principalColumn: "MaquinariaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblAvanceCliente_ClienteId",
                table: "tblAvanceCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarroItem_ProductoId",
                table: "tblCarroItem",
                column: "ProductoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamientoUsuario_ClienteId",
                table: "tblEntrenamientoUsuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEntrenamientoUsuario_EntrenamientoId",
                table: "tblEntrenamientoUsuario",
                column: "EntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMantencion_ClienteId",
                table: "tblMantencion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMantencion_EstadoMantencionId",
                table: "tblMantencion",
                column: "EstadoMantencionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMantencion_MaquinariaId",
                table: "tblMantencion",
                column: "MaquinariaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinaria_EstadoMaquinariaId",
                table: "tblMaquinaria",
                column: "EstadoMaquinariaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinaria_TipoMaquinariaId",
                table: "tblMaquinaria",
                column: "TipoMaquinariaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembresia_ClienteId",
                table: "tblMembresia",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembresia_EstadoMembresiaId",
                table: "tblMembresia",
                column: "EstadoMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembresia_MetodoPagoMembresiaId",
                table: "tblMembresia",
                column: "MetodoPagoMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMembresia_TipoMembresiaId",
                table: "tblMembresia",
                column: "TipoMembresiaId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tblAvanceCliente");

            migrationBuilder.DropTable(
                name: "tblCarroItem");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoUsuario");

            migrationBuilder.DropTable(
                name: "tblMantencion");

            migrationBuilder.DropTable(
                name: "tblMembresia");

            migrationBuilder.DropTable(
                name: "tblPedidoDetalle");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblEntrenamiento");

            migrationBuilder.DropTable(
                name: "tblEstadoMantencion");

            migrationBuilder.DropTable(
                name: "tblMaquinaria");

            migrationBuilder.DropTable(
                name: "tblEstadoMembresia");

            migrationBuilder.DropTable(
                name: "tblMetodoPagoMembresia");

            migrationBuilder.DropTable(
                name: "tblTipoMembresia");

            migrationBuilder.DropTable(
                name: "tblPedido");

            migrationBuilder.DropTable(
                name: "tblProductos");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoCategoria");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoEstado");

            migrationBuilder.DropTable(
                name: "tblEntrenamientoZona");

            migrationBuilder.DropTable(
                name: "tblEstadoMaquinaria");

            migrationBuilder.DropTable(
                name: "tblTipoMaquinaria");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblMetodoPago");

            migrationBuilder.DropTable(
                name: "tblPedidoEstado");

            migrationBuilder.DropTable(
                name: "tblCategorias");

            migrationBuilder.DropTable(
                name: "tblEstados");
        }
    }
}
