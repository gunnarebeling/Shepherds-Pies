using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shepherds_pies.Migrations
{
    /// <inheritdoc />
    public partial class revertback3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ac57bc-4fdd-4680-afda-1e9aa87debec", "AQAAAAIAAYagAAAAELUdsQCCerVdPmP/8G9fL9SohhQRbt+NV7UTZ08tFD4ueeYb5pxHl1LpSKp/x+0TOQ==", "70a57dd3-9522-4365-8100-d0a218ec9332" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdfb127b-88bc-4950-b972-f5ca2eb1ee41", "AQAAAAIAAYagAAAAEFwKJSYYy++/o7vwQIwxEs2UwfXLrmUGX9r/2fXMsiHPkq70FGN5b4rkEsqfb064+A==", "63cc9afa-0a6e-4a62-aaa4-a7dc62596fd6" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 25, 39, 407, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 25, 39, 407, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 25, 39, 407, DateTimeKind.Local).AddTicks(6350));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26fb8d49-dfeb-4551-b03e-889801648277", "AQAAAAIAAYagAAAAEPe7iaKWA4Bk2eBFzSyDUYN6LkRI82eTOzFcCtUpZqoaUXn6nUs0YOCx9GBV+6ApyQ==", "520de99c-4f12-4e8e-9717-e5835b8058c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa4915b-504f-480d-b2dd-c352ce0acc43", "AQAAAAIAAYagAAAAEMp+99m0oT9cZgzvy4Bhz5Dft5vsG0Ys6go9zTLrKmKvjbo9eK801spJm7yEv8jpwg==", "e8bbc4aa-ac3c-4184-82e0-51946a2c17f8" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 20, 56, 228, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 20, 56, 228, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 20, 56, 228, DateTimeKind.Local).AddTicks(8880));
        }
    }
}
