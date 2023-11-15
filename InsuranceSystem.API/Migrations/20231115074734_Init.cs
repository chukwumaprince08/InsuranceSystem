using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyHolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIDNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHolders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PolicyHolders",
                columns: new[] { "Id", "DateCreated", "DateModified", "DateOfBirth", "Name", "NationalIDNumber", "PolicyNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1690), new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1720), new DateTime(2000, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Precious", "NGN0014AA", "H2441", "Chukwuma" },
                    { 2, new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1730), new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1730), new DateTime(2001, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladys", "NGN0024AA", "H2442", "Chukwuma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyHolders");
        }
    }
}
