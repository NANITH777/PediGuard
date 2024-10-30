using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CurrentCapacity", "Name", "NumberOfBeds", "ResponsibleDoctorId" },
                values: new object[,]
                {
                    { 1, 8, "Pediatric Emergency", 10, 101 },
                    { 2, 10, "Pediatric Intensive Care", 12, 102 },
                    { 3, 13, "Pediatric Hematology and Oncology", 15, 103 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
