using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddcategorytoAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 22, 14, 10, 16, 255, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Assets");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "f1429574-b848-4d35-b775-30bac9ec1ac4");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a3a08c40-9f82-412a-b3d0-036d1b84222e");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "7778522d-75d2-4560-8e9a-5479e294563f", new DateTime(2022, 11, 22, 12, 21, 37, 602, DateTimeKind.Local).AddTicks(3322), "AQAAAAEAACcQAAAAEMEXLkvKxAUVmMOCcZr3Sfu/CGTFUFVCacvKTy3QjXIe3n5VfmFr4vw0e+OrOditEw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8a446660-0b9b-4355-bdbc-d7b13161dd7a", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4581), "AQAAAAEAACcQAAAAEH23BrD887DyWe5Yuq77VPHOU4+3W027VejyYRDj1ORzPB1hPJKEbvhO4q9TqpDROw==" });

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
