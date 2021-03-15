using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class AddingVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueCommentVotes",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommentGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Vote = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueCommentVotes", x => new { x.UserGuid, x.CommentGuid });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueCommentVotes");
        }
    }
}
