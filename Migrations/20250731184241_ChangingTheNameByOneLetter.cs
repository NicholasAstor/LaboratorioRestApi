using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioRestApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTheNameByOneLetter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "segundoNome",
                table: "Autores",
                newName: "SegundoNome");

            migrationBuilder.RenameColumn(
                name: "primeiroNome",
                table: "Autores",
                newName: "PrimeiroNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SegundoNome",
                table: "Autores",
                newName: "segundoNome");

            migrationBuilder.RenameColumn(
                name: "PrimeiroNome",
                table: "Autores",
                newName: "primeiroNome");
        }
    }
}
