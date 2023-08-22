using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class notificationColumnEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HtmlNotification",
                table: "Notifications",
                newName: "NotificationContent");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 20, 15, 49, 28, 662, DateTimeKind.Local).AddTicks(1840), "$2a$11$A3qbRw3iBnRG1dBbC.neNuqjMUOOI9X7TcyG65IIFe8ciAjxJC3aW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationContent",
                table: "Notifications",
                newName: "HtmlNotification");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 20, 15, 8, 55, 472, DateTimeKind.Local).AddTicks(277), "$2a$11$IRVw0UmqON2RTmB9a4qStOqrhEZcKhtYC0Iva5kj5MVwETgCLcFh2" });
        }
    }
}
