using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class addisfirstlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "0456b983-4a60-4295-9588-2d782bda9b7b");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "05e2de69-4a76-46ea-bc55-9870863ca4d9");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "ef4e00c3-1948-4b58-bf42-786a9b54f167", new DateTime(2022, 11, 19, 22, 11, 47, 738, DateTimeKind.Local).AddTicks(6892), "AQAAAAEAACcQAAAAEJfugJV6w63PDSOgxDYsowqZCcwShSTlNUxFKA2jbO473+gc64J/XcoN5ubXzxkXEA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "6012e620-c7d7-42d3-98e0-51efd078dfde");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9f268807-8376-4b1d-8b1f-acb0d6c900f3");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "4f0d5d14-1b99-434a-aa8f-d2ee068b441e", new DateTime(2022, 11, 19, 12, 18, 43, 507, DateTimeKind.Local).AddTicks(4641), "AQAAAAEAACcQAAAAELvwVsMwOo8XqJ6Z4jSTO2Bz1lQ9DqyKwvDvBcC12v6D/ImMd7ZW88M8ma1pgXHEyw==" });
        }
    }
}
