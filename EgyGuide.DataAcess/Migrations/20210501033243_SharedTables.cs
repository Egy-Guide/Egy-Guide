using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class SharedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityCardUrl",
                table: "GuideUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Excludeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excludeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Includeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Includeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestedInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripStyles",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStyles", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "Requested",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SelcetedStyles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTravellers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requested", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Requested_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requested_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "RequestedSelectedStyle",
                columns: table => new
                {
                    SelectedStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    TripStyleStyleId = table.Column<int>(type: "int", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    RequestedTripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedSelectedStyle", x => x.SelectedStyleId);
                    table.ForeignKey(
                        name: "FK_RequestedSelectedStyle_Requested_RequestedTripId",
                        column: x => x.RequestedTripId,
                        principalTable: "Requested",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestedSelectedStyle_TripStyles_TripStyleStyleId",
                        column: x => x.TripStyleStyleId,
                        principalTable: "TripStyles",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripDetailTripId = table.Column<int>(type: "int", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_TripDetails_TripDetailTripId",
                        column: x => x.TripDetailTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripDetailTripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_TripDetails_TripDetailTripId",
                        column: x => x.TripDetailTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedStyles",
                columns: table => new
                {
                    SelectedStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    TripStyleStyleId = table.Column<int>(type: "int", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripDetailTripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedStyles", x => x.SelectedStyleId);
                    table.ForeignKey(
                        name: "FK_SelectedStyles_TripDetails_TripDetailTripId",
                        column: x => x.TripDetailTripId,
                        principalTable: "TripDetails",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedStyles_TripStyles_TripStyleStyleId",
                        column: x => x.TripStyleStyleId,
                        principalTable: "TripStyles",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Galleries_TripDetailTripId",
                table: "Galleries",
                column: "TripDetailTripId");

            migrationBuilder.CreateIndex(
                name: "IX_IncludedTripDetail_TripDetailsTripId",
                table: "IncludedTripDetail",
                column: "TripDetailsTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_TripDetailTripId",
                table: "Places",
                column: "TripDetailTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Requested_CityId",
                table: "Requested",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requested_UserId",
                table: "Requested",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedRequestedInfo_RequestedTripId",
                table: "RequestedRequestedInfo",
                column: "RequestedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedSelectedStyle_RequestedTripId",
                table: "RequestedSelectedStyle",
                column: "RequestedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedSelectedStyle_TripStyleStyleId",
                table: "RequestedSelectedStyle",
                column: "TripStyleStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedStyles_TripDetailTripId",
                table: "SelectedStyles",
                column: "TripDetailTripId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedStyles_TripStyleStyleId",
                table: "SelectedStyles",
                column: "TripStyleStyleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "ExcludedTripDetail");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "IncludedTripDetail");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "RequestedRequestedInfo");

            migrationBuilder.DropTable(
                name: "RequestedSelectedStyle");

            migrationBuilder.DropTable(
                name: "SelectedStyles");

            migrationBuilder.DropTable(
                name: "TripDaysDetails");

            migrationBuilder.DropTable(
                name: "Excludeds");

            migrationBuilder.DropTable(
                name: "Includeds");

            migrationBuilder.DropTable(
                name: "RequestedInfo");

            migrationBuilder.DropTable(
                name: "Requested");

            migrationBuilder.DropTable(
                name: "TripStyles");

            migrationBuilder.DropTable(
                name: "TripDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityCardUrl",
                table: "GuideUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
