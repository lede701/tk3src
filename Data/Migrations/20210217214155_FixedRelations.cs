using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class FixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeDetails_ProjectCode_ProjectCodeid",
                table: "TimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_TimeDetails_ProjectCodeid",
                table: "TimeDetails");

            migrationBuilder.DropColumn(
                name: "ProjectCodeid",
                table: "TimeDetails");

            migrationBuilder.AddColumn<int>(
                name: "CratedUserId",
                table: "ProjectCode",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_projectId",
                table: "TimeDetails",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCode_CratedUserId",
                table: "ProjectCode",
                column: "CratedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCode_modifiedBy",
                table: "ProjectCode",
                column: "modifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCode_Users_CratedUserId",
                table: "ProjectCode",
                column: "CratedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectCode_Users_modifiedBy",
                table: "ProjectCode",
                column: "modifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeDetails_ProjectCode_projectId",
                table: "TimeDetails",
                column: "projectId",
                principalTable: "ProjectCode",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCode_Users_CratedUserId",
                table: "ProjectCode");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectCode_Users_modifiedBy",
                table: "ProjectCode");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeDetails_ProjectCode_projectId",
                table: "TimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_TimeDetails_projectId",
                table: "TimeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCode_CratedUserId",
                table: "ProjectCode");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCode_modifiedBy",
                table: "ProjectCode");

            migrationBuilder.DropColumn(
                name: "CratedUserId",
                table: "ProjectCode");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCodeid",
                table: "TimeDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_ProjectCodeid",
                table: "TimeDetails",
                column: "ProjectCodeid");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeDetails_ProjectCode_ProjectCodeid",
                table: "TimeDetails",
                column: "ProjectCodeid",
                principalTable: "ProjectCode",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
