using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBio.Migrations
{
    public partial class afteraddingtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Iron Man 1" },
                    { 2, "SpiderMan Far From Home" },
                    { 3, "Cars 1" }
                });

            migrationBuilder.InsertData(
                table: "Salon",
                columns: new[] { "Id", "Name", "NumOfSeats" },
                values: new object[] { 1, "1", 50 });

            migrationBuilder.InsertData(
                table: "ShowCase",
                columns: new[] { "Id", "AvailableSeats", "MovieId", "SalonId", "Starts" },
                values: new object[] { 1, 50, 1, 1, new DateTime(2022, 5, 20, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ShowCase",
                columns: new[] { "Id", "AvailableSeats", "MovieId", "SalonId", "Starts" },
                values: new object[] { 2, 50, 2, 1, new DateTime(2022, 5, 20, 22, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShowCase",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShowCase",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salon",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
