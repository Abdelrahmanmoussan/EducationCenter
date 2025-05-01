using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationCenter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullableAcademicYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicYears_AcademicYearID",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearID",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicYears_AcademicYearID",
                table: "Students",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicYears_AcademicYearID",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicYears_AcademicYearID",
                table: "Students",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
