using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocials_AspNetUsers_UserNameId",
                table: "UserSocials");

            migrationBuilder.DropIndex(
                name: "IX_UserSocials_UserNameId",
                table: "UserSocials");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "UserSocials");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocials_UserId",
                table: "UserSocials",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocials_AspNetUsers_UserId",
                table: "UserSocials",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocials_AspNetUsers_UserId",
                table: "UserSocials");

            migrationBuilder.DropIndex(
                name: "IX_UserSocials_UserId",
                table: "UserSocials");

            migrationBuilder.AddColumn<int>(
                name: "UserNameId",
                table: "UserSocials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserSocials_UserNameId",
                table: "UserSocials",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocials_AspNetUsers_UserNameId",
                table: "UserSocials",
                column: "UserNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
