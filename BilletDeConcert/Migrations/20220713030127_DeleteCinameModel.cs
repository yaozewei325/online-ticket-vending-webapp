using Microsoft.EntityFrameworkCore.Migrations;

namespace BilletDeConcert.Migrations
{
    public partial class DeleteCinameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Cinemas_CinemaId",
                table: "Concerts");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_CinemaId",
                table: "Concerts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_CinemaId",
                table: "Concerts",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Cinemas_CinemaId",
                table: "Concerts",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
