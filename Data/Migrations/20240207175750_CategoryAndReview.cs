using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6de274b6-7730-4315-8906-f1a2667f30d7", "6de274b6-7730-4315-8906-f1a2667f30d7", "user", "USER" },
                    { "90e05465-6bb3-4c5d-8632-5168306a59a1", "90e05465-6bb3-4c5d-8632-5168306a59a1", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "818e484a-4bdf-4213-81cf-bed32f900561", 0, "d71dcbd2-891e-4196-8fc1-ef6dbe26a0c0", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAIAAYagAAAAENlpRXZ3reGtoerx6ZbE66ablOdHgq9BGoYJ4GEOr9sQ33gKF/X1B5J1qb9EvuJrsg==", null, false, "61baf8f4-be02-4eec-a1ca-866ae59acc25", false, "adam" },
                    { "83c789bc-38a3-4604-9f3e-f59f228dfee0", 0, "b4530aac-d39a-41bc-9931-e18909a9a7eb", "user3@wsei.edu.pl", true, false, null, "USER3@WSEI.EDU.PL", "USER3", "AQAAAAIAAYagAAAAEHhiLGHNIgleB4PnhA8md1YNgVSqDhm6tThFF/HFRrl7godxE2Y2o8ujFKTymZQkCw==", null, false, "e94bf4fd-9339-4b39-bec5-5f0d1d4f68c7", false, "user3" },
                    { "b6e0d80d-317d-40ae-8672-f02b39b2e006", 0, "250675c6-5789-4d09-8d06-cd701c46dbf0", "user2@wsei.edu.pl", true, false, null, "USER2@WSEI.EDU.PL", "USER2", "AQAAAAIAAYagAAAAENdWMKaYTx1EJUDSXM/6SCnUcaZIOtBfsmLI7XHdtzPkBkbRIMA9gw3IL9i1+R2MfQ==", null, false, "ea1ca5b2-0c14-4bc4-a2a6-0ac68b09bfe2", false, "user2" },
                    { "d0af24da-0223-4121-a3fd-3d157622d607", 0, "26c6d9b8-6068-4533-b39d-d949ef1a4290", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEGEfKJMuIvzQmzHXW03Ka7vA3/a1LgIrMjh+SC0Bye3zlABo8FTL3z8XWIs+XyVPyg==", null, false, "e7220cb6-6510-4892-b7fb-8b9c7f524008", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Dom i ogród" },
                    { 2, null, "Odzież i akcesoria" },
                    { 3, null, "Sport i turystyka" }
                });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Name", "Price", "ProductionDate" },
                values: new object[] { 1, "Opis młynka do pieprzu", "Młynek do pieprzu", 15.0m, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, "Opis rękawiczek wełnianych zimowych", "Rękawiczki wełniane zimowe", 241.13m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, "Opis maty do ćwiczeń", "Mata do ćwiczeń", 39.99m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "90e05465-6bb3-4c5d-8632-5168306a59a1", "818e484a-4bdf-4213-81cf-bed32f900561" },
                    { "6de274b6-7730-4315-8906-f1a2667f30d7", "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { "6de274b6-7730-4315-8906-f1a2667f30d7", "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { "6de274b6-7730-4315-8906-f1a2667f30d7", "d0af24da-0223-4121-a3fd-3d157622d607" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Producent", "ProductionDate" },
                values: new object[,]
                {
                    { 4, 1, "Opis mopa z mikrofibry", "Mop z mikrofibry", 70.0m, "Producent76", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "Opis wagi cyfrowej", "Waga cyfrowa", 150.0m, "Producent1", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, "Opis produktu nr 6", "Produkt nr 6", 59.4m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, "Opis produktu nr 7", "Produkt nr 7", 69.3m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, "Opis produktu nr 8", "Produkt nr 8", 79.2m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, "Opis produktu nr 9", "Produkt nr 9", 89.1m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, "Opis produktu nr 10", "Produkt nr 10", 99.0m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, "Opis produktu nr 11", "Produkt nr 11", 108.9m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, "Opis produktu nr 12", "Produkt nr 12", 118.8m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, "Opis produktu nr 13", "Produkt nr 13", 128.7m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 3, "Opis produktu nr 14", "Produkt nr 14", 138.6m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, "Opis produktu nr 15", "Produkt nr 15", 148.5m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, "Opis produktu nr 16", "Produkt nr 16", 158.4m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 3, "Opis produktu nr 17", "Produkt nr 17", 168.3m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, "Opis produktu nr 18", "Produkt nr 18", 178.2m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, "Opis produktu nr 19", "Produkt nr 19", 188.1m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 3, "Opis produktu nr 20", "Produkt nr 20", 198.0m, "Producent1", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, "Opis produktu nr 21", "Produkt nr 21", 207.9m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, "Opis produktu nr 22", "Produkt nr 22", 217.8m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, "Opis produktu nr 23", "Produkt nr 23", 227.7m, "Producent2", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, "Opis produktu nr 24", "Produkt nr 24", 237.6m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, "Opis produktu nr 25", "Produkt nr 25", 247.5m, "Producent3", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "Id", "Comment", "ProductId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Bardzo fajny produkt", 1, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 2, "Nie polecam", 1, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 3, "Bardzo fajny produkt", 2, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 4, "Bardzo fajny produkt", 3, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 25, "Komentarz produktu nr 1", 1, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 26, "Komentarz produktu nr 2", 2, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 27, "Komentarz produktu nr 3", 3, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 50, "Komentarz produktu nr 1", 1, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 51, "Komentarz produktu nr 2", 2, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 52, "Komentarz produktu nr 3", 3, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 75, "Komentarz produktu nr 1", 1, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 76, "Komentarz produktu nr 2", 2, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 77, "Komentarz produktu nr 3", 3, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 100, "Komentarz produktu nr 1", 1, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 101, "Komentarz produktu nr 2", 2, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 102, "Komentarz produktu nr 3", 3, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 125, "Komentarz produktu nr 1", 1, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 126, "Komentarz produktu nr 2", 2, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 127, "Komentarz produktu nr 3", 3, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 150, "Komentarz produktu nr 1", 1, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 151, "Komentarz produktu nr 2", 2, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 152, "Komentarz produktu nr 3", 3, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 175, "Komentarz produktu nr 1", 1, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 176, "Komentarz produktu nr 2", 2, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 177, "Komentarz produktu nr 3", 3, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 200, "Komentarz produktu nr 1", 1, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 201, "Komentarz produktu nr 2", 2, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 202, "Komentarz produktu nr 3", 3, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 225, "Komentarz produktu nr 1", 1, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 226, "Komentarz produktu nr 2", 2, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 227, "Komentarz produktu nr 3", 3, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 250, "Komentarz produktu nr 1", 1, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 251, "Komentarz produktu nr 2", 2, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 252, "Komentarz produktu nr 3", 3, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 275, "Komentarz produktu nr 1", 1, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 276, "Komentarz produktu nr 2", 2, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 277, "Komentarz produktu nr 3", 3, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 300, "Komentarz produktu nr 1", 1, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 5, "Komentarz produktu nr 6", 6, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 6, "Komentarz produktu nr 7", 7, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 7, "Komentarz produktu nr 8", 8, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 8, "Komentarz produktu nr 9", 9, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 9, "Komentarz produktu nr 10", 10, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 10, "Komentarz produktu nr 11", 11, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 11, "Komentarz produktu nr 12", 12, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 12, "Komentarz produktu nr 13", 13, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 13, "Komentarz produktu nr 14", 14, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 14, "Komentarz produktu nr 15", 15, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 15, "Komentarz produktu nr 16", 16, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 16, "Komentarz produktu nr 17", 17, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 17, "Komentarz produktu nr 18", 18, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 18, "Komentarz produktu nr 19", 19, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 19, "Komentarz produktu nr 20", 20, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 20, "Komentarz produktu nr 21", 21, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 21, "Komentarz produktu nr 22", 22, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 22, "Komentarz produktu nr 23", 23, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 23, "Komentarz produktu nr 24", 24, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 24, "Komentarz produktu nr 25", 25, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 28, "Komentarz produktu nr 4", 4, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 29, "Komentarz produktu nr 5", 5, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 30, "Komentarz produktu nr 6", 6, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 31, "Komentarz produktu nr 7", 7, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 32, "Komentarz produktu nr 8", 8, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 33, "Komentarz produktu nr 9", 9, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 34, "Komentarz produktu nr 10", 10, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 35, "Komentarz produktu nr 11", 11, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 36, "Komentarz produktu nr 12", 12, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 37, "Komentarz produktu nr 13", 13, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 38, "Komentarz produktu nr 14", 14, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 39, "Komentarz produktu nr 15", 15, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 40, "Komentarz produktu nr 16", 16, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 41, "Komentarz produktu nr 17", 17, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 42, "Komentarz produktu nr 18", 18, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 43, "Komentarz produktu nr 19", 19, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 44, "Komentarz produktu nr 20", 20, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 45, "Komentarz produktu nr 21", 21, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 46, "Komentarz produktu nr 22", 22, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 47, "Komentarz produktu nr 23", 23, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 48, "Komentarz produktu nr 24", 24, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 49, "Komentarz produktu nr 25", 25, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 53, "Komentarz produktu nr 4", 4, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 54, "Komentarz produktu nr 5", 5, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 55, "Komentarz produktu nr 6", 6, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 56, "Komentarz produktu nr 7", 7, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 57, "Komentarz produktu nr 8", 8, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 58, "Komentarz produktu nr 9", 9, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 59, "Komentarz produktu nr 10", 10, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 60, "Komentarz produktu nr 11", 11, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 61, "Komentarz produktu nr 12", 12, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 62, "Komentarz produktu nr 13", 13, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 63, "Komentarz produktu nr 14", 14, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 64, "Komentarz produktu nr 15", 15, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 65, "Komentarz produktu nr 16", 16, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 66, "Komentarz produktu nr 17", 17, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 67, "Komentarz produktu nr 18", 18, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 68, "Komentarz produktu nr 19", 19, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 69, "Komentarz produktu nr 20", 20, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 70, "Komentarz produktu nr 21", 21, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 71, "Komentarz produktu nr 22", 22, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 72, "Komentarz produktu nr 23", 23, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 73, "Komentarz produktu nr 24", 24, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 74, "Komentarz produktu nr 25", 25, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 78, "Komentarz produktu nr 4", 4, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 79, "Komentarz produktu nr 5", 5, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 80, "Komentarz produktu nr 6", 6, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 81, "Komentarz produktu nr 7", 7, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 82, "Komentarz produktu nr 8", 8, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 83, "Komentarz produktu nr 9", 9, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 84, "Komentarz produktu nr 10", 10, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 85, "Komentarz produktu nr 11", 11, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 86, "Komentarz produktu nr 12", 12, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 87, "Komentarz produktu nr 13", 13, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 88, "Komentarz produktu nr 14", 14, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 89, "Komentarz produktu nr 15", 15, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 90, "Komentarz produktu nr 16", 16, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 91, "Komentarz produktu nr 17", 17, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 92, "Komentarz produktu nr 18", 18, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 93, "Komentarz produktu nr 19", 19, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 94, "Komentarz produktu nr 20", 20, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 95, "Komentarz produktu nr 21", 21, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 96, "Komentarz produktu nr 22", 22, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 97, "Komentarz produktu nr 23", 23, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 98, "Komentarz produktu nr 24", 24, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 99, "Komentarz produktu nr 25", 25, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 103, "Komentarz produktu nr 4", 4, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 104, "Komentarz produktu nr 5", 5, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 105, "Komentarz produktu nr 6", 6, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 106, "Komentarz produktu nr 7", 7, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 107, "Komentarz produktu nr 8", 8, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 108, "Komentarz produktu nr 9", 9, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 109, "Komentarz produktu nr 10", 10, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 110, "Komentarz produktu nr 11", 11, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 111, "Komentarz produktu nr 12", 12, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 112, "Komentarz produktu nr 13", 13, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 113, "Komentarz produktu nr 14", 14, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 114, "Komentarz produktu nr 15", 15, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 115, "Komentarz produktu nr 16", 16, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 116, "Komentarz produktu nr 17", 17, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 117, "Komentarz produktu nr 18", 18, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 118, "Komentarz produktu nr 19", 19, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 119, "Komentarz produktu nr 20", 20, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 120, "Komentarz produktu nr 21", 21, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 121, "Komentarz produktu nr 22", 22, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 122, "Komentarz produktu nr 23", 23, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 123, "Komentarz produktu nr 24", 24, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 124, "Komentarz produktu nr 25", 25, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 128, "Komentarz produktu nr 4", 4, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 129, "Komentarz produktu nr 5", 5, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 130, "Komentarz produktu nr 6", 6, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 131, "Komentarz produktu nr 7", 7, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 132, "Komentarz produktu nr 8", 8, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 133, "Komentarz produktu nr 9", 9, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 134, "Komentarz produktu nr 10", 10, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 135, "Komentarz produktu nr 11", 11, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 136, "Komentarz produktu nr 12", 12, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 137, "Komentarz produktu nr 13", 13, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 138, "Komentarz produktu nr 14", 14, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 139, "Komentarz produktu nr 15", 15, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 140, "Komentarz produktu nr 16", 16, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 141, "Komentarz produktu nr 17", 17, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 142, "Komentarz produktu nr 18", 18, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 143, "Komentarz produktu nr 19", 19, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 144, "Komentarz produktu nr 20", 20, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 145, "Komentarz produktu nr 21", 21, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 146, "Komentarz produktu nr 22", 22, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 147, "Komentarz produktu nr 23", 23, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 148, "Komentarz produktu nr 24", 24, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 149, "Komentarz produktu nr 25", 25, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 153, "Komentarz produktu nr 4", 4, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 154, "Komentarz produktu nr 5", 5, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 155, "Komentarz produktu nr 6", 6, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 156, "Komentarz produktu nr 7", 7, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 157, "Komentarz produktu nr 8", 8, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 158, "Komentarz produktu nr 9", 9, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 159, "Komentarz produktu nr 10", 10, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 160, "Komentarz produktu nr 11", 11, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 161, "Komentarz produktu nr 12", 12, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 162, "Komentarz produktu nr 13", 13, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 163, "Komentarz produktu nr 14", 14, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 164, "Komentarz produktu nr 15", 15, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 165, "Komentarz produktu nr 16", 16, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 166, "Komentarz produktu nr 17", 17, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 167, "Komentarz produktu nr 18", 18, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 168, "Komentarz produktu nr 19", 19, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 169, "Komentarz produktu nr 20", 20, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 170, "Komentarz produktu nr 21", 21, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 171, "Komentarz produktu nr 22", 22, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 172, "Komentarz produktu nr 23", 23, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 173, "Komentarz produktu nr 24", 24, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 174, "Komentarz produktu nr 25", 25, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 178, "Komentarz produktu nr 4", 4, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 179, "Komentarz produktu nr 5", 5, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 180, "Komentarz produktu nr 6", 6, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 181, "Komentarz produktu nr 7", 7, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 182, "Komentarz produktu nr 8", 8, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 183, "Komentarz produktu nr 9", 9, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 184, "Komentarz produktu nr 10", 10, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 185, "Komentarz produktu nr 11", 11, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 186, "Komentarz produktu nr 12", 12, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 187, "Komentarz produktu nr 13", 13, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 188, "Komentarz produktu nr 14", 14, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 189, "Komentarz produktu nr 15", 15, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 190, "Komentarz produktu nr 16", 16, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 191, "Komentarz produktu nr 17", 17, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 192, "Komentarz produktu nr 18", 18, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 193, "Komentarz produktu nr 19", 19, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 194, "Komentarz produktu nr 20", 20, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 195, "Komentarz produktu nr 21", 21, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 196, "Komentarz produktu nr 22", 22, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 197, "Komentarz produktu nr 23", 23, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 198, "Komentarz produktu nr 24", 24, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 199, "Komentarz produktu nr 25", 25, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 203, "Komentarz produktu nr 4", 4, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 204, "Komentarz produktu nr 5", 5, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 205, "Komentarz produktu nr 6", 6, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 206, "Komentarz produktu nr 7", 7, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 207, "Komentarz produktu nr 8", 8, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 208, "Komentarz produktu nr 9", 9, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 209, "Komentarz produktu nr 10", 10, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 210, "Komentarz produktu nr 11", 11, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 211, "Komentarz produktu nr 12", 12, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 212, "Komentarz produktu nr 13", 13, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 213, "Komentarz produktu nr 14", 14, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 214, "Komentarz produktu nr 15", 15, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 215, "Komentarz produktu nr 16", 16, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 216, "Komentarz produktu nr 17", 17, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 217, "Komentarz produktu nr 18", 18, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 218, "Komentarz produktu nr 19", 19, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 219, "Komentarz produktu nr 20", 20, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 220, "Komentarz produktu nr 21", 21, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 221, "Komentarz produktu nr 22", 22, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 222, "Komentarz produktu nr 23", 23, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 223, "Komentarz produktu nr 24", 24, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 224, "Komentarz produktu nr 25", 25, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 228, "Komentarz produktu nr 4", 4, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 229, "Komentarz produktu nr 5", 5, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 230, "Komentarz produktu nr 6", 6, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 231, "Komentarz produktu nr 7", 7, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 232, "Komentarz produktu nr 8", 8, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 233, "Komentarz produktu nr 9", 9, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 234, "Komentarz produktu nr 10", 10, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 235, "Komentarz produktu nr 11", 11, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 236, "Komentarz produktu nr 12", 12, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 237, "Komentarz produktu nr 13", 13, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 238, "Komentarz produktu nr 14", 14, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 239, "Komentarz produktu nr 15", 15, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 240, "Komentarz produktu nr 16", 16, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 241, "Komentarz produktu nr 17", 17, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 242, "Komentarz produktu nr 18", 18, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 243, "Komentarz produktu nr 19", 19, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 244, "Komentarz produktu nr 20", 20, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 245, "Komentarz produktu nr 21", 21, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 246, "Komentarz produktu nr 22", 22, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 247, "Komentarz produktu nr 23", 23, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 248, "Komentarz produktu nr 24", 24, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 249, "Komentarz produktu nr 25", 25, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 253, "Komentarz produktu nr 4", 4, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 254, "Komentarz produktu nr 5", 5, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 255, "Komentarz produktu nr 6", 6, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 256, "Komentarz produktu nr 7", 7, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 257, "Komentarz produktu nr 8", 8, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 258, "Komentarz produktu nr 9", 9, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 259, "Komentarz produktu nr 10", 10, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 260, "Komentarz produktu nr 11", 11, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 261, "Komentarz produktu nr 12", 12, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 262, "Komentarz produktu nr 13", 13, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 263, "Komentarz produktu nr 14", 14, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 264, "Komentarz produktu nr 15", 15, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 265, "Komentarz produktu nr 16", 16, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 266, "Komentarz produktu nr 17", 17, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 267, "Komentarz produktu nr 18", 18, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 268, "Komentarz produktu nr 19", 19, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 269, "Komentarz produktu nr 20", 20, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 270, "Komentarz produktu nr 21", 21, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 271, "Komentarz produktu nr 22", 22, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 272, "Komentarz produktu nr 23", 23, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 273, "Komentarz produktu nr 24", 24, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 274, "Komentarz produktu nr 25", 25, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 278, "Komentarz produktu nr 4", 4, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 279, "Komentarz produktu nr 5", 5, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 280, "Komentarz produktu nr 6", 6, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 281, "Komentarz produktu nr 7", 7, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 282, "Komentarz produktu nr 8", 8, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 283, "Komentarz produktu nr 9", 9, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 284, "Komentarz produktu nr 10", 10, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 285, "Komentarz produktu nr 11", 11, 1, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 286, "Komentarz produktu nr 12", 12, 2, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 287, "Komentarz produktu nr 13", 13, 3, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 288, "Komentarz produktu nr 14", 14, 4, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 289, "Komentarz produktu nr 15", 15, 5, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 290, "Komentarz produktu nr 16", 16, 1, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 291, "Komentarz produktu nr 17", 17, 2, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 292, "Komentarz produktu nr 18", 18, 3, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 293, "Komentarz produktu nr 19", 19, 4, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 294, "Komentarz produktu nr 20", 20, 5, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 295, "Komentarz produktu nr 21", 21, 1, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 296, "Komentarz produktu nr 22", 22, 2, "83c789bc-38a3-4604-9f3e-f59f228dfee0" },
                    { 297, "Komentarz produktu nr 23", 23, 3, "d0af24da-0223-4121-a3fd-3d157622d607" },
                    { 298, "Komentarz produktu nr 24", 24, 4, "b6e0d80d-317d-40ae-8672-f02b39b2e006" },
                    { 299, "Komentarz produktu nr 25", 25, 5, "83c789bc-38a3-4604-9f3e-f59f228dfee0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ProductId",
                table: "reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "90e05465-6bb3-4c5d-8632-5168306a59a1", "818e484a-4bdf-4213-81cf-bed32f900561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6de274b6-7730-4315-8906-f1a2667f30d7", "83c789bc-38a3-4604-9f3e-f59f228dfee0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6de274b6-7730-4315-8906-f1a2667f30d7", "b6e0d80d-317d-40ae-8672-f02b39b2e006" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6de274b6-7730-4315-8906-f1a2667f30d7", "d0af24da-0223-4121-a3fd-3d157622d607" });

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6de274b6-7730-4315-8906-f1a2667f30d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90e05465-6bb3-4c5d-8632-5168306a59a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "818e484a-4bdf-4213-81cf-bed32f900561");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83c789bc-38a3-4604-9f3e-f59f228dfee0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6e0d80d-317d-40ae-8672-f02b39b2e006");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0af24da-0223-4121-a3fd-3d157622d607");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

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

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "ProductionDate" },
                values: new object[] { "Description1", "Product1 abc", 10.0m, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { null, "Product2 def", 0.99m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Description3", "Product3 ghi", 389.99m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ed74ec84-6236-4e16-9f81-de104bd76d06", "3d0fe541-2776-410b-8bb7-42486fe0961c" },
                    { "1daf4a70-b2a9-48a1-889d-27d0c61412b5", "55d210bd-5293-456e-b76a-c3e6319b8982" }
                });
        }
    }
}
