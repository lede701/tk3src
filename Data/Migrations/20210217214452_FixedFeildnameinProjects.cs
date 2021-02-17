using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class FixedFeildnameinProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCode_Users_CratedUserId",
                table: "ProjectCode");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCode_CratedUserId",
                table: "ProjectCode");

            migrationBuilder.DropColumn(
                name: "CratedUserId",
                table: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCode_createdBy",
                table: "ProjectCode",
                column: "createdBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCode_Users_createdBy",
                table: "ProjectCode",
                column: "createdBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCode_Users_createdBy",
                table: "ProjectCode");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCode_createdBy",
                table: "ProjectCode");

            migrationBuilder.AddColumn<int>(
                name: "CratedUserId",
                table: "ProjectCode",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCode_CratedUserId",
                table: "ProjectCode",
                column: "CratedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCode_Users_CratedUserId",
                table: "ProjectCode",
                column: "CratedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
