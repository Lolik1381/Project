using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_hotels_Hotelid",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_landmarks_Landmarkid",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_restaurants_Restaurantid",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "reviews",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "Landmarkid",
                table: "reviews",
                newName: "landmarkId");

            migrationBuilder.RenameColumn(
                name: "Hotelid",
                table: "reviews",
                newName: "hotelId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_Restaurantid",
                table: "reviews",
                newName: "IX_reviews_restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_Landmarkid",
                table: "reviews",
                newName: "IX_reviews_landmarkId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_Hotelid",
                table: "reviews",
                newName: "IX_reviews_hotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_hotels_hotelId",
                table: "reviews",
                column: "hotelId",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_landmarks_landmarkId",
                table: "reviews",
                column: "landmarkId",
                principalTable: "landmarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_restaurants_restaurantId",
                table: "reviews",
                column: "restaurantId",
                principalTable: "restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_hotels_hotelId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_landmarks_landmarkId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_restaurants_restaurantId",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "reviews",
                newName: "Restaurantid");

            migrationBuilder.RenameColumn(
                name: "landmarkId",
                table: "reviews",
                newName: "Landmarkid");

            migrationBuilder.RenameColumn(
                name: "hotelId",
                table: "reviews",
                newName: "Hotelid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_restaurantId",
                table: "reviews",
                newName: "IX_reviews_Restaurantid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_landmarkId",
                table: "reviews",
                newName: "IX_reviews_Landmarkid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_hotelId",
                table: "reviews",
                newName: "IX_reviews_Hotelid");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_hotels_Hotelid",
                table: "reviews",
                column: "Hotelid",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_landmarks_Landmarkid",
                table: "reviews",
                column: "Landmarkid",
                principalTable: "landmarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_restaurants_Restaurantid",
                table: "reviews",
                column: "Restaurantid",
                principalTable: "restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
