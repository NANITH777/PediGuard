using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsActive", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john.smith@example.com", "John", true, "Smith", "123-456-7890" },
                    { 2, "456 Maple Ave", "jane.doe@example.com", "Jane", false, "Doe", "987-654-3210" },
                    { 3, "789 Oak Dr", "alice.brown@example.com", "Alice", true, "Brown", "555-555-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
