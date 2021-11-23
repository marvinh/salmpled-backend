using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salmpled.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleLike_User_UserId1",
                table: "SampleLike");

            migrationBuilder.DropIndex(
                name: "IX_SampleLike_UserId1",
                table: "SampleLike");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SampleLike");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SampleLike",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "SamplePlaylistGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GenreName = table.Column<string>(maxLength: 64, nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamplePlaylistGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SamplePlaylistSamplePlaylistGenre",
                columns: table => new
                {
                    SamplePlaylistId = table.Column<Guid>(nullable: false),
                    SamplePlaylistGenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamplePlaylistSamplePlaylistGenre", x => new { x.SamplePlaylistId, x.SamplePlaylistGenreId });
                    table.ForeignKey(
                        name: "FK_SamplePlaylistSamplePlaylistGenre_SamplePlaylistGenre_Sampl~",
                        column: x => x.SamplePlaylistGenreId,
                        principalTable: "SamplePlaylistGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamplePlaylistSamplePlaylistGenre_SamplePlaylist_SamplePlay~",
                        column: x => x.SamplePlaylistId,
                        principalTable: "SamplePlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleLike_UserId",
                table: "SampleLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SamplePlaylistSamplePlaylistGenre_SamplePlaylistGenreId",
                table: "SamplePlaylistSamplePlaylistGenre",
                column: "SamplePlaylistGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleLike_User_UserId",
                table: "SampleLike",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleLike_User_UserId",
                table: "SampleLike");

            migrationBuilder.DropTable(
                name: "SamplePlaylistSamplePlaylistGenre");

            migrationBuilder.DropTable(
                name: "SamplePlaylistGenre");

            migrationBuilder.DropIndex(
                name: "IX_SampleLike_UserId",
                table: "SampleLike");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SampleLike",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "SampleLike",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SampleLike_UserId1",
                table: "SampleLike",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleLike_User_UserId1",
                table: "SampleLike",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
