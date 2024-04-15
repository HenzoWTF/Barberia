using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barberia.Migrations
{
    /// <inheritdoc />
    public partial class cobro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cobrada",
                table: "Facturas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cobrada",
                table: "Facturas");
        }
    }
}
