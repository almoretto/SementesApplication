using Microsoft.EntityFrameworkCore.Migrations;

namespace SementesApplication.Migrations
{
    public partial class AddressChabge2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationGroup",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignationGroup",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
