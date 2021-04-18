using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Project.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Directionid",
                table: "photos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Landmarkid",
                table: "photos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reviewid",
                table: "photos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "directions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    shortDescription = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directions", x => x.id);
                    table.ForeignKey(
                        name: "FK_directions_photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "landmarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    LandmarksId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landmarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_landmarks_directions_LandmarksId",
                        column: x => x.LandmarksId,
                        principalTable: "directions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: true),
                    header = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    Landmarkid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviews_landmarks_Landmarkid",
                        column: x => x.Landmarkid,
                        principalTable: "landmarks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_photos_Directionid",
                table: "photos",
                column: "Directionid");

            migrationBuilder.CreateIndex(
                name: "IX_photos_Landmarkid",
                table: "photos",
                column: "Landmarkid");

            migrationBuilder.CreateIndex(
                name: "IX_photos_Reviewid",
                table: "photos",
                column: "Reviewid");

            migrationBuilder.CreateIndex(
                name: "IX_directions_PhotoId",
                table: "directions",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_landmarks_LandmarksId",
                table: "landmarks",
                column: "LandmarksId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Landmarkid",
                table: "reviews",
                column: "Landmarkid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_userId",
                table: "reviews",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_directions_Directionid",
                table: "photos",
                column: "Directionid",
                principalTable: "directions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_landmarks_Landmarkid",
                table: "photos",
                column: "Landmarkid",
                principalTable: "landmarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_reviews_Reviewid",
                table: "photos",
                column: "Reviewid",
                principalTable: "reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_directions_Directionid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_landmarks_Landmarkid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_reviews_Reviewid",
                table: "photos");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "landmarks");

            migrationBuilder.DropTable(
                name: "directions");

            migrationBuilder.DropIndex(
                name: "IX_photos_Directionid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_Landmarkid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_Reviewid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Directionid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Landmarkid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Reviewid",
                table: "photos");
        }
    }
}
