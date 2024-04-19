using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barberia.Migrations
{
    /// <inheritdoc />
    public partial class Compra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "CompraDetalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "CompraDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
