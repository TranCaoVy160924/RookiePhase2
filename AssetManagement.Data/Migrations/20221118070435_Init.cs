using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "6e210a15-53bf-4e9c-9ca2-14d396feb331");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9a806d98-d99b-4705-b7d7-308c0f0420bd");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "09236342-fc99-49d3-9410-bcd6c8690db5", new DateTime(2022, 11, 18, 14, 4, 35, 344, DateTimeKind.Local).AddTicks(7745), "AQAAAAEAACcQAAAAEOZu9AZroTJ5CqjCVnzbpkA3rW+MLJdcKqtO2UUJz4hBqD9TqCjw+tWxyax/dVYk2Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "cc48c800-888b-4015-964e-70eaa62525fa");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c0130a46-9281-4ccb-89ac-dcef9fe52d6f");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "5f062d55-a1eb-4be2-a96a-3b3f561ecc25", new DateTime(2022, 11, 18, 11, 51, 54, 397, DateTimeKind.Local).AddTicks(6456), "AQAAAAEAACcQAAAAEF1mlJT9sSvEI5EOasJQup7lTgo0ihVv+JHIKFvxZtAvLm1nHC2TUubdkg69XwTX/Q==" });
        }
    }
}
