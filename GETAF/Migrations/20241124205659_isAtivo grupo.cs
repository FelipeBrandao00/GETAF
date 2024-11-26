using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class isAtivogrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Grupos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Grupos");
        }
    }
}
