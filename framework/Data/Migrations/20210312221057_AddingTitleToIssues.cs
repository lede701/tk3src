using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class AddingTitleToIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssueTitle",
                table: "Issues",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueTitle",
                table: "Issues");
        }
    }
}
