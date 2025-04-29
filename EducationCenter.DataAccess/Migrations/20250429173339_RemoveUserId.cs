using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationCenter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationRecipients_AspNetUsers_UserID",
                table: "NotificationRecipients");

            migrationBuilder.DropIndex(
                name: "IX_NotificationRecipients_UserID",
                table: "NotificationRecipients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "NotificationRecipients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "NotificationRecipients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipients_UserID",
                table: "NotificationRecipients",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationRecipients_AspNetUsers_UserID",
                table: "NotificationRecipients",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
