using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddTableAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AppUser_AssignedBy",
                        column: x => x.AssignedBy,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_AppUser_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "938e67a4-54f2-407c-b369-36231393e6b4");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "014f707d-fc4d-4fb4-b278-b9de07da5be8");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "064db62b-19b0-43ff-a213-f32d21098613", new DateTime(2022, 11, 23, 12, 40, 49, 537, DateTimeKind.Local).AddTicks(8576), "AQAAAAEAACcQAAAAEAXcDtIgIl8XxdNXc5Tt02QgKooqaHd6nL7wVVJ7oye73NlaSpQgLmnh/W6fCT0yHQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "9bafde65-d3e5-4058-996a-94c57e8f5a1d", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(1882), "AQAAAAEAACcQAAAAEIQnNlfQX60Y8c34lGV9kEMFTse/h1hW9uoYP736dM3nH5FjS7pgd/XZV7EcI97h2g==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100001", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2135), "Laptop 1", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100002", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2145), "Laptop 2", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100003", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2155), "Laptop 3", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100004", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2163), "Laptop 4", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100005", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2170), "Laptop 5", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100006", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2183), "Laptop 6", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100007", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2191), "Laptop 7", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100008", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2198), "Laptop 8", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100009", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2205), "Laptop 9", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA1000010", new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2214), "Laptop 10", "Core i5, 5GB RAM, 650 GB HDD, Window 10" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetId", "AssignedBy", "AssignedDate", "AssignedTo", "ReturnedDate", "State" },
                values: new object[] { 1, 1, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2231), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 23, 12, 40, 49, 544, DateTimeKind.Local).AddTicks(2232), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssetId",
                table: "Assignments",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignedBy",
                table: "Assignments",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignedTo",
                table: "Assignments",
                column: "AssignedTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assets");

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
