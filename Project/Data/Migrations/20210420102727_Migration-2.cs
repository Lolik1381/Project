using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_restingPlaces_RestingPlaceid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_restingPlaces_RestingPlaceid",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "RestingPlaceid",
                table: "reviews",
                newName: "Hotelid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_RestingPlaceid",
                table: "reviews",
                newName: "IX_reviews_Hotelid");

            migrationBuilder.RenameColumn(
                name: "RestingPlaceid",
                table: "photos",
                newName: "Hotelid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_RestingPlaceid",
                table: "photos",
                newName: "IX_photos_Hotelid");

            migrationBuilder.AddColumn<string>(
                name: "hrefSite",
                table: "restingPlaces",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "restingPlaces",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_restingPlaces_Hotelid",
                table: "photos",
                column: "Hotelid",
                principalTable: "restingPlaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_restingPlaces_Hotelid",
                table: "reviews",
                column: "Hotelid",
                principalTable: "restingPlaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_restingPlaces_Hotelid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_restingPlaces_Hotelid",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "hrefSite",
                table: "restingPlaces");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "restingPlaces");

            migrationBuilder.RenameColumn(
                name: "Hotelid",
                table: "reviews",
                newName: "RestingPlaceid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_Hotelid",
                table: "reviews",
                newName: "IX_reviews_RestingPlaceid");

            migrationBuilder.RenameColumn(
                name: "Hotelid",
                table: "photos",
                newName: "RestingPlaceid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_Hotelid",
                table: "photos",
                newName: "IX_photos_RestingPlaceid");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_restingPlaces_RestingPlaceid",
                table: "photos",
                column: "RestingPlaceid",
                principalTable: "restingPlaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_restingPlaces_RestingPlaceid",
                table: "reviews",
                column: "RestingPlaceid",
                principalTable: "restingPlaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
