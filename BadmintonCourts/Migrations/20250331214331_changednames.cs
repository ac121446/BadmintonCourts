using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourts.Migrations
{
    /// <inheritdoc />
    public partial class changednames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Equipment",
                newName: "EType");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Equipment",
                newName: "EPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Equipment",
                newName: "EName");

            migrationBuilder.AlterColumn<string>(
                name: "Suburb",
                table: "Location",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EType",
                table: "Equipment",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "EPrice",
                table: "Equipment",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "EName",
                table: "Equipment",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Suburb",
                table: "Location",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
