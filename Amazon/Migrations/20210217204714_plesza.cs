using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Migrations
{
    public partial class plesza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Indentifier",
                table: "Books",
                newName: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Books",
                newName: "Indentifier");
        }
    }
}
