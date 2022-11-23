using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddTableAssignment : Migration
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
                value: "6668ad26-c733-48b5-89b6-4fd5406d7d3b");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "617ba2f4-a79d-4698-8da8-4a51243c8fda");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "dace1ade-efcc-4b99-ab59-9c2a908e1565", new DateTime(2022, 11, 23, 17, 27, 16, 825, DateTimeKind.Local).AddTicks(804), "AQAAAAEAACcQAAAAEA9u7Ng7I4rT6dX05T1GAxFN7GdJfe9JN6qBrkWpRsOR4GrroKjjJ9CI6GIchMfzVw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f84ebdb1-eedf-4d83-867d-e718d78eb115", new DateTime(2022, 11, 23, 17, 27, 16, 831, DateTimeKind.Local).AddTicks(9562), "AQAAAAEAACcQAAAAEKAH7IK7NS+JIIs1PgwK3LI2HRs+CaBPtdpg+8UM1dtPcMHbjGjVw0P9rG8CWSQMdg==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100001", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(120), "Laptop 1", "Core i1, 1GB RAM, 150 GB HDD, Window 1" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100002", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(335), "Laptop 2", "Core i2, 2GB RAM, 250 GB HDD, Window 2" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100003", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(347), "Laptop 3", "Core i3, 3GB RAM, 350 GB HDD, Window 3" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100004", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(356), "Laptop 4", "Core i4, 4GB RAM, 450 GB HDD, Window 4" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100005", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(365), "Laptop 5", "Core i5, 5GB RAM, 550 GB HDD, Window 5" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100006", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(381), "Laptop 6", "Core i6, 6GB RAM, 650 GB HDD, Window 6" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100007", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(390), "Laptop 7", "Core i7, 7GB RAM, 750 GB HDD, Window 7" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100008", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(398), "Laptop 8", "Core i8, 8GB RAM, 850 GB HDD, Window 8" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA100009", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(407), "Laptop 9", "Core i9, 9GB RAM, 950 GB HDD, Window 9" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssetCode", "InstalledDate", "Name", "Specification" },
                values: new object[] { "LA1000010", new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(418), "Laptop 10", "Core i10, 10GB RAM, 1050 GB HDD, Window 10" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetId", "AssignedBy", "AssignedDate", "AssignedTo", "ReturnedDate", "State" },
                values: new object[] { 1, 1, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(570), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 23, 17, 27, 16, 832, DateTimeKind.Local).AddTicks(570), 0 });

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
