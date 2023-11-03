using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HTTP_API.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawBankTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawBankTransactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RawBankTransactions",
                columns: new[] { "Id", "AccountNumber", "Amount", "Balance", "Date", "Narration" },
                values: new object[,]
                {
                    { new Guid("0f30ed8c-1adf-44c3-b580-f5fbb7a712cc"), 10003, 100, 400, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit 6" },
                    { new Guid("2325fa7b-4601-4c36-aa13-71c2bf47f3fb"), 10002, -100, 200, new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 5" },
                    { new Guid("2621b142-c472-4cc8-ac28-90e7293eb810"), null, -50, 200, new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 7" },
                    { new Guid("580784a2-803e-48f1-b773-69864658f9ad"), 10003, null, null, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 6" },
                    { new Guid("68826199-8f58-4dcf-833c-5f5ee426da2c"), 10001, -50, 250, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 1" },
                    { new Guid("6f512e21-041e-4feb-ae2b-fc147393fd93"), 10001, -100, 150, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 4" },
                    { new Guid("86b567c2-8a05-41cc-b82f-d74002f3f211"), 10003, null, null, new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 3" },
                    { new Guid("96cc4266-c174-4f6f-b276-4627800161e0"), 10002, 100, 200, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit 5" },
                    { new Guid("9a962f5c-19ae-48e5-a379-10187d9bd471"), 10002, -20, 200, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit 2" },
                    { new Guid("9b734fe7-d136-4485-a67d-f21825d666c4"), 10001, 200, 300, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit 4" },
                    { new Guid("b3bf7220-f371-40b4-8116-2887336d5fab"), 10002, 200, 200, new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("c994cea0-1479-4f56-9cbe-e1b45ba5b7f1"), 10003, 300, 300, new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit 3" },
                    { new Guid("f1070e88-8811-4967-bd56-c4a9faff6c91"), 10001, 100, 100, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "RawBankTransactions");
        }
    }
}
