using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations {
    /// <inheritdoc />
    public partial class correcaotarefa : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int>(
                name: "DificuldadeId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_DificuldadeId",
                table: "Tarefas",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_MateriaId",
                table: "Tarefas",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Dificuldades_DificuldadeId",
                table: "Tarefas",
                column: "DificuldadeId",
                principalTable: "Dificuldades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Materias_MateriaId",
                table: "Tarefas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Dificuldades_DificuldadeId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Materias_MateriaId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_DificuldadeId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_MateriaId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DificuldadeId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Tarefas");
        }
    }
}
