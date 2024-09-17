using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class AssigningcorrectdtypetoMiscellaneous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Miscellaneous",
                table: "TravelSightseeingDays",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Miscellaneous",
                table: "TravelSightseeingDays",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
