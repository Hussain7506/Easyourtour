using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayItineraryRoom");

            migrationBuilder.DropTable(
                name: "DayItinerarySightseeings");

            migrationBuilder.DropTable(
                name: "DayItineraries");

            migrationBuilder.DropColumn(
                name: "FinalCost",
                table: "Templates");

            migrationBuilder.AddColumn<int>(
                name: "TravelSightseeingDayId",
                table: "Sightseeings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelDestinationOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDestinationOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelDestinationOption_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    HotelCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TravelCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateCost_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelSightseeingOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelSightseeingOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelSightseeingOption_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelDestinationDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelRoomId = table.Column<int>(type: "int", nullable: false),
                    NumRooms = table.Column<int>(type: "int", nullable: false),
                    ExtraBeds = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Inclusions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelDestinationOptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDestinationDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelDestinationDay_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelDestinationDay_HotelDestinationOption_HotelDestinationOptionId",
                        column: x => x.HotelDestinationOptionId,
                        principalTable: "HotelDestinationOption",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelDestinationDay_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelDestinationDay_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelDestinationDay_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelSightseeingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    CarTypeId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    BaseDistance = table.Column<int>(type: "int", nullable: false),
                    Kilometers = table.Column<int>(type: "int", nullable: false),
                    SightseeingSpotIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miscellaneous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelSightseeingOptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelSightseeingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelSightseeingDay_Transports_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelSightseeingDay_TravelSightseeingOption_TravelSightseeingOptionId",
                        column: x => x.TravelSightseeingOptionId,
                        principalTable: "TravelSightseeingOption",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sightseeings_TravelSightseeingDayId",
                table: "Sightseeings",
                column: "TravelSightseeingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationDay_DestinationId",
                table: "HotelDestinationDay",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationDay_HotelDestinationOptionId",
                table: "HotelDestinationDay",
                column: "HotelDestinationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationDay_HotelId",
                table: "HotelDestinationDay",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationDay_HotelRoomId",
                table: "HotelDestinationDay",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationDay_LocationId",
                table: "HotelDestinationDay",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDestinationOption_TemplateId",
                table: "HotelDestinationOption",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCost_TemplateId",
                table: "TemplateCost",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelSightseeingDay_CarTypeId",
                table: "TravelSightseeingDay",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelSightseeingDay_TravelSightseeingOptionId",
                table: "TravelSightseeingDay",
                column: "TravelSightseeingOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelSightseeingOption_TemplateId",
                table: "TravelSightseeingOption",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDay_TravelSightseeingDayId",
                table: "Sightseeings",
                column: "TravelSightseeingDayId",
                principalTable: "TravelSightseeingDay",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDay_TravelSightseeingDayId",
                table: "Sightseeings");

            migrationBuilder.DropTable(
                name: "HotelDestinationDay");

            migrationBuilder.DropTable(
                name: "TemplateCost");

            migrationBuilder.DropTable(
                name: "TravelSightseeingDay");

            migrationBuilder.DropTable(
                name: "HotelDestinationOption");

            migrationBuilder.DropTable(
                name: "TravelSightseeingOption");

            migrationBuilder.DropIndex(
                name: "IX_Sightseeings_TravelSightseeingDayId",
                table: "Sightseeings");

            migrationBuilder.DropColumn(
                name: "TravelSightseeingDayId",
                table: "Sightseeings");

            migrationBuilder.AddColumn<double>(
                name: "FinalCost",
                table: "Templates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DayItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    HotelRoomId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: true),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayItineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayItineraries_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayItineraries_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayItineraries_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayItineraries_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayItineraries_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayItineraries_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayItineraryRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayItineraryId = table.Column<int>(type: "int", nullable: false),
                    HotelRoomId = table.Column<int>(type: "int", nullable: false),
                    ExtraPersons = table.Column<int>(type: "int", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "DayItinerarySightseeings",
                columns: table => new
                {
                    DayItineraryId = table.Column<int>(type: "int", nullable: false),
                    SightseeingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayItinerarySightseeings", x => new { x.DayItineraryId, x.SightseeingId });
                    table.ForeignKey(
                        name: "FK_DayItinerarySightseeings_DayItineraries_DayItineraryId",
                        column: x => x.DayItineraryId,
                        principalTable: "DayItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayItinerarySightseeings_Sightseeings_SightseeingId",
                        column: x => x.SightseeingId,
                        principalTable: "Sightseeings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_DestinationId",
                table: "DayItineraries",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_HotelId",
                table: "DayItineraries",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_HotelRoomId",
                table: "DayItineraries",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_LocationId",
                table: "DayItineraries",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_TemplateId",
                table: "DayItineraries",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraries_TransportId",
                table: "DayItineraries",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraryRoom_DayItineraryId",
                table: "DayItineraryRoom",
                column: "DayItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItineraryRoom_HotelRoomId",
                table: "DayItineraryRoom",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DayItinerarySightseeings_SightseeingId",
                table: "DayItinerarySightseeings",
                column: "SightseeingId");
        }
    }
}
