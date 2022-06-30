using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmLibrary.DataRepository.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("078e804a-650b-4a49-a8b8-59d022a822d4"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("3953a537-4d69-4dc2-9f7c-371a55421cb9"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("6af838c2-7b99-4694-ad78-e6fddac242a3"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("a736799e-01d7-4d9a-95a1-74d34a6245f5"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("c6db8f2c-56d4-40de-abaa-aeab499f7689"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Films",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Directors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("22c977a8-683f-43e5-97ed-e411e9a0568b"), "General audiences – All ages admitted", "G" },
                    { new Guid("9903c142-6474-432e-97d4-5b66bd6a18c2"), "Parental guidance suggested – Some material may not be suitable for children", "PG" },
                    { new Guid("9e714ed4-a1a3-4e62-b49d-856b3009d528"), "Parents strongly cautioned – Some material may be inappropriate for children under 13", "PG-13" },
                    { new Guid("a4a5eb16-c029-4ae6-ae0a-f56bab161d7d"), "Restricted – Under 17 requires accompanying parent or adult guardian", "R" },
                    { new Guid("bf9c6f50-b7c2-4e2d-97fb-bd318a3977f3"), "Adults only – No one 17 and under admitted", "NC-17" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("22c977a8-683f-43e5-97ed-e411e9a0568b"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("9903c142-6474-432e-97d4-5b66bd6a18c2"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("9e714ed4-a1a3-4e62-b49d-856b3009d528"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("a4a5eb16-c029-4ae6-ae0a-f56bab161d7d"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("bf9c6f50-b7c2-4e2d-97fb-bd318a3977f3"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Plot",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("078e804a-650b-4a49-a8b8-59d022a822d4"), "General audiences – All ages admitted", "G" },
                    { new Guid("3953a537-4d69-4dc2-9f7c-371a55421cb9"), "Parental guidance suggested – Some material may not be suitable for children", "PG" },
                    { new Guid("6af838c2-7b99-4694-ad78-e6fddac242a3"), "Restricted – Under 17 requires accompanying parent or adult guardian", "R" },
                    { new Guid("a736799e-01d7-4d9a-95a1-74d34a6245f5"), "Parents strongly cautioned – Some material may be inappropriate for children under 13", "PG-13" },
                    { new Guid("c6db8f2c-56d4-40de-abaa-aeab499f7689"), "Adults only – No one 17 and under admitted", "NC-17" }
                });
        }
    }
}
