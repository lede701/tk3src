using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class AddingTSTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workHoursPerWeek",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    departmentCode = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    deptParams = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    locationId = table.Column<int>(type: "INTEGER", nullable: false),
                    holidayDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    holidayDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveAccrual",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    earnedHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    startYear = table.Column<decimal>(type: "TEXT", nullable: false),
                    endYear = table.Column<decimal>(type: "TEXT", nullable: false),
                    maxHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    rateGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAccrual", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    parentId = table.Column<int>(type: "INTEGER", nullable: false),
                    locationCity = table.Column<string>(type: "TEXT", nullable: true),
                    locationState = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_parentId",
                        column: x => x.parentId,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    lastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateExpire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    signatureHash = table.Column<string>(type: "TEXT", nullable: true),
                    isLocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Signatures_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetExceptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    supervisorId = table.Column<int>(type: "INTEGER", nullable: false),
                    approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    weekTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    weekNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    weekStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    weekEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    employeeComment = table.Column<string>(type: "TEXT", nullable: true),
                    comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetExceptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimesheetExceptions_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetExceptions_Users_supervisorId",
                        column: x => x.supervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    hoursPerDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    hoursPerWeek = table.Column<decimal>(type: "TEXT", nullable: false),
                    hoursPerHoliday = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayEmployee",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    holidayId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    holidayHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayEmployee", x => x.id);
                    table.ForeignKey(
                        name: "FK_HolidayEmployee_Holidays_holidayId",
                        column: x => x.holidayId,
                        principalTable: "Holidays",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayEmployee_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayEmployee_holidayId",
                table: "HolidayEmployee",
                column: "holidayId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayEmployee_timesheetId",
                table: "HolidayEmployee",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_parentId",
                table: "Locations",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_userId",
                table: "Signatures",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetExceptions_supervisorId",
                table: "TimesheetExceptions",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetExceptions_timesheetId",
                table: "TimesheetExceptions",
                column: "timesheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "HolidayEmployee");

            migrationBuilder.DropTable(
                name: "LeaveAccrual");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "TimesheetExceptions");

            migrationBuilder.DropTable(
                name: "WorkSchedule");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.AddColumn<decimal>(
                name: "workHoursPerWeek",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
