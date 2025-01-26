using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Migrations
{
    /// <inheritdoc />
    public partial class trying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Users_BanneduserId",
                table: "Bans");

            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Users_BanningAdminId",
                table: "Bans");

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Users_BanneduserId",
                table: "Bans",
                column: "BanneduserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Users_BanningAdminId",
                table: "Bans",
                column: "BanningAdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Users_BanneduserId",
                table: "Bans");

            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Users_BanningAdminId",
                table: "Bans");

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Users_BanneduserId",
                table: "Bans",
                column: "BanneduserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Users_BanningAdminId",
                table: "Bans",
                column: "BanningAdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
