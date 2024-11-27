using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmergencyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergencys_Departments_DepartmentID",
                table: "Emergencys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergencys",
                table: "Emergencys");

            migrationBuilder.RenameTable(
                name: "Emergencys",
                newName: "Emergencies");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Emergencies",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Emergencies",
                newName: "UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Emergencys_DepartmentID",
                table: "Emergencies",
                newName: "IX_Emergencies_DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Emergencies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Emergencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergencies",
                table: "Emergencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emergencies_Departments_DepartmentId",
                table: "Emergencies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emergencies_Departments_DepartmentId",
                table: "Emergencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emergencies",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Emergencies");

            migrationBuilder.RenameTable(
                name: "Emergencies",
                newName: "Emergencys");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Emergencys",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Emergencys",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Emergencies_DepartmentId",
                table: "Emergencys",
                newName: "IX_Emergencys_DepartmentID");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Emergencys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emergencys",
                table: "Emergencys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emergencys_Departments_DepartmentID",
                table: "Emergencys",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
