using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class criandoperguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Quiz_QuizId",
                table: "Alternativas");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Alternativas_QuizId",
                table: "Alternativas");

            migrationBuilder.RenameColumn(
                name: "TarefaId",
                table: "Quiz",
                newName: "GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_TarefaId",
                table: "Quiz",
                newName: "IX_Quiz_GrupoId");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PerguntaId",
                table: "Quiz",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerguntaId",
                table: "Alternativas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_PerguntaId",
                table: "Quiz",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_PerguntaId",
                table: "Alternativas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_QuizId",
                table: "Perguntas",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Perguntas_PerguntaId",
                table: "Alternativas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Grupos_GrupoId",
                table: "Quiz",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Perguntas_PerguntaId",
                table: "Quiz",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Perguntas_PerguntaId",
                table: "Alternativas");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Grupos_GrupoId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Perguntas_PerguntaId",
                table: "Quiz");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_PerguntaId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Alternativas_PerguntaId",
                table: "Alternativas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "PerguntaId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "PerguntaId",
                table: "Alternativas");

            migrationBuilder.RenameColumn(
                name: "GrupoId",
                table: "Quiz",
                newName: "TarefaId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_GrupoId",
                table: "Quiz",
                newName: "IX_Quiz_TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_QuizId",
                table: "Alternativas",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Quiz_QuizId",
                table: "Alternativas",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Tarefas_TarefaId",
                table: "Quiz",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
