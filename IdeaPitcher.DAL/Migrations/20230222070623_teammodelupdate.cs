using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaPitcher.DAL.Migrations
{
    public partial class teammodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Team",
                newName: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Team",
                newName: "Id");
        }
    }
}
