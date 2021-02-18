using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class addingGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "TimeLunch",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "TimeDetailsComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "TimeDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "ProjectCode",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "Menu",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "LeaveTansactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "LeaveBank",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guid",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "TimeLunch");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "TimeDetailsComments");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "TimeDetails");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "ProjectCode");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "LeaveTansactions");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "LeaveBank");
        }
    }
}
