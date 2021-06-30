using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class AddTripDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPlaces = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SelcetedStyles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxTravellers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_TripDetails_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetails_GuideUsers_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GuideUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestedRequestedInfo",
                columns: table => new
                {
                    RequestedInfoId = table.Column<int>(type: "int", nullable: false),
                    RequestedTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedRequestedInfo", x => new { x.RequestedInfoId, x.RequestedTripId });
                    table.ForeignKey(
                        name: "FK_RequestedRequestedInfo_Requested_RequestedTripId",
                        column: x => x.RequestedTripId,
                        principalTable: "Requested",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestedRequestedInfo_RequestedInfo_RequestedInfoId",
                        column: x => x.RequestedInfoId,
                        principalTable: "RequestedInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcludedTripDetail",
                columns: table => new
                {
                    ExcludedId = table.Column<int>(type: "int", nullable: false),
                    TripDetailsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludedTripDetail", x => new { x.ExcludedId, x.TripDetailsTripId });
                    table.ForeignKey(
                        name: "FK_ExcludedTripDetail_Excludeds_ExcludedId",
                        column: x => x.ExcludedId,
                        principalTable: "Excludeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcludedTripDetail_TripDetails_TripDetailsTripId",
                        column: x => x.TripDetailsTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryTripDetail",
                columns: table => new
                {
                    SelectedImagesId = table.Column<int>(type: "int", nullable: false),
                    TripDetailsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryTripDetail", x => new { x.SelectedImagesId, x.TripDetailsTripId });
                    table.ForeignKey(
                        name: "FK_GalleryTripDetail_Galleries_SelectedImagesId",
                        column: x => x.SelectedImagesId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryTripDetail_TripDetails_TripDetailsTripId",
                        column: x => x.TripDetailsTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncludedTripDetail",
                columns: table => new
                {
                    IncludedId = table.Column<int>(type: "int", nullable: false),
                    TripDetailsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedTripDetail", x => new { x.IncludedId, x.TripDetailsTripId });
                    table.ForeignKey(
                        name: "FK_IncludedTripDetail_Includeds_IncludedId",
                        column: x => x.IncludedId,
                        principalTable: "Includeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncludedTripDetail_TripDetails_TripDetailsTripId",
                        column: x => x.TripDetailsTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripDaysDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    DayNum = table.Column<int>(type: "int", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDaysDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDaysDetails_TripDetails_TripId",
                        column: x => x.TripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcludedTripDetail_TripDetailsTripId",
                table: "ExcludedTripDetail",
                column: "TripDetailsTripId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTripDetail_TripDetailsTripId",
                table: "GalleryTripDetail",
                column: "TripDetailsTripId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedTripDetail_TripDetailsTripId",
                table: "IncludedTripDetail",
                column: "TripDetailsTripId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedRequestedInfo_RequestedTripId",
                table: "RequestedRequestedInfo",
                column: "RequestedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDaysDetails_TripId",
                table: "TripDaysDetails",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_CityId",
                table: "TripDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_GuideId",
                table: "TripDetails",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcludedTripDetail");

            migrationBuilder.DropTable(
                name: "GalleryTripDetail");

            migrationBuilder.DropTable(
                name: "IncludedTripDetail");

            migrationBuilder.DropTable(
                name: "RequestedRequestedInfo");

            migrationBuilder.DropTable(
                name: "TripDaysDetails");

            migrationBuilder.DropTable(
                name: "TripDetails");
        }
    }
}
