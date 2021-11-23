using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salmpled.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.AddColumn<string>(
                name: "UserImageBucket",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImageKey",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImageRegion",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageBucket",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserImageKey",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserImageRegion",
                table: "User");

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserImageBucket = table.Column<string>(type: "text", nullable: true),
                    UserImageKey = table.Column<string>(type: "text", nullable: true),
                    UserImageRegion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_UserId",
                table: "UserImage",
                column: "UserId",
                unique: true);
        }
    }
}
