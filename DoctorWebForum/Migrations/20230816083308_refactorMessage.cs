using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class refactorMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FromUser",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ToUser",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToUser",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 16, 15, 33, 8, 761, DateTimeKind.Local).AddTicks(2157), "$2a$11$.JpiYMC9tVNyF2g25b7U3Ol31coQc7bq621RIdhZgbeM2Eym04lG2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "ToUser");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_ToUser");

            migrationBuilder.AddColumn<int>(
                name: "FromUser",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
