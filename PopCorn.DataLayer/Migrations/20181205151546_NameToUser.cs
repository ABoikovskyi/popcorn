using Microsoft.EntityFrameworkCore.Migrations;

namespace PopCorn.DataLayer.Migrations
{
    public partial class NameToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Users_NameId",
                table: "UserProjects");

            migrationBuilder.RenameColumn(
                name: "NameId",
                table: "UserProjects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjects_NameId",
                table: "UserProjects",
                newName: "IX_UserProjects_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Users_UserId",
                table: "UserProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Users_UserId",
                table: "UserProjects");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProjects",
                newName: "NameId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects",
                newName: "IX_UserProjects_NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Users_NameId",
                table: "UserProjects",
                column: "NameId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
