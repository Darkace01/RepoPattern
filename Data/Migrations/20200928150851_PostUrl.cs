using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PostUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostUrl",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostUrl",
                table: "Post");
        }
    }
}
