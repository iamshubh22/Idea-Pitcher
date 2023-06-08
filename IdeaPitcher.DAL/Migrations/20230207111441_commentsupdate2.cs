using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaPitcher.DAL.Migrations
{
    public partial class commentsupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_ContentModel_AuthorId",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentModel",
                table: "ContentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "ContentModel",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_AuthorId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_AuthorId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "ContentModel");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "CommentModel");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "CommentModel",
                newName: "IX_CommentModel_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentModel",
                table: "ContentModel",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_ContentModel_AuthorId",
                table: "CommentModel",
                column: "AuthorId",
                principalTable: "ContentModel",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
