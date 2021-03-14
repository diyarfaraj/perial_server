using Microsoft.EntityFrameworkCore.Migrations;

namespace perial_server.Migrations
{
    public partial class AddDisLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisLikes",
                columns: table => new
                {
                    SourceUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisLikedUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisLikes", x => new { x.SourceUserId, x.DisLikedUserId });
                    table.ForeignKey(
                        name: "FK_DisLikes_Users_DisLikedUserId",
                        column: x => x.DisLikedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisLikes_Users_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisLikes_DisLikedUserId",
                table: "DisLikes",
                column: "DisLikedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisLikes");
        }
    }
}
