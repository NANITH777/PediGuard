using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pediatric_Service.Migrations
{
    /// <inheritdoc />
    public partial class AddAssistantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Assistants",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", "john.doe@example.com", "John Doe", "Male", "Password123", "123-456-7890" },
                    { 2, "456 Elm St, Othertown, USA", "jane.smith@example.com", "Jane Smith", "Female", "Password123", "098-765-4321" },
                    { 3, "789 Oak St, Sometown, USA", "alice.johnson@example.com", "Morgan Alex", "Female", "Password123", "555-123-4567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistants");
        }
    }
}
