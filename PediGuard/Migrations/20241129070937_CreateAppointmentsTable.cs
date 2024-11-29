using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class CreateAppointmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NobetID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Nobets_NobetID",
                        column: x => x.NobetID,
                        principalTable: "Nobets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NobetID",
                table: "Appointments",
                column: "NobetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9126), new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9128), new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9129) });

            migrationBuilder.UpdateData(
                table: "Emergencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9131), new DateTime(2024, 11, 27, 18, 14, 51, 324, DateTimeKind.Local).AddTicks(9131) });
        }
    }
}
