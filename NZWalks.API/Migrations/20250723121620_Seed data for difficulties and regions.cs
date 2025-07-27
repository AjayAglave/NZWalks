using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeddatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegionImageUrl",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("501dfbd8-4c64-4eaa-a961-94b5ee5751c0"), "Easy" },
                    { new Guid("6abaea43-513d-414a-87ab-2d5879ba5d34"), "Hard" },
                    { new Guid("8c91828d-5c9c-41b1-9a36-43ee0f7a3210"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("13c0cc3e-b9d6-4788-89a2-91a16d456c73"), "TRG", "Tauranga", "TaurangaImageUrl" },
                    { new Guid("1a88e888-44e8-414d-897b-a13c120a0bec"), "AKL", "Auckland", "AucklandImageUrl" },
                    { new Guid("7579d713-bf23-4af1-9198-e1924d4f9aea"), "HLZ", "Hamilton", "HamiltonImageUrl" },
                    { new Guid("8d1ae977-4cf6-4477-a43a-bf3f49c50b51"), "WLG", "Wellington", "WellingtonImageUrl" },
                    { new Guid("ba4082ec-4094-40b7-acdc-db15ea6607e9"), "DUD", "Dunedin", "DunedinImageUrl" },
                    { new Guid("d027a0d8-cfa9-4359-95b6-dba4c9be34d1"), "CHC", "Christchurch", "ChristchurchImageUrl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("501dfbd8-4c64-4eaa-a961-94b5ee5751c0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6abaea43-513d-414a-87ab-2d5879ba5d34"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8c91828d-5c9c-41b1-9a36-43ee0f7a3210"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("13c0cc3e-b9d6-4788-89a2-91a16d456c73"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a88e888-44e8-414d-897b-a13c120a0bec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7579d713-bf23-4af1-9198-e1924d4f9aea"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8d1ae977-4cf6-4477-a43a-bf3f49c50b51"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ba4082ec-4094-40b7-acdc-db15ea6607e9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d027a0d8-cfa9-4359-95b6-dba4c9be34d1"));

            migrationBuilder.AlterColumn<string>(
                name: "RegionImageUrl",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
