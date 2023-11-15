using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class ClaimsAndExpenseTableCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimsId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalIDOfPolicyHolder = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfExpense = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimsStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "DateCreated", "DateModified", "ExpenseDescription", "ExpenseType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(7230), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(7240), "D and C", "Procedure" },
                    { 2, new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(7240), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(7250), "Typhoid and Malaria Parasite Injection", "Prescription" }
                });

            migrationBuilder.UpdateData(
                table: "PolicyHolders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(5590), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "PolicyHolders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(5630), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(5640) });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Id", "Amount", "ClaimsId", "ClaimsStatus", "DateCreated", "DateModified", "DateOfExpense", "ExpenseId", "NationalIDOfPolicyHolder" },
                values: new object[,]
                {
                    { 1, 20000m, "CLA001", "Submitted", new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(8990), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(9010), new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NGN0024AA" },
                    { 2, 20000m, "CLA002", "Submitted", new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(9010), new DateTime(2023, 11, 15, 14, 12, 36, 559, DateTimeKind.Local).AddTicks(9010), new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NGN0014AA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ExpenseId",
                table: "Claims",
                column: "ExpenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.UpdateData(
                table: "PolicyHolders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1690), new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1720) });

            migrationBuilder.UpdateData(
                table: "PolicyHolders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1730), new DateTime(2023, 11, 15, 11, 47, 34, 220, DateTimeKind.Local).AddTicks(1730) });
        }
    }
}
