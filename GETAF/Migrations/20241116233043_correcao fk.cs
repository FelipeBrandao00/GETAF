using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class correcaofk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaUsuario_Perguntas_UsuarioId",
                table: "RespostaUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaUsuario_Perguntas_PerguntaId",
                table: "RespostaUsuario",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaUsuario_Perguntas_PerguntaId",
                table: "RespostaUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaUsuario_Perguntas_UsuarioId",
                table: "RespostaUsuario",
                column: "UsuarioId",
                principalTable: "Perguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
