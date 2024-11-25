using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignerKeysToNobetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssistantID",
                table: "Nobets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Nobets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Nobets",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AssistantID", "DepartmentID" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Nobets",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "AssistantID", "DepartmentID" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Nobets",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "AssistantID", "DepartmentID" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Nobets_AssistantID",
                table: "Nobets",
                column: "AssistantID");

            migrationBuilder.CreateIndex(
                name: "IX_Nobets_DepartmentID",
                table: "Nobets",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nobets_Assistants_AssistantID",
                table: "Nobets",
                column: "AssistantID",
                principalTable: "Assistants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nobets_Departments_DepartmentID",
                table: "Nobets",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nobets_Assistants_AssistantID",
                table: "Nobets");

            migrationBuilder.DropForeignKey(
                name: "FK_Nobets_Departments_DepartmentID",
                table: "Nobets");

            migrationBuilder.DropIndex(
                name: "IX_Nobets_AssistantID",
                table: "Nobets");

            migrationBuilder.DropIndex(
                name: "IX_Nobets_DepartmentID",
                table: "Nobets");

            migrationBuilder.DropColumn(
                name: "AssistantID",
                table: "Nobets");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Nobets");
        }
    }
}
