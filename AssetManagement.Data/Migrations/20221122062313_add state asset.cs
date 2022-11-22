using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class addstateasset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "24434fe5-08cf-4c87-86f3-df833d747aae");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "871b149c-4e7d-4c32-aac1-004cf033b5b5");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d2bfda32-c5f6-4aff-ad4e-ccd03b9f6362", new DateTime(2022, 11, 22, 13, 23, 12, 310, DateTimeKind.Local).AddTicks(4829), "AQAAAAEAACcQAAAAEFd9F2RHVKo8Io33sx62XI9ZZsMA6wE921qjuc+opvnpajmQcjvTACnNpj+T4VgIcQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "4886a394-1e55-439f-b44e-3bd79a0a11fd", new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4219), "AQAAAAEAACcQAAAAEK8Ws6pfLWyyGH8ZhtKIzXkW0xBaIrL5vFD74Y0On4ZSebA8AqVhZY1k21RrIGGMvA==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 13, 23, 12, 324, DateTimeKind.Local).AddTicks(5009));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "41a80006-b09b-4ab9-acba-370e6099bcb5");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "839cde89-bab8-4ea6-9ed0-d3b6b6e94358");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "7cb32e4a-4938-42aa-8b5c-a60517430f8f", new DateTime(2022, 11, 22, 10, 57, 59, 758, DateTimeKind.Local).AddTicks(6692), "AQAAAAEAACcQAAAAEGsdXztltHEnLFv4NX23eTKldBY33ZddXcAmT3pGiFlNwg/cgbxqE3pqEagEWIbrkQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f7e4c34c-5688-462d-8a8f-fe92c20256ec", new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4603), "AQAAAAEAACcQAAAAELkASVGJlQOrkjRZZ+nwXV1M6Iw3usGuXjjVPwcQWXbcIS9LEMO+aImOd1bF3DW7qw==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 10, 57, 59, 768, DateTimeKind.Local).AddTicks(4959));
        }
    }
}
