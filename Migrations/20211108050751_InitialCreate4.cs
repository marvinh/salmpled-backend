using Microsoft.EntityFrameworkCore.Migrations;

namespace Salmpled.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderGroup",
                table: "Sample",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderGroup",
                table: "Sample");
        }
    }
}
