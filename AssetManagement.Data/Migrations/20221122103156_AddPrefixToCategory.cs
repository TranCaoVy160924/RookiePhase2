using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddPrefixToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100001", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7009), "Laptop 1", "Core i1, 1GB RAM, 150 GB HDD, Window 1" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100002", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7032), "Laptop 2", "Core i2, 2GB RAM, 250 GB HDD, Window 2" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100003", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7050), "Laptop 3", "Core i3, 3GB RAM, 350 GB HDD, Window 3" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100004", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7065), "Laptop 4", "Core i4, 4GB RAM, 450 GB HDD, Window 4" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100005", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7082), "Laptop 5", "Core i5, 5GB RAM, 550 GB HDD, Window 5" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100006", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7107), "Laptop 6", "Core i6, 6GB RAM, 650 GB HDD, Window 6" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100007", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7123), "Laptop 7", "Core i7, 7GB RAM, 750 GB HDD, Window 7" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100008", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7142), "Laptop 8", "Core i8, 8GB RAM, 850 GB HDD, Window 8" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100009", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7156), "Laptop 9", "Core i9, 9GB RAM, 950 GB HDD, Window 9" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA1000010", new DateTime(2022, 11, 22, 17, 31, 55, 523, DateTimeKind.Local).AddTicks(7177), "Laptop 10", "Core i10, 10GB RAM, 1050 GB HDD, Window 10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "f61d3e6d-f181-4ea4-a717-4ebf781b9e68");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5e9df8fa-bebf-4559-b93d-6aa98f79d990");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "dc712d62-0a31-4c96-a505-1e528058898a", new DateTime(2022, 11, 22, 14, 10, 16, 248, DateTimeKind.Local).AddTicks(4834), "AQAAAAEAACcQAAAAEPRivljmfNM2v0boYOO57NVWQePVOoWZKIdIdfU6sVMl4U3ufIavyWNq4iv28TS4Kg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "95605815-8ea4-4c63-838c-d8854e481598", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(1896), "AQAAAAEAACcQAAAAECNVdlgw4rQEZLz1PMVqfIQM7yVrKGeDb1ZtJwrFn2UQ6ttdXxXNwNEUDmio3al1eQ==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "1", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2166), "Asset 1", "1" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "2", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2177), "Asset 2", "2" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "3", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2185), "Asset 3", "3" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "4", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2193), "Asset 4", "4" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "5", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2287), "Asset 5", "5" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "6", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2305), "Asset 6", "6" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "7", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2313), "Asset 7", "7" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "8", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2321), "Asset 8", "8" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "9", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2329), "Asset 9", "9" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "10", new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2338), "Asset 10", "10" });
        }
    }
}
