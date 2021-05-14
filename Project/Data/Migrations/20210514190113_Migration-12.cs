using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "landmarks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "landmarks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "landmarks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "webSite",
                table: "landmarks",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "landmarks");

            migrationBuilder.DropColumn(
                name: "location",
                table: "landmarks");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "landmarks");

            migrationBuilder.DropColumn(
                name: "webSite",
                table: "landmarks");
        }
    }
}
