using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitarLogisticsAPI.Migrations
{
    public partial class ModTablaParametros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Parametros",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Parametros",
                newName: "Tipo_parametro");

            migrationBuilder.AddColumn<string>(
                name: "Parametro",
                table: "Parametros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parametro",
                table: "Parametros");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Parametros",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Tipo_parametro",
                table: "Parametros",
                newName: "Key");
        }
    }
}
