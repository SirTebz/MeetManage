using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetManage.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserIdInMeetingRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "meetingRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_meetingRequests_UserId",
                table: "meetingRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_meetingRequests_AspNetUsers_UserId",
                table: "meetingRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meetingRequests_AspNetUsers_UserId",
                table: "meetingRequests");

            migrationBuilder.DropIndex(
                name: "IX_meetingRequests_UserId",
                table: "meetingRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "meetingRequests");
        }
    }
}
