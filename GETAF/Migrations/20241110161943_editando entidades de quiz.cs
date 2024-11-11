using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class editandoentidadesdequiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Perguntas_PerguntaId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_PerguntaId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "PerguntaId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Alternativas");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Alternativas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerguntaId",
                table: "Quiz",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Alternativas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Alternativas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_PerguntaId",
                table: "Quiz",
                column: "PerguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Perguntas_PerguntaId",
                table: "Quiz",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id");
        }
    }
}
