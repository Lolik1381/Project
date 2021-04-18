using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "backgroundPhotoid",
                table: "profiles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_backgroundPhotoid",
                table: "profiles",
                column: "backgroundPhotoid");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_photos_backgroundPhotoid",
                table: "profiles",
                column: "backgroundPhotoid",
                principalTable: "photos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_photos_backgroundPhotoid",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_backgroundPhotoid",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "backgroundPhotoid",
                table: "profiles");
        }
    }
}
