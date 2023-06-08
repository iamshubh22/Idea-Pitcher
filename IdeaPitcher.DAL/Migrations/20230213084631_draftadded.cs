using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaPitcher.DAL.Migrations
{
    public partial class draftadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Drafted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drafted",
                table: "Posts");
        }
    }
}
