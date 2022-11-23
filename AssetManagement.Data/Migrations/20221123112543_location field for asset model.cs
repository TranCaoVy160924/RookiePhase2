using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class locationfieldforassetmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "6e62aa12-ee7c-44c3-b7ee-ffc01c865c5d");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "48ecb1d6-d678-4618-967b-a90486a735ea");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "20b66c3a-4bb7-4973-ac99-091ba933c776", new DateTime(2022, 11, 23, 18, 25, 41, 499, DateTimeKind.Local).AddTicks(1028), "AQAAAAEAACcQAAAAEAs8RjJTuL80FpjA4jrkTb6u9z75eDdf7j+SqcpNDBYvm5dCjdpDIFd/EsvKcstf+w==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "6c5cb0f7-c73b-4769-abb2-c36552cdacb8", new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1042), "AQAAAAEAACcQAAAAEG9XI0X3ezrQsssrw0YilNb9jbYe1PJkJubReUcGyidLwLCf23aXkqwSB+nkZ0rVXw==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 18, 25, 41, 507, DateTimeKind.Local).AddTicks(1637));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assets");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "5381c6c0-b321-4d04-a3e6-6868f5a12dae");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d47372ca-ac0d-4573-aaa8-9241c97ec81a");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "23d03bdd-0001-43d8-9cc6-e9fda91b10e5", new DateTime(2022, 11, 22, 17, 31, 55, 511, DateTimeKind.Local).AddTicks(3954), "AQAAAAEAACcQAAAAECN3gD+uQSH8NSC62UOHmqbGp9VEE4ITsGfcYHNmvHwuOUSDIorpz2OjJ2AXUKBRdQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "232f01e2-3bb1-4322-bab8-fcd696ae1c84", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(6728), "AQAAAAEAACcQAAAAEBf136TOFc/xUqkjt6gmvBZJmJmo5LQ8QpeoU2yDO2hPP6FQKj5/tCjjHL++syvMaQ==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7177));
        }
    }
}
