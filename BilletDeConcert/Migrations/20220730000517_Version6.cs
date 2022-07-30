using Microsoft.EntityFrameworkCore.Migrations;

namespace BilletDeConcert.Migrations
{
    public partial class Version6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Concerts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Concerts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
