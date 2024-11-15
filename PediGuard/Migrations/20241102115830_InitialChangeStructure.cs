using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PediGuard.Migrations
{
    /// <inheritdoc />
    public partial class InitialChangeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Doctors_DoctorId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DoctorId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleDoctorName",
                table: "Departments",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResponsibleDoctorName",
                value: "Ahmet Özkan");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResponsibleDoctorName",
                value: "Nani Fulchany");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResponsibleDoctorName",
                value: "Luss Huguette");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponsibleDoctorName",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoctorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoctorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoctorId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DoctorId",
                table: "Departments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Doctors_DoctorId",
                table: "Departments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
