using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations {
    /// <inheritdoc />
    public partial class adicaododbSet : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativa_Quiz_QuizId",
                table: "Alternativa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Alternativa_AlternativaId",
                table: "QuizUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Quiz_UsuarioId",
                table: "QuizUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Usuarios_QuizId",
                table: "QuizUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUsuario",
                table: "QuizUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alternativa",
                table: "Alternativa");

            migrationBuilder.RenameTable(
                name: "QuizUsuario",
                newName: "QuizUsuarios");

            migrationBuilder.RenameTable(
                name: "Alternativa",
                newName: "Alternativas");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUsuario_UsuarioId",
                table: "QuizUsuarios",
                newName: "IX_QuizUsuarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUsuario_AlternativaId",
                table: "QuizUsuarios",
                newName: "IX_QuizUsuarios_AlternativaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativa_QuizId",
                table: "Alternativas",
                newName: "IX_Alternativas_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUsuarios",
                table: "QuizUsuarios",
                columns: new[] { "QuizId", "UsuarioId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alternativas",
                table: "Alternativas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Quiz_QuizId",
                table: "Alternativas",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuarios_Alternativas_AlternativaId",
                table: "QuizUsuarios",
                column: "AlternativaId",
                principalTable: "Alternativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuarios_Quiz_UsuarioId",
                table: "QuizUsuarios",
                column: "UsuarioId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuarios_Usuarios_QuizId",
                table: "QuizUsuarios",
                column: "QuizId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Quiz_QuizId",
                table: "Alternativas");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuarios_Alternativas_AlternativaId",
                table: "QuizUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuarios_Quiz_UsuarioId",
                table: "QuizUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuarios_Usuarios_QuizId",
                table: "QuizUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUsuarios",
                table: "QuizUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alternativas",
                table: "Alternativas");

            migrationBuilder.RenameTable(
                name: "QuizUsuarios",
                newName: "QuizUsuario");

            migrationBuilder.RenameTable(
                name: "Alternativas",
                newName: "Alternativa");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUsuarios_UsuarioId",
                table: "QuizUsuario",
                newName: "IX_QuizUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUsuarios_AlternativaId",
                table: "QuizUsuario",
                newName: "IX_QuizUsuario_AlternativaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativas_QuizId",
                table: "Alternativa",
                newName: "IX_Alternativa_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUsuario",
                table: "QuizUsuario",
                columns: new[] { "QuizId", "UsuarioId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alternativa",
                table: "Alternativa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativa_Quiz_QuizId",
                table: "Alternativa",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Alternativa_AlternativaId",
                table: "QuizUsuario",
                column: "AlternativaId",
                principalTable: "Alternativa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Quiz_UsuarioId",
                table: "QuizUsuario",
                column: "UsuarioId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Usuarios_QuizId",
                table: "QuizUsuario",
                column: "QuizId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
