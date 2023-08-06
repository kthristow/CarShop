using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoveHoursePowerToCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "EngineTypes");

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "EngineTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
