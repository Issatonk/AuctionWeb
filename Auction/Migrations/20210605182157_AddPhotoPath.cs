using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Migrations
{
    public partial class AddPhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathPhoto",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathPhoto",
                table: "Lots");
        }
    }
}
