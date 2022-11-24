using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddTableAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "d434f50b-7e89-42ba-960f-3b14cd4d69f4");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "cac42767-d9c6-4acb-ab2e-a3c0c502d3e3");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8a2f5a4e-c642-4c54-ab3b-7f49006ca7fa", new DateTime(2022, 11, 24, 12, 4, 12, 298, DateTimeKind.Local).AddTicks(1811), "AQAAAAEAACcQAAAAEH6B8SRrHvPGHmQ84rjVlFCqzIlgTLOqPfSfTVvoOtjEJG2NxvYDblpgQaEhk5GVvg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "468fe6e9-8d08-4dc4-8029-8c73e594f935", new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2746), "AQAAAAEAACcQAAAAEIZX11XIjhKz0whNZLYbaCNwfpd2fIOKPTtoVw5T9qx+EKxPLQ58exvJg469enzQvw==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetId", "AssignedBy", "AssignedDate", "AssignedTo", "ReturnedDate", "State" },
                values: new object[] { 1, 1, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(3026), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 24, 12, 4, 12, 304, DateTimeKind.Local).AddTicks(3026), 0 });

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
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 11, 23, 23, 21, 55, 39, DateTimeKind.Local).AddTicks(8354));
        }
    }
}
