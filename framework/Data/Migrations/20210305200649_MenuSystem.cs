using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class MenuSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Menu",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuItemId",
                table: "Menu",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_MenuItemId",
                table: "Menu",
                column: "MenuItemId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_MenuItemId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_MenuItemId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Menu");
        }
    }
}
