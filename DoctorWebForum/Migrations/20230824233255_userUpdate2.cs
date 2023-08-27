using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 25, 6, 32, 55, 795, DateTimeKind.Local).AddTicks(5802), "$2a$11$GNcsJ9YkeLXpmw4VKxCQm.sf.LCclBCIg48PLADkKSv4rA9RVS5Ze" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 25, 6, 29, 18, 983, DateTimeKind.Local).AddTicks(5392), "$2a$11$zbYd4MMCQTV0BR4N25PQ5e7fejlB3j//9M3QQpeQ5ewmXFzjuln1W" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");
        }
    }
}
