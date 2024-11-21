using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class mudancaestruturatarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleta",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "CdStatus",
                table: "Tarefas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CdStatus",
                table: "Tarefas");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleta",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
