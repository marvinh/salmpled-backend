using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salmpled.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SampleTag");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SampleTag");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePlaylistLike");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePlaylistLike");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePlaylistGenre");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePlaylistGenre");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePlaylist");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePlaylist");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePackLike");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePackLike");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePackGenre");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePackGenre");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SamplePack");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SamplePack");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "SampleLike");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "SampleLike");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Sample");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SampleTag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SampleTag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePlaylistLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePlaylistLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePlaylistGenre",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePlaylistGenre",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePlaylist",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePlaylist",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePackLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePackLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePackGenre",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePackGenre",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SamplePack",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SamplePack",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SampleLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SampleLike",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Sample",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sample",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Follow",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Follow",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SampleTag");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SampleTag");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePlaylistLike");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePlaylistLike");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePlaylistGenre");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePlaylistGenre");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePlaylist");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePlaylist");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePackLike");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePackLike");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePackGenre");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePackGenre");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SamplePack");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SamplePack");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SampleLike");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SampleLike");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Sample");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Follow");

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SampleTag",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SampleTag",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePlaylistLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePlaylistLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePlaylistGenre",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePlaylistGenre",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePlaylist",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePlaylist",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePackLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePackLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePackGenre",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePackGenre",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SamplePack",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SamplePack",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "SampleLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "SampleLike",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "Sample",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Sample",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
