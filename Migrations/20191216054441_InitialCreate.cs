using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NgNetCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    NombreCompleto = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    NumeroMatricula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Departamento = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.NumeroMatricula);
                });

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NumeroCuotas = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ValorCredito = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creditos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arriendos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteIdentificacion = table.Column<string>(nullable: false),
                    InmuebleNumeroMatricula = table.Column<string>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    ValorContrato = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arriendos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arriendos_Clientes_ClienteIdentificacion",
                        column: x => x.ClienteIdentificacion,
                        principalTable: "Clientes",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arriendos_Inmuebles_InmuebleNumeroMatricula",
                        column: x => x.InmuebleNumeroMatricula,
                        principalTable: "Inmuebles",
                        principalColumn: "NumeroMatricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuota = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ValorCuota = table.Column<decimal>(nullable: false),
                    SaldoCuota = table.Column<decimal>(nullable: false),
                    CreditoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuota_Creditos_CreditoId",
                        column: x => x.CreditoId,
                        principalTable: "Creditos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arriendos_ClienteIdentificacion",
                table: "Arriendos",
                column: "ClienteIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Arriendos_InmuebleNumeroMatricula",
                table: "Arriendos",
                column: "InmuebleNumeroMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_ClienteId",
                table: "Creditos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_CreditoId",
                table: "Cuota",
                column: "CreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arriendos");

            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
