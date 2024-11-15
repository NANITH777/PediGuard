using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class SeedAssistantData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assistants",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, City A", "john.doe@example.com", "John Doe", "Male", "+905340000003" },
                    { 2, "456 Elm St, City B", "jane.smith@example.com", "Jane Smith", "Female", "+905340000002" },
                    { 3, "789 Oak St, City C", "alice.johnson@example.com", "Alice Johnson", "Female", "+905340000001" },
                    { 4, "321 Pine St, City D", "robert.brown@example.com", "Robert Brown", "Male", "+905340000000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assistants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assistants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assistants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assistants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
