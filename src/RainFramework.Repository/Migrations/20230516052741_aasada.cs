using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainFramework.Repository.Migrations
{
    /// <inheritdoc />
    public partial class aasada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "SysMenus",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "SysMenus");
        }
    }
}
