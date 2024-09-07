using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class addingtemplatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SightseeingImages_Sightseeings_HotelId",
                table: "SightseeingImages");

            migrationBuilder.DropIndex(
                name: "IX_SightseeingImages_HotelId",
                table: "SightseeingImages");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "SightseeingImages");

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    FinalCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    HotelRoomId = table.Column<int>(type: "int", nullable: true),
                    TransportId = table.Column<int>(type: "int", nullable: true),
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
                name: "IX_SightseeingImages_SightseeingId",
                table: "SightseeingImages",
                column: "SightseeingId");

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
                name: "IX_DayItinerarySightseeings_SightseeingId",
                table: "DayItinerarySightseeings",
                column: "SightseeingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SightseeingImages_Sightseeings_SightseeingId",
                table: "SightseeingImages",
                column: "SightseeingId",
                principalTable: "Sightseeings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SightseeingImages_Sightseeings_SightseeingId",
                table: "SightseeingImages");

            migrationBuilder.DropTable(
                name: "DayItinerarySightseeings");

            migrationBuilder.DropTable(
                name: "DayItineraries");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_SightseeingImages_SightseeingId",
                table: "SightseeingImages");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "SightseeingImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SightseeingImages_HotelId",
                table: "SightseeingImages",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SightseeingImages_Sightseeings_HotelId",
                table: "SightseeingImages",
                column: "HotelId",
                principalTable: "Sightseeings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
