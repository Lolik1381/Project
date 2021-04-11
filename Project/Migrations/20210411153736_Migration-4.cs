using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "userInfos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "userInfos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "create",
                table: "userInfos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "hrefWebSite",
                table: "userInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personalInformation",
                table: "userInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "profiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "photos",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "photos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "country",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "create",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "hrefWebSite",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "personalInformation",
                table: "userInfos");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "image",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "name",
                table: "photos");
        }
    }
}
