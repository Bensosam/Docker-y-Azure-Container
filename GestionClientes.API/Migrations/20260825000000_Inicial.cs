using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionClientes.API.Migrations;

public partial class Inicial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Clientes",
            columns: table => new
            {
                Id_cliente = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CUI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                NIT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Fecha_Nacimiento = table.Column<DateTime>(type: "date", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clientes", x => x.Id_cliente);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Clientes");
    }
}
