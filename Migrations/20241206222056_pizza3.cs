using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shepherds_pies.Migrations
{
    /// <inheritdoc />
    public partial class pizza3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53393ab9-a15b-40f0-a4a1-dfb1c7a96c89", "AQAAAAIAAYagAAAAEEU9/DcXx2VgwVNqle44kUkeh1A+hT1F1Jd2XVjkFdi2PhjdSyynfAV/GPZlMZr90w==", "56775454-db3d-4db1-b1c4-67ad8330d679" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e723a1bf-6c78-4541-854d-55095ac14672", "AQAAAAIAAYagAAAAEOI0ycDoe3Pgqq/hflO8XdMPVFeghcdNY27wjojDtZD1+uKoM2NJ83/iXENGa01fOg==", "bc30d121-32e7-4e80-9cf0-0e4f4384dd15" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 17, 40, 666, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 17, 40, 666, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 12, 6, 16, 17, 40, 666, DateTimeKind.Local).AddTicks(1960));
        }
    }
}
