using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoestruturarespostasperguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizUsuarios");

            migrationBuilder.CreateTable(
                name: "RespostaUsuario",
                columns: table => new
                {
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AlternativaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaUsuario", x => new { x.PerguntaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_RespostaUsuario_Alternativas_AlternativaId",
                        column: x => x.AlternativaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaUsuario_Perguntas_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespostaUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostaUsuario_AlternativaId",
                table: "RespostaUsuario",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaUsuario_UsuarioId",
                table: "RespostaUsuario",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostaUsuario");

            migrationBuilder.CreateTable(
                name: "QuizUsuarios",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AlternativaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizUsuarios", x => new { x.QuizId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_QuizUsuarios_Alternativas_AlternativaId",
                        column: x => x.AlternativaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizUsuarios_Quiz_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizUsuarios_Usuarios_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuarios_AlternativaId",
                table: "QuizUsuarios",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuarios_UsuarioId",
                table: "QuizUsuarios",
                column: "UsuarioId");
        }
    }
}
