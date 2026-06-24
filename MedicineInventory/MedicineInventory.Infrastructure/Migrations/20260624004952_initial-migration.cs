using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicineInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Brand = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Brand", "ExpiryDate", "FullName", "Notes", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Cipla", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol 500mg", "Used for fever and pain relief", 25.50m, 50 },
                    { 2, "Sun Pharma", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azithromycin 250mg", "Antibiotic medicine", 120.00m, 5 },
                    { 3, "Himalaya", new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitamin D3", "Supplement", 180.75m, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");
        }
    }
}
