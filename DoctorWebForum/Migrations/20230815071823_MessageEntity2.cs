using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class MessageEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 15, 14, 18, 23, 858, DateTimeKind.Local).AddTicks(2612), "$2a$11$0zL/mN50hF90UNzPj.hgbunQgy0ya2sYz8K8smKMWmfYvEcVEibYW" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUser",
                table: "Messages",
                column: "FromUser");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUser",
                table: "Messages",
                column: "ToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUser",
                table: "Messages",
                column: "FromUser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToUser",
                table: "Messages",
                column: "ToUser",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUser",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToUser",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromUser",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToUser",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 15, 13, 58, 43, 730, DateTimeKind.Local).AddTicks(4834), "$2a$11$RkTYB/oOHb/CjYI9LPNjPe.6mf5jYe7oPwcwcaRJS8HvoD.siJrMm" });
        }
    }
}
