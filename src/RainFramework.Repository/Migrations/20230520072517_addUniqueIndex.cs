using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAuths_Username",
                table: "UserAuths",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysMenus_Name",
                table: "SysMenus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAuths_Username",
                table: "UserAuths");

            migrationBuilder.DropIndex(
                name: "IX_SysMenus_Name",
                table: "SysMenus");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleName",
                table: "Roles");
        }
    }
}
