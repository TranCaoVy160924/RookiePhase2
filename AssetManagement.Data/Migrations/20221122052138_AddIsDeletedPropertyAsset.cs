using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddIsDeletedPropertyAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetCode", "InstalledDate", "IsDeleted", "Name", "Specification", "State" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4809), false, "Asset 1", "1", 1 },
                    { 2, "2", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4899), true, "Asset 2", "2", 0 },
                    { 3, "3", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4912), false, "Asset 3", "3", 1 },
                    { 4, "4", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4920), true, "Asset 4", "4", 0 },
                    { 5, "5", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4927), false, "Asset 5", "5", 1 },
                    { 6, "6", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4941), true, "Asset 6", "6", 0 },
                    { 7, "7", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4949), false, "Asset 7", "7", 1 },
                    { 8, "8", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4957), true, "Asset 8", "8", 0 },
                    { 9, "9", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4964), false, "Asset 9", "9", 1 },
                    { 10, "10", new DateTime(2022, 11, 22, 12, 21, 37, 610, DateTimeKind.Local).AddTicks(4974), true, "Asset 10", "10", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assets");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "7027a446-e8c2-4b00-bc09-2aefc892ba57");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "acfb6c92-c938-4485-ae2c-32addb60154a");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "1f5d5de4-0a8f-4e38-aad2-629dc6548e1f", new DateTime(2022, 11, 22, 10, 15, 18, 550, DateTimeKind.Local).AddTicks(6959), "AQAAAAEAACcQAAAAEJa907HNcTamMkcpMbHn3vH53c5Ppq4K14JUMo393SmcCtzM/ar4u0XN1lH2g2OWFQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "134fc0d3-2394-4738-bc9c-43acef5271d4", new DateTime(2022, 11, 22, 10, 15, 18, 557, DateTimeKind.Local).AddTicks(3674), "AQAAAAEAACcQAAAAEJFjyQiaZQe3BwtkxgGbZEJ4ZqZT+swVAzTdM1KdC1aNTALr7Oy5OpYkHBMsS4hH/Q==" });
        }
    }
}
