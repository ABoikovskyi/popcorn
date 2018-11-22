using Microsoft.EntityFrameworkCore.Migrations;

namespace PopCorn.DataLayer.Migrations
{
    public partial class Changes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Income",
                table: "FinanceTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "FinanceTypes");
        }
    }
}
