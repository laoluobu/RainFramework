using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addRoleAndMenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RoleSysMenu",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    SysMenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSysMenu", x => new { x.RolesId, x.SysMenusId });
                    table.ForeignKey(
                        name: "FK_RoleSysMenu_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSysMenu_SysMenus_SysMenusId",
                        column: x => x.SysMenusId,
                        principalTable: "SysMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_RoleSysMenu_SysMenusId",
                table: "RoleSysMenu",
                column: "SysMenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleSysMenu");

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
    }
}
