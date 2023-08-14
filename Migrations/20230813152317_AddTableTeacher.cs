using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSystemApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TacherId",
                table: "Teachers",
                newName: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "TacherId");
        }
    }
}
