using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsTestApp1609.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FitnessRating",
                table: "UserTestMapping",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FitnessRating",
                table: "UserTestMapping");
        }
    }
}
