using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class FixedCommentsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeDetailsComments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timeDetailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    comment = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDetailsComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeDetailsComments_TimeDetails_timeDetailsId",
                        column: x => x.timeDetailsId,
                        principalTable: "TimeDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeDetailsComments_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetailsComments_timeDetailsId",
                table: "TimeDetailsComments",
                column: "timeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetailsComments_timesheetId",
                table: "TimeDetailsComments",
                column: "timesheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeDetailsComments");
        }
    }
}
