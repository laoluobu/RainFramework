using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    /// <inheritdoc />
    public partial class deleteindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SysMenus_Name",
                table: "SysMenus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SysMenus_Name",
                table: "SysMenus",
                column: "Name",
                unique: true);
        }
    }
}
