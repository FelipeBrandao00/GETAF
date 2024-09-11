using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class correçãodoquiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "IdTarefa",
                table: "Quiz");

            migrationBuilder.AddColumn<decimal>(
                name: "Salt",
                table: "Usuarios",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Quiz",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdTarefa",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id");
        }
    }
}
