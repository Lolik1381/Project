using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Project.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roomEquipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    photoid = table.Column<int>(type: "integer", nullable: true),
                    Hotelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomEquipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_roomEquipment_hotels_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roomEquipment_photos_photoid",
                        column: x => x.photoid,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roomTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    photoid = table.Column<int>(type: "integer", nullable: true),
                    Hotelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK_roomTypes_hotels_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roomTypes_photos_photoid",
                        column: x => x.photoid,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    photoid = table.Column<int>(type: "integer", nullable: true),
                    Hotelid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_services_hotels_Hotelid",
                        column: x => x.Hotelid,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_services_photos_photoid",
                        column: x => x.photoid,
                        principalTable: "photos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roomEquipment_Hotelid",
                table: "roomEquipment",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_roomEquipment_photoid",
                table: "roomEquipment",
                column: "photoid");

            migrationBuilder.CreateIndex(
                name: "IX_roomTypes_Hotelid",
                table: "roomTypes",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_roomTypes_photoid",
                table: "roomTypes",
                column: "photoid");

            migrationBuilder.CreateIndex(
                name: "IX_services_Hotelid",
                table: "services",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_services_photoid",
                table: "services",
                column: "photoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roomEquipment");

            migrationBuilder.DropTable(
                name: "roomTypes");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
