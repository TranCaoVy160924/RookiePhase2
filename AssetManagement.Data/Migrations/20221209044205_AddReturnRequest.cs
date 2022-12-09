using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class AddReturnRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "Assignments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ReturnRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcceptedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_AspNetUsers_AcceptedBy",
                        column: x => x.AcceptedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnRequests_AspNetUsers_AssignedBy",
                        column: x => x.AssignedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "4a97a439-2f79-4342-8a7f-b71d713f1a43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2e5b24f5-62ed-47d7-881a-78eb23843cdd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "c2508d97-f190-4469-9c18-551376338181", new DateTime(2022, 12, 9, 11, 42, 4, 739, DateTimeKind.Local).AddTicks(6670), "AQAAAAEAACcQAAAAEBZiGcrOw9olMHc/R4dbZQ5PikYOU/tOWQFQkyZyVdQ8WaIMjBfF+TYImxA3BUOyiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "1cb5e9ab-199d-4a33-a593-c695621acb8f", new DateTime(2022, 12, 9, 11, 42, 4, 733, DateTimeKind.Local).AddTicks(2260), "AQAAAAEAACcQAAAAEBkzrANreNLBJMzEnCEHbG9AS4v8Xg15kHzSXQvJrIm82C19eA5IpRhtE30RvADFSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "751a93aa-5c0e-4b3f-85f2-83df318a5870", new DateTime(2022, 12, 9, 11, 42, 4, 745, DateTimeKind.Local).AddTicks(5708), "AQAAAAEAACcQAAAAEFBCeRZX4WoBso0NdFYz31da6UaYz4FffbxDpMPkAUWbPdtbhCi2ZElWkAYVk2poVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70bd814f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "2741f28f-55c8-4a49-8a23-5df37988d8f8", new DateTime(2022, 12, 9, 11, 42, 4, 751, DateTimeKind.Local).AddTicks(9559), "AQAAAAEAACcQAAAAEFrAB4gkh35v5L3zAzlUxlvhwa9tebK1AQLG0+EM3JVtSF2+hPYCuxqbwGiV/VYDdQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "1788c929-2042-4516-bce0-9e843500f97a", new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3522), "AQAAAAEAACcQAAAAEAefH9KFnKOPiWi53WS2qJRFK/ShGwOgFxf8wThggUzkdXCxmcMv7l4H5dRqqTUzkg==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 9, 11, 42, 4, 758, DateTimeKind.Local).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "ReturnRequests",
                columns: new[] { "Id", "AcceptedBy", "AssignedBy", "AssignedDate", "AssignmentId", "ReturnedDate", "State" },
                values: new object[,]
                {
                    { 1, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 2, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 2, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 3, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 3, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 4, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 4, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 5, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 6, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 6, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 7, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 7, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 8, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 8, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 9, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 9, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 10, null, new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 10, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_AcceptedBy",
                table: "ReturnRequests",
                column: "AcceptedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_AssignedBy",
                table: "ReturnRequests",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_AssignmentId",
                table: "ReturnRequests",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"),
                column: "ConcurrencyStamp",
                value: "33ed9da7-35aa-46da-9ed0-a7028245b937");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ec82f8a5-713b-4b22-8d7b-498d6e10270f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00bf"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "83ffff5c-3b00-4d82-bd66-2a2ae967fa4e", new DateTime(2022, 12, 2, 10, 31, 32, 992, DateTimeKind.Local).AddTicks(1385), "AQAAAAEAACcQAAAAEMdHb3SDr8KHSCwenrFwmAb2dpOrA4LvG0T9NxcTH7r7kucQtc60rLiAUdnHZi5xyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "4002fd1a-b92b-4ab9-a4b9-79ebd08ed61e", new DateTime(2022, 12, 2, 10, 31, 32, 984, DateTimeKind.Local).AddTicks(7978), "AQAAAAEAACcQAAAAEEn9e2wK6v4JMmITMiGhmTLPayo3vSSv0jtRIpnBqECNG+3Bd0MiVD/rhyt3GMCO6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d73e49a0-2ddf-47bd-b2fe-73eeffe4a074", new DateTime(2022, 12, 2, 10, 31, 32, 999, DateTimeKind.Local).AddTicks(5476), "AQAAAAEAACcQAAAAEP6U7ktsudVoP/LwXIVgG93lOt0f+JyG8sj8+xEeBtiAf5MEdQSzokKu0YjDmfrvuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("70bd814f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "6ac20c26-3534-48bb-9437-e942e40d3ece", new DateTime(2022, 12, 2, 10, 31, 33, 5, DateTimeKind.Local).AddTicks(9667), "AQAAAAEAACcQAAAAEFhCKEPsDMsG6dhsmCtSQ/zGK7poQ1vcMP9q6IdFYWOeuMpxmIGVFXkquGmvDlql8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f2269894-ed4c-43a3-94b8-ab807a039bd5", new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4035), "AQAAAAEAACcQAAAAEGoToFsr4EZJir6os3J0mz3W2BGHdFEr8M3etBs/E9GZfTUpm+wY7xmfs4BLlvNcCQ==" });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "InstalledDate",
                value: new DateTime(2022, 12, 2, 10, 31, 33, 12, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignedDate", "ReturnedDate" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
