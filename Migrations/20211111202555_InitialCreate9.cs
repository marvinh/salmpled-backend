using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salmpled.Migrations
{
    public partial class InitialCreate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sample_SampleFolderGroup_FolderGroupId",
                table: "Sample");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleSamplePlaylist_SampleSamplePlaylistFolderGroup_Folder~",
                table: "SampleSamplePlaylist");

            migrationBuilder.DropTable(
                name: "SampleFolderGroup");

            migrationBuilder.DropTable(
                name: "SampleSamplePlaylistFolderGroup");

            migrationBuilder.DropIndex(
                name: "IX_SampleSamplePlaylist_FolderGroupId",
                table: "SampleSamplePlaylist");

            migrationBuilder.DropIndex(
                name: "IX_Sample_FolderGroupId",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "FolderGroupId",
                table: "SampleSamplePlaylist");

            migrationBuilder.DropColumn(
                name: "FolderGroupId",
                table: "Sample");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FolderGroupId",
                table: "SampleSamplePlaylist",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FolderGroupId",
                table: "Sample",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SampleFolderGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FolderGroupName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleFolderGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleSamplePlaylistFolderGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FolderGroupName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleSamplePlaylistFolderGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleSamplePlaylist_FolderGroupId",
                table: "SampleSamplePlaylist",
                column: "FolderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_FolderGroupId",
                table: "Sample",
                column: "FolderGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_SampleFolderGroup_FolderGroupId",
                table: "Sample",
                column: "FolderGroupId",
                principalTable: "SampleFolderGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSamplePlaylist_SampleSamplePlaylistFolderGroup_Folder~",
                table: "SampleSamplePlaylist",
                column: "FolderGroupId",
                principalTable: "SampleSamplePlaylistFolderGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
