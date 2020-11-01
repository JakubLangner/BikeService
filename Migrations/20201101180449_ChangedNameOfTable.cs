using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class ChangedNameOfTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Warehouse_PartId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "RepairPriority",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    BikeType = table.Column<string>(nullable: true),
                    PartName = table.Column<string>(nullable: true),
                    BikeAdvertisements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_StorageId",
                table: "Repairs",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Storage_StorageId",
                table: "Repairs",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Storage_StorageId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_StorageId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "RepairPriority",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Repairs");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Repairs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehousePartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeAdvertisements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BikeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehousePartId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Warehouse_PartId",
                table: "Repairs",
                column: "PartId",
                principalTable: "Warehouse",
                principalColumn: "WarehousePartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
