using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaPitcher.DAL.Migrations
{
    public partial class commentsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Posts_AuthorId",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "ContentModel");

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "CommentModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentModel",
                table: "ContentModel",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_ContentModel_AuthorId",
                table: "CommentModel",
                column: "AuthorId",
                principalTable: "ContentModel",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_ContentModel_AuthorId",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentModel",
                table: "ContentModel");

            migrationBuilder.RenameTable(
                name: "ContentModel",
                newName: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "CommentModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Posts_AuthorId",
                table: "CommentModel",
                column: "AuthorId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
