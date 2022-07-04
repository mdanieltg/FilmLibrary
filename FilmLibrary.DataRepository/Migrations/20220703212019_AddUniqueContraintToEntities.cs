using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLibrary.DataRepository.Migrations
{
    public partial class AddUniqueContraintToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ratings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ratings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0489f31a-b9a7-4160-ffa5-08da5c884309"), "Terror" },
                    { new Guid("0ef4d820-96f4-476b-ffa9-08da5c884309"), "Musical" },
                    { new Guid("10cb7746-bec4-4e24-ffaa-08da5c884309"), "Western" },
                    { new Guid("1e7ec66d-6114-4710-ffa8-08da5c884309"), "Crimen" },
                    { new Guid("34dd8660-b7da-4626-cc71-08da5b7b0adb"), "Acción" },
                    { new Guid("35b924df-d199-45a5-cc6d-08da5b7b0adb"), "Ciencia ficción" },
                    { new Guid("441b397f-7af0-46ca-ffa7-08da5c884309"), "Comedia" },
                    { new Guid("4dd12164-0e2c-4d55-cc70-08da5b7b0adb"), "Romance" },
                    { new Guid("4ea80f53-593c-4636-cc6f-08da5b7b0adb"), "Drama" },
                    { new Guid("c1c843db-ad47-4d0b-cc6c-08da5b7b0adb"), "Fantasía" },
                    { new Guid("ed8c8d63-416b-452d-cc6e-08da5b7b0adb"), "Suspenso" },
                    { new Guid("ffe8aac7-2fd7-4ef1-ffa6-08da5c884309"), "Documental" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Name",
                table: "Ratings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_Title",
                table: "Films",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_Name",
                table: "Directors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_Name",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Films_Title",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Directors_Name",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0489f31a-b9a7-4160-ffa5-08da5c884309"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0ef4d820-96f4-476b-ffa9-08da5c884309"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("10cb7746-bec4-4e24-ffaa-08da5c884309"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1e7ec66d-6114-4710-ffa8-08da5c884309"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("34dd8660-b7da-4626-cc71-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("35b924df-d199-45a5-cc6d-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("441b397f-7af0-46ca-ffa7-08da5c884309"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4dd12164-0e2c-4d55-cc70-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4ea80f53-593c-4636-cc6f-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c1c843db-ad47-4d0b-cc6c-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ed8c8d63-416b-452d-cc6e-08da5b7b0adb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ffe8aac7-2fd7-4ef1-ffa6-08da5c884309"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
