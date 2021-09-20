using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class LogoUrlAndLogoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Users",
                newName: "LogoUrl");

            migrationBuilder.AddColumn<string>(
                name: "LogoName",
                table: "Users",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Users",
                newName: "Logo");
        }
    }
}
