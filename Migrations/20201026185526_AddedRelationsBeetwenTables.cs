using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class AddedRelationsBeetwenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BikeAdvertisements",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehousePartId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentAdvertisingCampaign",
                table: "Bikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_BikeId",
                table: "Repairs",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UserId1",
                table: "Repairs",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_WarehousePartId",
                table: "Repairs",
                column: "WarehousePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_RepairId",
                table: "Archives",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_Repairs_RepairId",
                table: "Archives",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Bikes_BikeId",
                table: "Repairs",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "BikeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId1",
                table: "Repairs",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Warehouse_WarehousePartId",
                table: "Repairs",
                column: "WarehousePartId",
                principalTable: "Warehouse",
                principalColumn: "PartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_Repairs_RepairId",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Bikes_BikeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId1",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Warehouse_WarehousePartId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_BikeId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_UserId1",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_WarehousePartId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Archives_RepairId",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "BikeAdvertisements",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "WarehousePartId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "CurrentAdvertisingCampaign",
                table: "Bikes");
        }
    }
}
