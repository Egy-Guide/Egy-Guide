using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class Cover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("CoverImageUrl", "TripDetails", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
