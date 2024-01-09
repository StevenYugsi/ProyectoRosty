using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRosty.Migrations
{
    /// <inheritdoc />
    public partial class Librerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bodegas",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeContratacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "GestionDeGaseosas",
                columns: table => new
                {
                    IdGestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionDeGaseosas", x => x.IdGestion);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    idEmpleado = table.Column<int>(type: "int", nullable: false),
                    rolesIdRol = table.Column<int>(type: "int", nullable: false),
                    empleadosIdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_empleados_empleadosIdEmpleado",
                        column: x => x.empleadosIdEmpleado,
                        principalTable: "empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_roles_rolesIdRol",
                        column: x => x.rolesIdRol,
                        principalTable: "roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    rolesIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rolesIdRol",
                        column: x => x.rolesIdRol,
                        principalTable: "roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDeVentas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentasDiarias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idGestion = table.Column<int>(type: "int", nullable: false),
                    BodegaIdProducto = table.Column<int>(type: "int", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    GestionDeGaseosasIdGestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDeVentas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_RegistroDeVentas_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroDeVentas_GestionDeGaseosas_GestionDeGaseosasIdGestion",
                        column: x => x.GestionDeGaseosasIdGestion,
                        principalTable: "GestionDeGaseosas",
                        principalColumn: "IdGestion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroDeVentas_bodegas_BodegaIdProducto",
                        column: x => x.BodegaIdProducto,
                        principalTable: "bodegas",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_empleadosIdEmpleado",
                table: "Clientes",
                column: "empleadosIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_rolesIdRol",
                table: "Clientes",
                column: "rolesIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDeVentas_BodegaIdProducto",
                table: "RegistroDeVentas",
                column: "BodegaIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDeVentas_ClienteIdCliente",
                table: "RegistroDeVentas",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDeVentas_GestionDeGaseosasIdGestion",
                table: "RegistroDeVentas",
                column: "GestionDeGaseosasIdGestion");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rolesIdRol",
                table: "usuarios",
                column: "rolesIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroDeVentas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "GestionDeGaseosas");

            migrationBuilder.DropTable(
                name: "bodegas");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
