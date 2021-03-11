using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class CreatingOrginizationOwernership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "WorkSchedule",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "TimesheetExceptions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "TimeLunch",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "TimeDetailsComments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "TimeDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Signatures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "ProjectCode",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Menu",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Locations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "LeaveTansactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "LeaveBank",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "LeaveAccrual",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Holidays",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "HolidayEmployee",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrginizationGuid",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orginizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrginizationName = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrginizationGuid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orginizations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orginizations");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "WorkSchedule");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "TimesheetExceptions");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "TimeLunch");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "TimeDetailsComments");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "TimeDetails");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "ProjectCode");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "LeaveTansactions");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "LeaveBank");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "LeaveAccrual");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "HolidayEmployee");

            migrationBuilder.DropColumn(
                name: "OrginizationGuid",
                table: "Departments");
        }
    }
}
