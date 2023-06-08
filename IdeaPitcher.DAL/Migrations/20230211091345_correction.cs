using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaPitcher.DAL.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_AuthorId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContentModelPostId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ContentModelPostId",
                table: "Comment",
                column: "ContentModelPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_ContentModelPostId",
                table: "Comment",
                column: "ContentModelPostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_ContentModelPostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ContentModelPostId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ContentModelPostId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
