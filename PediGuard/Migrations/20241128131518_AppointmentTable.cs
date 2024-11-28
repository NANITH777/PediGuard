using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentPs");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssistantId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Assistants_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "Assistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5579), new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5582), new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5584), new DateTime(2024, 11, 28, 16, 15, 14, 214, DateTimeKind.Local).AddTicks(5584) });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AssistantId",
                table: "Appointments",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DepartmentId",
                table: "Appointments",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.CreateTable(
                name: "DepartmentPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentPs_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DepartmentPs",
                columns: new[] { "Id", "CurrentCapacity", "DoctorID", "Name", "NumberOfBeds" },
                values: new object[,]
                {
                    { 1, 25, 1, "Cardiology", 30 },
                    { 2, 15, 3, "Neurology", 20 },
                    { 3, 35, 3, "Pediatrics", 40 }
                });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1733), new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1734) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1736), new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1736) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1738), new DateTime(2024, 11, 28, 13, 10, 27, 63, DateTimeKind.Local).AddTicks(1739) });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentPs_DoctorID",
                table: "DepartmentPs",
                column: "DoctorID");
        }
    }
}
