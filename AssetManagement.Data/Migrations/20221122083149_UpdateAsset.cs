using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class UpdateAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "d2e1f898-b0f1-4e7a-96bf-4b3595308627");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ebdd30b9-1434-46d5-a635-48ff5691ccb0");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "4cc974f4-3468-492e-a75c-9272df3ba3ba", new DateTime(2022, 11, 22, 15, 31, 48, 84, DateTimeKind.Local).AddTicks(3691), "AQAAAAEAACcQAAAAEGxbScYy8HfbTGHjUQELP3jtZ+5bUS6OwrQIKP6EgIywmNxelyCSsQ7Aid4E2iGvtQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "3cdb5296-bde6-4ad2-ade3-90003f765c52", new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5174), "AQAAAAEAACcQAAAAELvl8nJ1WMy5XQyCv2X8oFNlDUULYm2Iya97m3IhXNjc6x7aXflcrWhDsyFJibKSPg==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 15, 31, 48, 103, DateTimeKind.Local).AddTicks(5789));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "e7bd09d4-3628-411f-b61e-c0440b8d67c2");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5129220d-f6de-466e-9141-1b3c46240a4b");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "5efbd9d2-56e7-4421-80e4-ccfca0669e1c", new DateTime(2022, 11, 22, 11, 58, 50, 422, DateTimeKind.Local).AddTicks(2440), "AQAAAAEAACcQAAAAEFmLaCJgvh6eU3v9sy1duU5ivLYJH2H/At2LKrwi8Q/1UbxTLPXiRk+pj0aJMN8WVg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d704a54d-3c01-4dfa-968a-bd644314dc10", new DateTime(2022, 11, 22, 11, 58, 50, 431, DateTimeKind.Local).AddTicks(9902), "AQAAAAEAACcQAAAAEDczVD7WIJdEmga15oFyfh5T4qP9roXBcgWF+T8Q+iKJlMHZq06Je1YJPh4OjMUROw==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4974));
        }
    }
}
