using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addUserinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuths_UserInfos_UserInfoId",
                table: "UserAuths");

            migrationBuilder.DropIndex(
                name: "IX_UserAuths_UserInfoId",
                table: "UserAuths");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "UserAuths");

            migrationBuilder.AddColumn<int>(
                name: "UserAuthId",
                table: "UserInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserAuthId",
                table: "UserInfos",
                column: "UserAuthId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_UserAuths_UserAuthId",
                table: "UserInfos",
                column: "UserAuthId",
                principalTable: "UserAuths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_UserAuths_UserAuthId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_UserAuthId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "UserAuthId",
                table: "UserInfos");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "UserAuths",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAuths_UserInfoId",
                table: "UserAuths",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuths_UserInfos_UserInfoId",
                table: "UserAuths",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }
    }
}
