using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackBox.Migrations
{
    public partial class FixEntityes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "UsersAndBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersAndBooks",
                table: "UsersAndBooks",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersAndBooks",
                table: "UsersAndBooks");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UsersAndBooks");
        }
    }
}
