using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmergency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Emergencies",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Description", "Location", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9126), 1, "Fire in the emergency room", "Emergency Room 1", "Pending", new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9126) },
                    { 2, new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9128), 2, "Child with severe asthma attack", "Pediatrics Ward", "In Progress", new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9129) },
                    { 3, new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9131), 1, "Power outage in the hospital", "Main Building", "Resolved", new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9131) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
