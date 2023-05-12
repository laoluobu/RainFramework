using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RoleAndMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "SysMenus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SysMenus_RoleId",
                table: "SysMenus",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SysMenus_Roles_RoleId",
                table: "SysMenus",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SysMenus_Roles_RoleId",
                table: "SysMenus");

            migrationBuilder.DropIndex(
                name: "IX_SysMenus_RoleId",
                table: "SysMenus");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "SysMenus");
        }
    }
}
