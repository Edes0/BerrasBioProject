using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioProject.Migrations
{
    public partial class ShowSeatsTakenMovedprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsTaken",
                table: "Salons");

            migrationBuilder.AddColumn<int>(
                name: "SeatsTaken",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsTaken",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "SeatsTaken",
                table: "Salons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
