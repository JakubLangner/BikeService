using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeService.Migrations
{
    public partial class FixedRowsInTableRepairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId1",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Warehouse_WarehousePartId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_UserId1",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_WarehousePartId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "WarehousePartId",
                table: "Repairs");

            migrationBuilder.AddColumn<int>(
                name: "WarehousePartId",
                table: "Warehouse",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Repairs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehousePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UserId",
                table: "Repairs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Warehouse_PartId",
                table: "Repairs",
                column: "PartId",
                principalTable: "Warehouse",
                principalColumn: "WarehousePartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId",
                table: "Repairs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Warehouse_PartId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_UserId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "WarehousePartId",
                table: "Warehouse");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Warehouse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Repairs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Repairs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehousePartId",
                table: "Repairs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UserId1",
                table: "Repairs",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_WarehousePartId",
                table: "Repairs",
                column: "WarehousePartId");

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
    }
}
