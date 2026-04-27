using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealthcare.API.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 3, 6, 7, 24, 408, DateTimeKind.Utc).AddTicks(2696), "$2a$11$cUTFHC/26R6vI9uTE7sI6uHoSeWU15yfRW.5966DNdeZh6WQuufVS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 2, 12, 19, 44, 971, DateTimeKind.Utc).AddTicks(4865), "$2a$11$TZkBK3aujGSfLIdxr42wbulxyLx6GYirWJeDBCtQJ4z7/kzaDTL2a" });
        }
    }
}
