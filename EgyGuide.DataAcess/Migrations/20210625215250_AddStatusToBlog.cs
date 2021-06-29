using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyGuide.DataAccess.Migrations
{
    public partial class AddStatusToBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Blogs");
        }
    }
}
