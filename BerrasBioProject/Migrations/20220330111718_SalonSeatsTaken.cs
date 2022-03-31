using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerrasBioProject.Migrations
{
    public partial class SalonSeatsTaken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatsLeft",
                table: "Salons",
                newName: "SeatsTaken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatsTaken",
                table: "Salons",
                newName: "SeatsLeft");
        }
    }
}
