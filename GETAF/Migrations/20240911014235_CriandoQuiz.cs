using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations {
    /// <inheritdoc />
    public partial class CriandoQuiz : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTarefa = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alternativa",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdQuiz = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Alternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternativa_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alternativa_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizUsuario",
                columns: table => new {
                    IdQuiz = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdAlternativa = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true),
                    AlternativaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_QuizUsuario", x => new { x.IdQuiz, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_QuizUsuario_Alternativa_AlternativaId",
                        column: x => x.AlternativaId,
                        principalTable: "Alternativa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizUsuario_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativa_QuizId",
                table: "Alternativa",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativa_UsuarioId",
                table: "Alternativa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_TarefaId",
                table: "Quiz",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuario_AlternativaId",
                table: "QuizUsuario",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuario_QuizId",
                table: "QuizUsuario",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuario_UsuarioId",
                table: "QuizUsuario",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "QuizUsuario");

            migrationBuilder.DropTable(
                name: "Alternativa");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
