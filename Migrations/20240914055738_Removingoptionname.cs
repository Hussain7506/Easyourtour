using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class Removingoptionname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionName",
                table: "TravelSightseeingOption");

            migrationBuilder.DropColumn(
                name: "OptionName",
                table: "HotelDestinationOption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionName",
                table: "TravelSightseeingOption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionName",
                table: "HotelDestinationOption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
