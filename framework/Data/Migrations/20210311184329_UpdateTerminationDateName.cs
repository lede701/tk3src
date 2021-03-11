using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class UpdateTerminationDateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "teminationDate",
                table: "Users",
                newName: "terminationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "terminationDate",
                table: "Users",
                newName: "teminationDate");
        }
    }
}
