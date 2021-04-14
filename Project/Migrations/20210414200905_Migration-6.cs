using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_profiles_Profileid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_Profileid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Profileid",
                table: "photos");

            migrationBuilder.AddColumn<int>(
                name: "backgroundPhotoId",
                table: "profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mainPhotoId",
                table: "profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_backgroundPhotoId",
                table: "profiles",
                column: "backgroundPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_mainPhotoId",
                table: "profiles",
                column: "mainPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_photos_backgroundPhotoId",
                table: "profiles",
                column: "backgroundPhotoId",
                principalTable: "photos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_photos_mainPhotoId",
                table: "profiles",
                column: "mainPhotoId",
                principalTable: "photos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_photos_backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_profiles_photos_mainPhotoId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_mainPhotoId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "mainPhotoId",
                table: "profiles");

            migrationBuilder.AddColumn<int>(
                name: "Profileid",
                table: "photos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_photos_Profileid",
                table: "photos",
                column: "Profileid");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_profiles_Profileid",
                table: "photos",
                column: "Profileid",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
