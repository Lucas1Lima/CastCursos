using Microsoft.EntityFrameworkCore.Migrations;

namespace CastCursosAPI.Migrations
{
    public partial class Acao_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDCurso",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCurso",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Logs");
        }
    }
}
