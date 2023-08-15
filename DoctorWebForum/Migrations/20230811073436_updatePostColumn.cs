using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class updatePostColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostComment",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostReact",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 34, 36, 897, DateTimeKind.Local).AddTicks(4722), "$2a$11$30KpKRwkCaPwApdYioC5Ue48jDhNsXKey6/SgwbxuzEKTHoQrB5VW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostComment",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostReact",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 51, 36, 313, DateTimeKind.Local).AddTicks(7722), "$2a$11$NqdTx6UhQtp8use89rfUMOmlQdFAAVzgk0X7m/sn.DRRmALWTNyqe" });
        }
    }
}
