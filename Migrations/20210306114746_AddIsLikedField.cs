using Microsoft.EntityFrameworkCore.Migrations;

namespace perial_server.Migrations
{
    public partial class AddIsLikedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Users",
                type: "INTEGER",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Users");
        }
    }
}
