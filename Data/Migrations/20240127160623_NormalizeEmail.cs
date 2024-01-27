using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9bc3104c-0080-4991-9768-45de4a58d3ca", "1e5a8bd6-f11b-452f-8151-5fc58d82010b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57754cb2-bfa9-42bb-98b0-6bd149ef60c9", "2fdcc70f-2b03-45df-9890-216a34b73494" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57754cb2-bfa9-42bb-98b0-6bd149ef60c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bc3104c-0080-4991-9768-45de4a58d3ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e5a8bd6-f11b-452f-8151-5fc58d82010b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fdcc70f-2b03-45df-9890-216a34b73494");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08eb56fa-00b4-4f52-a84b-b8d26be8c24c", "08eb56fa-00b4-4f52-a84b-b8d26be8c24c", "admin", "ADMIN" },
                    { "dc590230-d1a1-4bd6-89ed-a520c161fed5", "dc590230-d1a1-4bd6-89ed-a520c161fed5", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "996dbf9f-aabc-46bb-a426-9fbd060e12c1", 0, "87c1cab4-9c62-4b72-b405-c36e97029693", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAEKWMxXESiG4pG/lyA4bIZTlhm7KNn59GNLqDlAjNtMouycDxo2yumdkOQavxguWYiQ==", null, false, "7f9bb05d-359f-4e5d-83bd-19337d4ae112", false, "adam" },
                    { "fd6236a6-81c3-41ae-9436-b1e8851fb79f", 0, "e17fb112-8989-4eaf-94f6-18cec5eb1dcf", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEFeDKoogm8SRt1RsgRJQVdQveYAUmw2N80jJTwhJ2WHX5GaOjZH5L0wv7anIzAklTA==", null, false, "882dcc64-abad-474a-b3fb-4629b212bfe5", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "08eb56fa-00b4-4f52-a84b-b8d26be8c24c", "996dbf9f-aabc-46bb-a426-9fbd060e12c1" },
                    { "dc590230-d1a1-4bd6-89ed-a520c161fed5", "fd6236a6-81c3-41ae-9436-b1e8851fb79f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08eb56fa-00b4-4f52-a84b-b8d26be8c24c", "996dbf9f-aabc-46bb-a426-9fbd060e12c1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc590230-d1a1-4bd6-89ed-a520c161fed5", "fd6236a6-81c3-41ae-9436-b1e8851fb79f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08eb56fa-00b4-4f52-a84b-b8d26be8c24c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc590230-d1a1-4bd6-89ed-a520c161fed5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "996dbf9f-aabc-46bb-a426-9fbd060e12c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd6236a6-81c3-41ae-9436-b1e8851fb79f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57754cb2-bfa9-42bb-98b0-6bd149ef60c9", "57754cb2-bfa9-42bb-98b0-6bd149ef60c9", "admin", "ADMIN" },
                    { "9bc3104c-0080-4991-9768-45de4a58d3ca", "9bc3104c-0080-4991-9768-45de4a58d3ca", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e5a8bd6-f11b-452f-8151-5fc58d82010b", 0, "1bfb3b63-ecdf-47a3-b222-82cf536b2ea7", "user@wsei.edu.pl", true, false, null, "user@wsei.edu.pl", "USER", "AQAAAAIAAYagAAAAEKCBHS9uo64N4ZetHE7wE3j76c5Gkhb/982GFJ6D9P5GxhdYOvrWtcBJUfTmyZoQqg==", null, false, "1523cf6a-5812-422b-8115-716596cecccb", false, "user" },
                    { "2fdcc70f-2b03-45df-9890-216a34b73494", 0, "e53c7dcc-45ec-43e6-8afb-5b046e89226a", "adam@wsei.edu.pl", true, false, null, "adam@wsei.edu.pl", "ADMIN", "AQAAAAIAAYagAAAAEK7BV7Sd4LwbfupXMvyjdykochP8p9/ix1Hma+yJLOPu86xbxMpqfr4TJdN3MqFejA==", null, false, "de0c09b9-021e-4ab9-bc7b-cb3cfb649027", false, "adam" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9bc3104c-0080-4991-9768-45de4a58d3ca", "1e5a8bd6-f11b-452f-8151-5fc58d82010b" },
                    { "57754cb2-bfa9-42bb-98b0-6bd149ef60c9", "2fdcc70f-2b03-45df-9890-216a34b73494" }
                });
        }
    }
}
