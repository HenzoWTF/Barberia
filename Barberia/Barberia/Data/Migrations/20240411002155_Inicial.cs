using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barberia.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbero",
                columns: table => new
                {
                    BarberoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<float>(type: "real", nullable: false),
                    Comision = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbero", x => x.BarberoId);
                });

            migrationBuilder.CreateTable(
                name: "Peladas",
                columns: table => new
                {
                    peladasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    peladasName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioPelada = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peladas", x => x.peladasId);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Pagado = table.Column<float>(type: "real", nullable: false),
                    devuelta = table.Column<float>(type: "real", nullable: false),
                    BarberoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Facturas_Barbero_BarberoId",
                        column: x => x.BarberoId,
                        principalTable: "Barbero",
                        principalColumn: "BarberoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_BarberoId",
                table: "Facturas",
                column: "BarberoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Peladas");

            migrationBuilder.DropTable(
                name: "Barbero");
        }
    }
}
