using Microsoft.EntityFrameworkCore.Migrations;

namespace PopCorn.DataLayer.Migrations
{
    public partial class ProjectNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFinance_Projects_ProjectId",
                table: "ProjectFinance");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectFinance",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFinance_Projects_ProjectId",
                table: "ProjectFinance",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFinance_Projects_ProjectId",
                table: "ProjectFinance");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectFinance",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFinance_Projects_ProjectId",
                table: "ProjectFinance",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
