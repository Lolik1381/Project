using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Profile_Profileid",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_UserInfo_userInfoid",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profile_profileId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "userInfos");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "profiles");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "photos");

            migrationBuilder.RenameIndex(
                name: "IX_Users_profileId",
                table: "users",
                newName: "IX_users_profileId");

            migrationBuilder.RenameColumn(
                name: "userInfoid",
                table: "profiles",
                newName: "userInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_userInfoid",
                table: "profiles",
                newName: "IX_profiles_userInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_Profileid",
                table: "photos",
                newName: "IX_photos_Profileid");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "profiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userInfos",
                table: "userInfos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profiles",
                table: "profiles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_photos",
                table: "photos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_profiles_Profileid",
                table: "photos",
                column: "Profileid",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_userInfos_userInfoId",
                table: "profiles",
                column: "userInfoId",
                principalTable: "userInfos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_profileId",
                table: "users",
                column: "profileId",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_profiles_Profileid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_profiles_userInfos_userInfoId",
                table: "profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_profileId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userInfos",
                table: "userInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profiles",
                table: "profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_photos",
                table: "photos");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "userInfos",
                newName: "UserInfo");

            migrationBuilder.RenameTable(
                name: "profiles",
                newName: "Profile");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "Photo");

            migrationBuilder.RenameIndex(
                name: "IX_users_profileId",
                table: "Users",
                newName: "IX_Users_profileId");

            migrationBuilder.RenameColumn(
                name: "userInfoId",
                table: "Profile",
                newName: "userInfoid");

            migrationBuilder.RenameIndex(
                name: "IX_profiles_userInfoId",
                table: "Profile",
                newName: "IX_Profile_userInfoid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_Profileid",
                table: "Photo",
                newName: "IX_Photo_Profileid");

            migrationBuilder.AlterColumn<int>(
                name: "password",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Profile",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Profile_Profileid",
                table: "Photo",
                column: "Profileid",
                principalTable: "Profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_UserInfo_userInfoid",
                table: "Profile",
                column: "userInfoid",
                principalTable: "UserInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profile_profileId",
                table: "Users",
                column: "profileId",
                principalTable: "Profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
