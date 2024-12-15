using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pediatric_Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", "john.smith@example.com", "Dr. John Smith", "Male", "123-456-7890" },
                    { 2, "456 Elm St, Othertown, USA", "jane.doe@example.com", "Dr. Jane Doe", "Female", "098-765-4321" },
                    { 3, "789 Oak St, Sometown, USA", "emily.johnson@example.com", "Dr. Emily Johnson", "Female", "555-123-4567" }
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
