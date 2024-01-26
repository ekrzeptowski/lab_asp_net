using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NormalizedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a212c45-939f-49fe-9ec7-94ecc423bcc4", "1601743c-e69a-42d6-91ac-08c0ec2b2a8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b338210-23d1-4cf7-86cc-b5d85a3467a0", "5449b2e5-f35a-4b0e-9c8f-9bd591efaa01" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a212c45-939f-49fe-9ec7-94ecc423bcc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b338210-23d1-4cf7-86cc-b5d85a3467a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1601743c-e69a-42d6-91ac-08c0ec2b2a8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5449b2e5-f35a-4b0e-9c8f-9bd591efaa01");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2a212c45-939f-49fe-9ec7-94ecc423bcc4", "2a212c45-939f-49fe-9ec7-94ecc423bcc4", "admin", "ADMIN" },
                    { "9b338210-23d1-4cf7-86cc-b5d85a3467a0", "9b338210-23d1-4cf7-86cc-b5d85a3467a0", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1601743c-e69a-42d6-91ac-08c0ec2b2a8a", 0, "e0d151ec-6426-46d9-a049-b7573a55412e", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEG+rWFPO/PLCTjlGSwHVGa5+eguEmFaumT9LUgV+RZhh+gW3l596h0nZGBPtc9eKRg==", null, false, "8adfc132-a1e7-46e2-a23d-ddb7d06689e7", false, "adam" },
                    { "5449b2e5-f35a-4b0e-9c8f-9bd591efaa01", 0, "1ca1d859-748a-49b7-b8dd-0d94839f2904", "user@wsei.edu.pl", true, false, null, null, "USER", "AQAAAAIAAYagAAAAEB9I+7yKA08KNVOC3UJ2qFemOB16ityIKhUwbJQCALIiKtrwbQuZZnlq1RqryiOsKA==", null, false, "8c902cc7-c8cb-4611-ba68-92642dffcdd7", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2a212c45-939f-49fe-9ec7-94ecc423bcc4", "1601743c-e69a-42d6-91ac-08c0ec2b2a8a" },
                    { "9b338210-23d1-4cf7-86cc-b5d85a3467a0", "5449b2e5-f35a-4b0e-9c8f-9bd591efaa01" }
                });
        }
    }
}
