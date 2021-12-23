using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackBox.Migrations
{
    public partial class AddConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersAndBooks_BookID",
                table: "UsersAndBooks");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UsersAndBooks_BookID_UserID",
                table: "UsersAndBooks",
                columns: new[] { "BookID", "UserID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UsersAndBooks_BookID_UserID",
                table: "UsersAndBooks");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAndBooks_BookID",
                table: "UsersAndBooks",
                column: "BookID");
        }
    }
}
