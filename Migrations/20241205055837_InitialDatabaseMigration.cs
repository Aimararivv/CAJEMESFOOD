using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CajemesFoodAlejandro_Aimara.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Platillos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    caducidad = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Administradorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locals_Administradores_Administradorid",
                        column: x => x.Administradorid,
                        principalTable: "Administradores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Local_Platillo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localid = table.Column<int>(type: "int", nullable: false),
                    Platilloid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local_Platillo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Local_Platillo_Locals_Localid",
                        column: x => x.Localid,
                        principalTable: "Locals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Local_Platillo_Platillos_Platilloid",
                        column: x => x.Platilloid,
                        principalTable: "Platillos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Local_Platillo_Localid",
                table: "Local_Platillo",
                column: "Localid");

            migrationBuilder.CreateIndex(
                name: "IX_Local_Platillo_Platilloid",
                table: "Local_Platillo",
                column: "Platilloid");

            migrationBuilder.CreateIndex(
                name: "IX_Locals_Administradorid",
                table: "Locals",
                column: "Administradorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Local_Platillo");

            migrationBuilder.DropTable(
                name: "Locals");

            migrationBuilder.DropTable(
                name: "Platillos");

            migrationBuilder.DropTable(
                name: "Administradores");
        }
    }
}
