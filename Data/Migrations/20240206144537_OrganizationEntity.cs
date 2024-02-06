using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1daf4a70-b2a9-48a1-889d-27d0c61412b5", "1daf4a70-b2a9-48a1-889d-27d0c61412b5", "user", "USER" },
                    { "ed74ec84-6236-4e16-9f81-de104bd76d06", "ed74ec84-6236-4e16-9f81-de104bd76d06", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3d0fe541-2776-410b-8bb7-42486fe0961c", 0, "58b56adc-0a03-4fb2-bbb7-dd8863994e71", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAECM2C6T9lMCljA9wqKCBRKLfGoxAn0REzlfvfZIeiqomWO0NGAFnRnY7D+REhj2pfg==", null, false, "ed566664-958c-4044-9a1e-e32e36e8c9f2", false, "adam" },
                    { "55d210bd-5293-456e-b76a-c3e6319b8982", 0, "ebef2507-566b-4ed8-920a-520f339966ec", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEFz+ixhIfCyI5tzw+i+yaTKATExzzjeTqud7l/37lKCFvmyQ0LtUm86WE1TWzGNq5Q==", null, false, "04b81beb-96ae-45cf-911c-7b01285417ca", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 1, "Kraków", "31-150", "małopolskie", "Św. Filipa 17", "83492384", "13424234", "WSEI" },
                    { 2, "Kraków", "31-150", "małopolskie", "Krowoderska 45/6", "2498534", "0873439249", "Firma" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrganizationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrganizationId",
                value: 2);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ed74ec84-6236-4e16-9f81-de104bd76d06", "3d0fe541-2776-410b-8bb7-42486fe0961c" },
                    { "1daf4a70-b2a9-48a1-889d-27d0c61412b5", "55d210bd-5293-456e-b76a-c3e6319b8982" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed74ec84-6236-4e16-9f81-de104bd76d06", "3d0fe541-2776-410b-8bb7-42486fe0961c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1daf4a70-b2a9-48a1-889d-27d0c61412b5", "55d210bd-5293-456e-b76a-c3e6319b8982" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1daf4a70-b2a9-48a1-889d-27d0c61412b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed74ec84-6236-4e16-9f81-de104bd76d06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0fe541-2776-410b-8bb7-42486fe0961c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55d210bd-5293-456e-b76a-c3e6319b8982");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

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
    }
}
