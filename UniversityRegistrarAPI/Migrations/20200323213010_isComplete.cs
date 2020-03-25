using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityRegistrar.Migrations
{
    public partial class isComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "CourseStudent",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "CourseStudent");
        }
    }
}
