﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Location = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLoginFirstTime = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AspNetUsers_AssignedBy",
                        column: x => x.AssignedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_AspNetUsers_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"), "ecf600aa-1ffb-4ed4-a318-2a3614d98a56", "Staff role", "Staff", "staff" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "bb69e31f-237f-4502-8db6-aeba009cd0fc", "Administrator role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Dob", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "IsLoginFirstTime", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StaffCode", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00bf"), 0, "f7299983-1e7e-4147-9428-f2c5abf0f6f9", new DateTime(2022, 11, 29, 14, 29, 8, 685, DateTimeKind.Local).AddTicks(4185), new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminhn@gmail.com", true, "Toan", 0, false, true, "Bach", 1, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminhn@gmail.com", "adminhn", "AQAAAAEAACcQAAAAEIEwNRgdYOLeT/+evslU/ll4lnIcNxcixli63RZnik51cktMxU88jS0Jmrhihj3O3A==", null, false, "", " SD0002", false, "adminhn" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "77061d73-3294-4097-9c63-77b0876534d2", new DateTime(2022, 11, 29, 14, 29, 8, 679, DateTimeKind.Local).AddTicks(2205), new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminhcm@gmail.com", true, "Toan", 0, false, false, "Bach", 0, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminhcm@gmail.com", "adminhcm", "AQAAAAEAACcQAAAAECHytNYcFIsR//sfscR5OLY1kzln0zSwOFoxuXCrZ786AQXrl0TSOHuFR/VOQQXQqA==", null, false, "", " SD0001", false, "adminhcm" },
                    { new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), 0, "066ebe40-2a94-4126-a66f-e3928f2aca9d", new DateTime(2022, 11, 29, 14, 29, 8, 691, DateTimeKind.Local).AddTicks(5702), new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@gmail.com", true, "Toan", 1, false, true, "Bach", 1, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@gmail.com", "staff1", "AQAAAAEAACcQAAAAEK2woAJ9Ut7H2JpMb3jMr+ezwam2DZJ25D40PpzaaNdBUHPxvuYNwBqB4sItLTJDkw==", null, false, "", " SD0003", false, "staff1" },
                    { new Guid("70bd814f-9576-45ba-b5b7-f00649be00de"), 0, "aec1d194-2023-41fe-979b-8fce9154ec12", new DateTime(2022, 11, 29, 14, 29, 8, 697, DateTimeKind.Local).AddTicks(7258), new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@gmail.com", true, "Toan", 1, false, true, "Bach", 1, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@gmail.com", "staff2", "AQAAAAEAACcQAAAAEN2BkjsVyaBZNvLbo8rl48N2dz3NRCoEnrLy2bu4I7eFYU7saEopHhRJ2QMPUIvH0Q==", null, false, "", " SD0004", false, "staff2" },
                    { new Guid("73bd714f-9576-45ba-b5b7-f00649be00de"), 0, "792ce414-7ddf-4776-8637-0ad164b83799", new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(8919), new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "staffdis@gmail.com", true, "Toan", 1, true, true, "Bach", 1, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "staffdis@gmail.com", "staffdis", "AQAAAAEAACcQAAAAEJpPxmwjE+37+Km/msxNhMuhIB8u24sK5xjPiPvfWMEAVVqaH4g/Mx9SYEymdy2reA==", null, false, "", " SD0005", false, "staffDis" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name", "Prefix" },
                values: new object[,]
                {
                    { 1, false, "Laptop", "LA" },
                    { 2, false, "Monitor", "MO" },
                    { 3, false, "Personal Computer", "PC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00bf") },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de") },
                    { new Guid("12147fe0-4571-4ad2-b8f7-d2c863eb78a5"), new Guid("73bd714f-9576-45ba-b5b7-f00649be00de") }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetCode", "CategoryId", "InstalledDate", "IsDeleted", "Location", "Name", "Specification", "State" },
                values: new object[,]
                {
                    { 1, "LA100001", 2, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9195), false, 0, "Laptop 1", "Core i1, 1GB RAM, 150 GB HDD, Window 1", 1 },
                    { 2, "LA100002", 1, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9209), true, 0, "Laptop 2", "Core i2, 2GB RAM, 250 GB HDD, Window 2", 0 },
                    { 3, "LA100003", 2, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9217), false, 0, "Laptop 3", "Core i3, 3GB RAM, 350 GB HDD, Window 3", 1 },
                    { 4, "LA100004", 1, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9336), true, 0, "Laptop 4", "Core i4, 4GB RAM, 450 GB HDD, Window 4", 0 },
                    { 5, "LA100005", 2, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9348), false, 0, "Laptop 5", "Core i5, 5GB RAM, 550 GB HDD, Window 5", 1 },
                    { 6, "LA100006", 1, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9358), true, 0, "Laptop 6", "Core i6, 6GB RAM, 650 GB HDD, Window 6", 0 },
                    { 7, "LA100007", 2, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9366), false, 0, "Laptop 7", "Core i7, 7GB RAM, 750 GB HDD, Window 7", 1 },
                    { 8, "LA100008", 1, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9374), true, 0, "Laptop 8", "Core i8, 8GB RAM, 850 GB HDD, Window 8", 0 },
                    { 9, "LA100009", 2, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9382), false, 0, "Laptop 9", "Core i9, 9GB RAM, 950 GB HDD, Window 9", 1 },
                    { 10, "LA1000010", 1, new DateTime(2022, 11, 29, 14, 29, 8, 703, DateTimeKind.Local).AddTicks(9393), true, 0, "Laptop 10", "Core i10, 10GB RAM, 1050 GB HDD, Window 10", 0 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssetId", "AssignedBy", "AssignedDate", "AssignedTo", "IsDeleted", "Note", "ReturnedDate", "State" },
                values: new object[,]
                {
                    { 1, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 1", new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 2", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 3, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 3", new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 4, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 4", new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 5, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 5", new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 6, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 6", new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 7, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 7", new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 8", new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 9, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 9", new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 10, null, new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), new Guid("70bd714f-9576-45ba-b5b7-f00649be00de"), false, "Note for assignment 10", new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
