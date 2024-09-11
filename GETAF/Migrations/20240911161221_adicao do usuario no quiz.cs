using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class adicaodousuarionoquiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UsuarioId",
                table: "Quiz",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Usuarios_UsuarioId",
                table: "Quiz",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Usuarios_UsuarioId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UsuarioId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Quiz");
        }
    }
}
