using Microsoft.EntityFrameworkCore.Migrations;

namespace SementesApplication.Migrations
{
    public partial class AddressChabge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesignationGroup",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationGroup",
                table: "Address");
        }
    }
}
