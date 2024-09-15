using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easyourtour.Migrations
{
    /// <inheritdoc />
    public partial class AddingCorrespondingTableToDBCONTEXt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDay_Destinations_DestinationId",
                table: "HotelDestinationDay");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDay_HotelDestinationOption_HotelDestinationOptionId",
                table: "HotelDestinationDay");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDay_HotelRooms_HotelRoomId",
                table: "HotelDestinationDay");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDay_Hotels_HotelId",
                table: "HotelDestinationDay");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDay_Locations_LocationId",
                table: "HotelDestinationDay");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationOption_Templates_TemplateId",
                table: "HotelDestinationOption");

            migrationBuilder.DropForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDay_TravelSightseeingDayId",
                table: "Sightseeings");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingDay_Transports_CarTypeId",
                table: "TravelSightseeingDay");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingDay_TravelSightseeingOption_TravelSightseeingOptionId",
                table: "TravelSightseeingDay");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingOption_Templates_TemplateId",
                table: "TravelSightseeingOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelSightseeingOption",
                table: "TravelSightseeingOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelSightseeingDay",
                table: "TravelSightseeingDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelDestinationOption",
                table: "HotelDestinationOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelDestinationDay",
                table: "HotelDestinationDay");

            migrationBuilder.RenameTable(
                name: "TravelSightseeingOption",
                newName: "TravelSightseeingOptions");

            migrationBuilder.RenameTable(
                name: "TravelSightseeingDay",
                newName: "TravelSightseeingDays");

            migrationBuilder.RenameTable(
                name: "HotelDestinationOption",
                newName: "HotelDestinationOptions");

            migrationBuilder.RenameTable(
                name: "HotelDestinationDay",
                newName: "HotelDestinationDays");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingOption_TemplateId",
                table: "TravelSightseeingOptions",
                newName: "IX_TravelSightseeingOptions_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingDay_TravelSightseeingOptionId",
                table: "TravelSightseeingDays",
                newName: "IX_TravelSightseeingDays_TravelSightseeingOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingDay_CarTypeId",
                table: "TravelSightseeingDays",
                newName: "IX_TravelSightseeingDays_CarTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationOption_TemplateId",
                table: "HotelDestinationOptions",
                newName: "IX_HotelDestinationOptions_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDay_LocationId",
                table: "HotelDestinationDays",
                newName: "IX_HotelDestinationDays_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDay_HotelRoomId",
                table: "HotelDestinationDays",
                newName: "IX_HotelDestinationDays_HotelRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDay_HotelId",
                table: "HotelDestinationDays",
                newName: "IX_HotelDestinationDays_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDay_HotelDestinationOptionId",
                table: "HotelDestinationDays",
                newName: "IX_HotelDestinationDays_HotelDestinationOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDay_DestinationId",
                table: "HotelDestinationDays",
                newName: "IX_HotelDestinationDays_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelSightseeingOptions",
                table: "TravelSightseeingOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelSightseeingDays",
                table: "TravelSightseeingDays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelDestinationOptions",
                table: "HotelDestinationOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelDestinationDays",
                table: "HotelDestinationDays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDays_Destinations_DestinationId",
                table: "HotelDestinationDays",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDays_HotelDestinationOptions_HotelDestinationOptionId",
                table: "HotelDestinationDays",
                column: "HotelDestinationOptionId",
                principalTable: "HotelDestinationOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDays_HotelRooms_HotelRoomId",
                table: "HotelDestinationDays",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDays_Hotels_HotelId",
                table: "HotelDestinationDays",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDays_Locations_LocationId",
                table: "HotelDestinationDays",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationOptions_Templates_TemplateId",
                table: "HotelDestinationOptions",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDays_TravelSightseeingDayId",
                table: "Sightseeings",
                column: "TravelSightseeingDayId",
                principalTable: "TravelSightseeingDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingDays_Transports_CarTypeId",
                table: "TravelSightseeingDays",
                column: "CarTypeId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingDays_TravelSightseeingOptions_TravelSightseeingOptionId",
                table: "TravelSightseeingDays",
                column: "TravelSightseeingOptionId",
                principalTable: "TravelSightseeingOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingOptions_Templates_TemplateId",
                table: "TravelSightseeingOptions",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDays_Destinations_DestinationId",
                table: "HotelDestinationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDays_HotelDestinationOptions_HotelDestinationOptionId",
                table: "HotelDestinationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDays_HotelRooms_HotelRoomId",
                table: "HotelDestinationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDays_Hotels_HotelId",
                table: "HotelDestinationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationDays_Locations_LocationId",
                table: "HotelDestinationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDestinationOptions_Templates_TemplateId",
                table: "HotelDestinationOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDays_TravelSightseeingDayId",
                table: "Sightseeings");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingDays_Transports_CarTypeId",
                table: "TravelSightseeingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingDays_TravelSightseeingOptions_TravelSightseeingOptionId",
                table: "TravelSightseeingDays");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelSightseeingOptions_Templates_TemplateId",
                table: "TravelSightseeingOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelSightseeingOptions",
                table: "TravelSightseeingOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelSightseeingDays",
                table: "TravelSightseeingDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelDestinationOptions",
                table: "HotelDestinationOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelDestinationDays",
                table: "HotelDestinationDays");

            migrationBuilder.RenameTable(
                name: "TravelSightseeingOptions",
                newName: "TravelSightseeingOption");

            migrationBuilder.RenameTable(
                name: "TravelSightseeingDays",
                newName: "TravelSightseeingDay");

            migrationBuilder.RenameTable(
                name: "HotelDestinationOptions",
                newName: "HotelDestinationOption");

            migrationBuilder.RenameTable(
                name: "HotelDestinationDays",
                newName: "HotelDestinationDay");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingOptions_TemplateId",
                table: "TravelSightseeingOption",
                newName: "IX_TravelSightseeingOption_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingDays_TravelSightseeingOptionId",
                table: "TravelSightseeingDay",
                newName: "IX_TravelSightseeingDay_TravelSightseeingOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelSightseeingDays_CarTypeId",
                table: "TravelSightseeingDay",
                newName: "IX_TravelSightseeingDay_CarTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationOptions_TemplateId",
                table: "HotelDestinationOption",
                newName: "IX_HotelDestinationOption_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDays_LocationId",
                table: "HotelDestinationDay",
                newName: "IX_HotelDestinationDay_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDays_HotelRoomId",
                table: "HotelDestinationDay",
                newName: "IX_HotelDestinationDay_HotelRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDays_HotelId",
                table: "HotelDestinationDay",
                newName: "IX_HotelDestinationDay_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDays_HotelDestinationOptionId",
                table: "HotelDestinationDay",
                newName: "IX_HotelDestinationDay_HotelDestinationOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelDestinationDays_DestinationId",
                table: "HotelDestinationDay",
                newName: "IX_HotelDestinationDay_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelSightseeingOption",
                table: "TravelSightseeingOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelSightseeingDay",
                table: "TravelSightseeingDay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelDestinationOption",
                table: "HotelDestinationOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelDestinationDay",
                table: "HotelDestinationDay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDay_Destinations_DestinationId",
                table: "HotelDestinationDay",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDay_HotelDestinationOption_HotelDestinationOptionId",
                table: "HotelDestinationDay",
                column: "HotelDestinationOptionId",
                principalTable: "HotelDestinationOption",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDay_HotelRooms_HotelRoomId",
                table: "HotelDestinationDay",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDay_Hotels_HotelId",
                table: "HotelDestinationDay",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationDay_Locations_LocationId",
                table: "HotelDestinationDay",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDestinationOption_Templates_TemplateId",
                table: "HotelDestinationOption",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sightseeings_TravelSightseeingDay_TravelSightseeingDayId",
                table: "Sightseeings",
                column: "TravelSightseeingDayId",
                principalTable: "TravelSightseeingDay",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingDay_Transports_CarTypeId",
                table: "TravelSightseeingDay",
                column: "CarTypeId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingDay_TravelSightseeingOption_TravelSightseeingOptionId",
                table: "TravelSightseeingDay",
                column: "TravelSightseeingOptionId",
                principalTable: "TravelSightseeingOption",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelSightseeingOption_Templates_TemplateId",
                table: "TravelSightseeingOption",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
