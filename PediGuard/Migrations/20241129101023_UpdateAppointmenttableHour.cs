using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmenttableHour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Appointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9838), new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9838) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9840), new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9843), new DateTime(2024, 11, 29, 13, 10, 20, 441, DateTimeKind.Local).AddTicks(9844) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(784), new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(787), new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(790), new DateTime(2024, 11, 29, 10, 9, 36, 376, DateTimeKind.Local).AddTicks(790) });
        }
    }
}
