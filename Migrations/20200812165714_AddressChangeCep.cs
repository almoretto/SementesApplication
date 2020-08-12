using Microsoft.EntityFrameworkCore.Migrations;

namespace SementesApplication.Migrations
{
    public partial class AddressChangeCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Address");
        }
    }
}
