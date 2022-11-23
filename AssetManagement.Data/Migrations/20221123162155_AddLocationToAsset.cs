using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddLocationToAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Assets",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "a79e428e-0271-4df1-abdd-6ea3cd17a4dd");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "01c4f369-5a4f-4dff-8347-4d268a8f3ddf");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "88e07999-2a5a-474d-828a-a4c7a202bec4", new DateTime(2022, 11, 23, 23, 21, 55, 27, DateTimeKind.Local).AddTicks(5315), "AQAAAAEAACcQAAAAECzvcaduyUdJjqkjGmu+McZedqbrOjoSNuBsxGl+ye8JraA6pBc5ZnZtnjA4BH7ZSg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "730409f6-791a-4de1-8ca3-d22e870b63f7", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(7758), "AQAAAAEAACcQAAAAEJmVBJk7Qh1AeYSQvMaZYCV7lSnkWKcXuuhe8XI93H2AfE5biINuhogMcjr/xu3lgg==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100001", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8167), "Laptop 1", "Core i1, 1GB RAM, 150 GB HDD, Window 1" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100002", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8204), "Laptop 2", "Core i2, 2GB RAM, 250 GB HDD, Window 2" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100003", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8222), "Laptop 3", "Core i3, 3GB RAM, 350 GB HDD, Window 3" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100004", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8239), "Laptop 4", "Core i4, 4GB RAM, 450 GB HDD, Window 4" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100005", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8256), "Laptop 5", "Core i5, 5GB RAM, 550 GB HDD, Window 5" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100006", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8283), "Laptop 6", "Core i6, 6GB RAM, 650 GB HDD, Window 6" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100007", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8299), "Laptop 7", "Core i7, 7GB RAM, 750 GB HDD, Window 7" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100008", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8316), "Laptop 8", "Core i8, 8GB RAM, 850 GB HDD, Window 8" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100009", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8332), "Laptop 9", "Core i9, 9GB RAM, 950 GB HDD, Window 9" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA1000010", new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8354), "Laptop 10", "Core i10, 10GB RAM, 1050 GB HDD, Window 10" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_UserName",
                table: "AppUser",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUser_UserName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assets");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
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
