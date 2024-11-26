using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GETAF.Migrations
{
    /// <inheritdoc />
    public partial class predadosdificuldade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dificuldades",
                columns: new[] { "Id", "Nivel" },
                values: new object[,]
                {
                    { 1, "Baixa" },
                    { 2, "Média" },
                    { 3, "Alta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dificuldades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dificuldades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dificuldades",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
