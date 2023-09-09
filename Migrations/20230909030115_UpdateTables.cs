using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitarLogisticsAPI.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Provisiones_logs");

            migrationBuilder.AlterColumn<string>(
                name: "Response",
                table: "Provisiones_logs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Response",
                table: "Provisiones_logs",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Provisiones_logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
