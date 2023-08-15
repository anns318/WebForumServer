using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWebForum.Migrations
{
    /// <inheritdoc />
    public partial class ReCreateMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 51, 36, 313, DateTimeKind.Local).AddTicks(7722), "$2a$11$NqdTx6UhQtp8use89rfUMOmlQdFAAVzgk0X7m/sn.DRRmALWTNyqe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "HashedPassword" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 18, 35, 156, DateTimeKind.Local).AddTicks(56), "$2a$11$lHPu6fTyId0XihtbGI7eWOmlMfwHHGsAB8fh.c6.qFwCUgUzbGPSK" });
        }
    }
}
