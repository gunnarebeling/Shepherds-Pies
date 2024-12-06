using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shepherds_pies.Migrations
{
    /// <inheritdoc />
    public partial class pizza2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
