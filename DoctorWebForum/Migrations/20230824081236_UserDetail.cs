using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class UserDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 24, 15, 12, 36, 420, DateTimeKind.Local).AddTicks(5541), "$2a$11$98NXgQng1M6ObzyEXsrrheB9owVAk3sSe1hppFOCP72IUmXqGq38C" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 20, 15, 49, 28, 662, DateTimeKind.Local).AddTicks(1840), "$2a$11$A3qbRw3iBnRG1dBbC.neNuqjMUOOI9X7TcyG65IIFe8ciAjxJC3aW" });
        }
    }
}
