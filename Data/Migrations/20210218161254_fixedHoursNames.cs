using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class fixedHoursNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "workHours",
                table: "Timesheet",
                newName: "hoursPerWeek");

            migrationBuilder.RenameColumn(
                name: "hoursPerWeekWorked",
                table: "Timesheet",
                newName: "hoursPerDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hoursPerWeek",
                table: "Timesheet",
                newName: "workHours");

            migrationBuilder.RenameColumn(
                name: "hoursPerDay",
                table: "Timesheet",
                newName: "hoursPerWeekWorked");
        }
    }
}
