using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class estruturatarefaremovendomateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Materias_MateriaId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_MateriaId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Tarefas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_MateriaId",
                table: "Tarefas",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Materias_MateriaId",
                table: "Tarefas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
