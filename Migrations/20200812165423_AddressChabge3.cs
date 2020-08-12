using Microsoft.EntityFrameworkCore.Migrations;

namespace SementesApplication.Migrations
{
    public partial class AddressChabge3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
