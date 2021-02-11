using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class addingmenuitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parentId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    link = table.Column<string>(type: "TEXT", nullable: true),
                    alias = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    published = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ordering = table.Column<int>(type: "INTEGER", nullable: false),
                    checked_out = table.Column<int>(type: "INTEGER", nullable: true),
                    checked_out_time = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    menuParams = table.Column<string>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdBy = table.Column<int>(type: "INTEGER", nullable: false),
                    modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modifiedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
