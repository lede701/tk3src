using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class LinkingProjectCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimesheetProjects",
                columns: table => new
                {
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    projectCodeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetProjects", x => new { x.timesheetId, x.projectCodeId });
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_ProjectCode_projectCodeId",
                        column: x => x.projectCodeId,
                        principalTable: "ProjectCode",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetProjects_projectCodeId",
                table: "TimesheetProjects",
                column: "projectCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesheetProjects");
        }
    }
}
