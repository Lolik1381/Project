using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "services",
                table: "restaurants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "timeEating",
                table: "restaurants",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "services",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "timeEating",
                table: "restaurants");
        }
    }
}
