using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Project.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_landmarks_directions_LandmarksId",
                table: "landmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_directions_Directionid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_landmarks_Landmarkid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_reviews_Reviewid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_profiles_photos_backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_landmarks_Landmarkid",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_userId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_Landmarkid",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_profiles_backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_photos_Directionid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_Landmarkid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_Reviewid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_landmarks_LandmarksId",
                table: "landmarks");

            migrationBuilder.DropColumn(
                name: "Landmarkid",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "backgroundPhotoId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "countPublications",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "Directionid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Landmarkid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Reviewid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "LandmarksId",
                table: "landmarks");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "directionLandmarkLinks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    directionId = table.Column<int>(type: "integer", nullable: false),
                    landmarkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directionLandmarkLinks", x => x.id);
                    table.ForeignKey(
                        name: "FK_directionLandmarkLinks_directions_directionId",
                        column: x => x.directionId,
                        principalTable: "directions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_directionLandmarkLinks_landmarks_landmarkId",
                        column: x => x.landmarkId,
                        principalTable: "landmarks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "directionPhotoLinks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    directionId = table.Column<int>(type: "integer", nullable: false),
                    photoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directionPhotoLinks", x => x.id);
                    table.ForeignKey(
                        name: "FK_directionPhotoLinks_directions_directionId",
                        column: x => x.directionId,
                        principalTable: "directions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_directionPhotoLinks_photos_photoId",
                        column: x => x.photoId,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "landmarkPhotoLinks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    landmarkId = table.Column<int>(type: "integer", nullable: false),
                    photoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landmarkPhotoLinks", x => x.id);
                    table.ForeignKey(
                        name: "FK_landmarkPhotoLinks_landmarks_landmarkId",
                        column: x => x.landmarkId,
                        principalTable: "landmarks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_landmarkPhotoLinks_photos_photoId",
                        column: x => x.photoId,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "landmarkReviewLinks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    landmarkId = table.Column<int>(type: "integer", nullable: false),
                    reviewId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landmarkReviewLinks", x => x.id);
                    table.ForeignKey(
                        name: "FK_landmarkReviewLinks_landmarks_landmarkId",
                        column: x => x.landmarkId,
                        principalTable: "landmarks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_landmarkReviewLinks_reviews_reviewId",
                        column: x => x.reviewId,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviewPhotoLinks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reviewId = table.Column<int>(type: "integer", nullable: false),
                    photoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewPhotoLinks", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviewPhotoLinks_photos_photoId",
                        column: x => x.photoId,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviewPhotoLinks_reviews_reviewId",
                        column: x => x.reviewId,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_directionLandmarkLinks_directionId",
                table: "directionLandmarkLinks",
                column: "directionId");

            migrationBuilder.CreateIndex(
                name: "IX_directionLandmarkLinks_landmarkId",
                table: "directionLandmarkLinks",
                column: "landmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_directionPhotoLinks_directionId",
                table: "directionPhotoLinks",
                column: "directionId");

            migrationBuilder.CreateIndex(
                name: "IX_directionPhotoLinks_photoId",
                table: "directionPhotoLinks",
                column: "photoId");

            migrationBuilder.CreateIndex(
                name: "IX_landmarkPhotoLinks_landmarkId",
                table: "landmarkPhotoLinks",
                column: "landmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_landmarkPhotoLinks_photoId",
                table: "landmarkPhotoLinks",
                column: "photoId");

            migrationBuilder.CreateIndex(
                name: "IX_landmarkReviewLinks_landmarkId",
                table: "landmarkReviewLinks",
                column: "landmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_landmarkReviewLinks_reviewId",
                table: "landmarkReviewLinks",
                column: "reviewId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewPhotoLinks_photoId",
                table: "reviewPhotoLinks",
                column: "photoId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewPhotoLinks_reviewId",
                table: "reviewPhotoLinks",
                column: "reviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_userId",
                table: "reviews",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_userId",
                table: "reviews");

            migrationBuilder.DropTable(
                name: "directionLandmarkLinks");

            migrationBuilder.DropTable(
                name: "directionPhotoLinks");

            migrationBuilder.DropTable(
                name: "landmarkPhotoLinks");

            migrationBuilder.DropTable(
                name: "landmarkReviewLinks");

            migrationBuilder.DropTable(
                name: "reviewPhotoLinks");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "reviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Landmarkid",
                table: "reviews",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "backgroundPhotoId",
                table: "profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "countPublications",
                table: "profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "LandmarksId",
                table: "landmarks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Landmarkid",
                table: "reviews",
                column: "Landmarkid");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_backgroundPhotoId",
                table: "profiles",
                column: "backgroundPhotoId");

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
                name: "IX_landmarks_LandmarksId",
                table: "landmarks",
                column: "LandmarksId");

            migrationBuilder.AddForeignKey(
                name: "FK_landmarks_directions_LandmarksId",
                table: "landmarks",
                column: "LandmarksId",
                principalTable: "directions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_photos_backgroundPhotoId",
                table: "profiles",
                column: "backgroundPhotoId",
                principalTable: "photos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_landmarks_Landmarkid",
                table: "reviews",
                column: "Landmarkid",
                principalTable: "landmarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_userId",
                table: "reviews",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
