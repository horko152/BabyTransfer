using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeCarSeatTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSeat_drivers_driver_id",
                table: "CarSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarSeat",
                table: "CarSeat");

            migrationBuilder.RenameTable(
                name: "CarSeat",
                newName: "carseats");

            migrationBuilder.RenameIndex(
                name: "IX_CarSeat_driver_id",
                table: "carseats",
                newName: "IX_carseats_driver_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carseats",
                table: "carseats",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_carseats_drivers_driver_id",
                table: "carseats",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carseats_drivers_driver_id",
                table: "carseats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carseats",
                table: "carseats");

            migrationBuilder.RenameTable(
                name: "carseats",
                newName: "CarSeat");

            migrationBuilder.RenameIndex(
                name: "IX_carseats_driver_id",
                table: "CarSeat",
                newName: "IX_CarSeat_driver_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarSeat",
                table: "CarSeat",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSeat_drivers_driver_id",
                table: "CarSeat",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
