using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourts.Migrations
{
    /// <inheritdoc />
    public partial class madeEquipmentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentID",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "EquipmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "EquipmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
