using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class editingcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPersons",
                table: "Templates",
                newName: "NumberOfKids");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAdults",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StarRatingPreference",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DayItineraryRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayItineraryId = table.Column<int>(type: "int", nullable: false),
                    HotelRoomId = table.Column<int>(type: "int", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    ExtraPersons = table.Column<int>(type: "int", nullable: false),
                    TotalRoomCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayItineraryRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayItineraryRoom_DayItineraries_DayItineraryId",
                        column: x => x.DayItineraryId,
                        principalTable: "DayItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayItineraryRoom_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraryRoom_DayItineraryId",
                table: "DayItineraryRoom",
                column: "DayItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraryRoom_HotelRoomId",
                table: "DayItineraryRoom",
                column: "HotelRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayItineraryRoom");

            migrationBuilder.DropColumn(
                name: "NumberOfAdults",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "StarRatingPreference",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "NumberOfKids",
                table: "Templates",
                newName: "NumberOfPersons");
        }
    }
}
