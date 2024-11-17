using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class dificuldadepergunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dificuldade",
                table: "Perguntas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dificuldade",
                table: "Perguntas");
        }
    }
}
