using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shepherds_pies.Migrations
{
    /// <inheritdoc />
    public partial class timezonebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92e30f44-a20a-47d3-8cef-a9a1569ce34d", "AQAAAAIAAYagAAAAEAzCSPmTjisFwrmMb9MKhLrY1wgSr7RKrZOZDt5kLAr1Udzppz+dmo2wupKZmXaIMw==", "f4bfdb7f-c52d-4ef5-b048-e9953b21c239" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "349355b4-2b2d-4501-978e-46f79f18d1bc", "AQAAAAIAAYagAAAAEI/9lC1jwKipTrdGX8mTFofRZpTvHFtfsj7xHZ0vHTm28FpZrIXVCsdNglZp1ZX/NA==", "f0d8d373-dd3f-4c4a-8f34-a45523b4b9c5" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 11, 20, 27, 999, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 11, 20, 27, 999, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 11, 20, 27, 999, DateTimeKind.Local).AddTicks(1490));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6087c4ca-8252-4d89-a54d-4225ebebd14f", "AQAAAAIAAYagAAAAEJqy9upKcCqxgvKIsAec2Lzcp4alcZTHZvRqAe4gBsPljKWuryqVWAbhpXRC5XYP6Q==", "e8c6dd9d-d676-4eb9-9511-cec3a39447d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29ab9789-e7b4-4fcd-9acd-4c946643ec16", "AQAAAAIAAYagAAAAEB3eq6CxZdYrw17ea+eenxdzS7S2f1PayLbWQsc8xdDnEccvJJS2CGw68RL6g3k+Rg==", "598e42ae-0569-4be0-8e95-c47e6f18a34f" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 9, 30, 36, 492, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 9, 30, 36, 492, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 9, 9, 30, 36, 492, DateTimeKind.Local).AddTicks(8770));
        }
    }
}
