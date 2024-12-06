using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shepherds_pies.Migrations
{
    /// <inheritdoc />
    public partial class pizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95070068-33e9-436f-b392-4d2244bf8ff3", "AQAAAAIAAYagAAAAEBgzslY4cCE0pNW3bbARF3cKD+68QIVX4zzUCqnVGQQTkQzuXYL/aJnyXiAhl3NDUQ==", "e9abfa7f-22dc-42f2-aebf-7c81d0653c33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0879610-dfff-420e-a920-8a0dab21aaac", "AQAAAAIAAYagAAAAEFqXTZYuwkfL1S5GsC+xugUZQyaenA3hL+bUn5eLR7RVsWe3sV0R0nWvbLCBh/6TwQ==", "d13e53f5-1b84-48ed-a13b-821dd4d27d4c" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 7, 55, 708, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 7, 55, 708, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 7, 55, 708, DateTimeKind.Local).AddTicks(6350));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99c858d5-cb6f-4f5e-ba3a-b2a93eb1f414", "AQAAAAIAAYagAAAAEPJxMMVU8NQl+VefYPwKmzfd9u8+TRGlzhiF7sme4jP5mR61MtO5gPYkby0Inwc6jg==", "0350b162-e376-4c34-80b9-5284b3c09395" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15d2cd8e-026b-4a0a-abf7-bba7ae7a12f6", "AQAAAAIAAYagAAAAEFWGpUE6Uq/P3M3lIGjZHYRvySDRbW3d3ZpLf380Wg5WQn/cJAHhEopu0WZYMJqwwg==", "ac369dfb-0999-464a-bc55-0534cc7f578b" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 14, 0, 37, 176, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 14, 0, 37, 176, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 14, 0, 37, 176, DateTimeKind.Local).AddTicks(3690));
        }
    }
}
