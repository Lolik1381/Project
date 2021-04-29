using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Directionid",
                table: "restingPlaces",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Directionid",
                table: "restaurants",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_restingPlaces_Directionid",
                table: "restingPlaces",
                column: "Directionid");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_Directionid",
                table: "restaurants",
                column: "Directionid");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurants_directions_Directionid",
                table: "restaurants",
                column: "Directionid",
                principalTable: "directions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_restingPlaces_directions_Directionid",
                table: "restingPlaces",
                column: "Directionid",
                principalTable: "directions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurants_directions_Directionid",
                table: "restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_restingPlaces_directions_Directionid",
                table: "restingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_restingPlaces_Directionid",
                table: "restingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_Directionid",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "Directionid",
                table: "restingPlaces");

            migrationBuilder.DropColumn(
                name: "Directionid",
                table: "restaurants");
        }
    }
}
