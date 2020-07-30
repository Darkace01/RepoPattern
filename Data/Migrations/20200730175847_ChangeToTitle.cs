using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangeToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Post",
                newName: "Title");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Post",
                newName: "Name");
        }
    }
}
