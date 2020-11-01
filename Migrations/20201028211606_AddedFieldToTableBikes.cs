using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class AddedFieldToTableBikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BikeStatus",
                table: "Bikes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeStatus",
                table: "Bikes");
        }
    }
}
