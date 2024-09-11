using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations {
    /// <inheritdoc />
    public partial class adicaodequiz : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativa_Quiz_QuizId",
                table: "Alternativa");

            migrationBuilder.DropForeignKey(
                name: "FK_Alternativa_Usuarios_UsuarioId",
                table: "Alternativa");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Alternativa_AlternativaId",
                table: "QuizUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Quiz_QuizId",
                table: "QuizUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUsuario_Usuarios_UsuarioId",
                table: "QuizUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Status_StatusId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUsuario",
                table: "QuizUsuario");

            migrationBuilder.DropIndex(
                name: "IX_QuizUsuario_QuizId",
                table: "QuizUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Alternativa_UsuarioId",
                table: "Alternativa");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdQuiz",
                table: "QuizUsuario");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "QuizUsuario");

            migrationBuilder.DropColumn(
                name: "IdAlternativa",
                table: "QuizUsuario");

            migrationBuilder.DropColumn(
                name: "IdQuiz",
                table: "Alternativa");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Alternativa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Alternativa");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "Alternativa",
                newName: "IsCorreta");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaId",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Alternativa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Alternativa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUsuario",
                table: "QuizUsuario",
                columns: new[] { "QuizId", "UsuarioId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
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

            migrationBuilder.RenameColumn(
                name: "IsCorreta",
                table: "Alternativa",
                newName: "IsCorrect");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaId",
                table: "QuizUsuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "QuizUsuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "QuizUsuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdQuiz",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAlternativa",
                table: "QuizUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Alternativa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Alternativa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdQuiz",
                table: "Alternativa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Alternativa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Alternativa",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUsuario",
                table: "QuizUsuario",
                columns: new[] { "IdQuiz", "IdUsuario" });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUsuario_QuizId",
                table: "QuizUsuario",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativa_UsuarioId",
                table: "Alternativa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativa_Quiz_QuizId",
                table: "Alternativa",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativa_Usuarios_UsuarioId",
                table: "Alternativa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Alternativa_AlternativaId",
                table: "QuizUsuario",
                column: "AlternativaId",
                principalTable: "Alternativa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Quiz_QuizId",
                table: "QuizUsuario",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUsuario_Usuarios_UsuarioId",
                table: "QuizUsuario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Status_StatusId",
                table: "Tarefas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
