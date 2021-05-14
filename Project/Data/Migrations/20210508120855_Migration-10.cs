using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomEquipment_hotels_hotelsRoomEquimentid",
                table: "HotelRoomEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_roomTypes_hotels_Hotelid",
                table: "roomTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_services_hotels_Hotelid",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_Hotelid",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_roomTypes_Hotelid",
                table: "roomTypes");

            migrationBuilder.DropColumn(
                name: "Hotelid",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Hotelid",
                table: "roomTypes");

            migrationBuilder.RenameColumn(
                name: "hotelsRoomEquimentid",
                table: "HotelRoomEquipment",
                newName: "hotelRoomEquimentid");

            migrationBuilder.CreateTable(
                name: "HotelRoomType",
                columns: table => new
                {
                    hotelRoomTypeid = table.Column<int>(type: "integer", nullable: false),
                    roomTypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomType", x => new { x.hotelRoomTypeid, x.roomTypeid });
                    table.ForeignKey(
                        name: "FK_HotelRoomType_hotels_hotelRoomTypeid",
                        column: x => x.hotelRoomTypeid,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoomType_roomTypes_roomTypeid",
                        column: x => x.roomTypeid,
                        principalTable: "roomTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelServices",
                columns: table => new
                {
                    hotelPhotoid = table.Column<int>(type: "integer", nullable: false),
                    servicesid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelServices", x => new { x.hotelPhotoid, x.servicesid });
                    table.ForeignKey(
                        name: "FK_HotelServices_hotels_hotelPhotoid",
                        column: x => x.hotelPhotoid,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelServices_services_servicesid",
                        column: x => x.servicesid,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomType_roomTypeid",
                table: "HotelRoomType",
                column: "roomTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_servicesid",
                table: "HotelServices",
                column: "servicesid");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomEquipment_hotels_hotelRoomEquimentid",
                table: "HotelRoomEquipment",
                column: "hotelRoomEquimentid",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomEquipment_hotels_hotelRoomEquimentid",
                table: "HotelRoomEquipment");

            migrationBuilder.DropTable(
                name: "HotelRoomType");

            migrationBuilder.DropTable(
                name: "HotelServices");

            migrationBuilder.RenameColumn(
                name: "hotelRoomEquimentid",
                table: "HotelRoomEquipment",
                newName: "hotelsRoomEquimentid");

            migrationBuilder.AddColumn<int>(
                name: "Hotelid",
                table: "services",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hotelid",
                table: "roomTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_services_Hotelid",
                table: "services",
                column: "Hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_roomTypes_Hotelid",
                table: "roomTypes",
                column: "Hotelid");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomEquipment_hotels_hotelsRoomEquimentid",
                table: "HotelRoomEquipment",
                column: "hotelsRoomEquimentid",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roomTypes_hotels_Hotelid",
                table: "roomTypes",
                column: "Hotelid",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_hotels_Hotelid",
                table: "services",
                column: "Hotelid",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
