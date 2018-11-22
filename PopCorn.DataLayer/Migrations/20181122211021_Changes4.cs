using Microsoft.EntityFrameworkCore.Migrations;

namespace PopCorn.DataLayer.Migrations
{
    public partial class Changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ParentCategoryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ParentCategoryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects",
                column: "StatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_StatusId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StatusId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentCategoryId",
                table: "Projects",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ParentCategoryId",
                table: "Projects",
                column: "ParentCategoryId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
