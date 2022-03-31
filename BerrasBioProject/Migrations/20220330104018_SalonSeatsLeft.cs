using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioProject.Migrations
{
    public partial class SalonSeatsLeft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatsLeft",
                table: "Salons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsLeft",
                table: "Salons");
        }
    }
}
