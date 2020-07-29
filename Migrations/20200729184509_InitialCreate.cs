using System;
using Microsoft.EntityFrameworkCore.Migrations;
using SementesApplication.Data;

namespace SementesApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "AssistedEntities",
                columns: table => new
                {
                    AssistedEntitiesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssistedEntitiesName = table.Column<string>(nullable: true),
                    AssistedEntitiesVisitDay = table.Column<int>(nullable: false),
                    AssistedEntitiesVisitTime = table.Column<DateTime>(nullable: false),
                    AssistedEntitiesVisitDuration = table.Column<TimeSpan>(nullable: false),
                    AssitedEntitiesVisitScale = table.Column<int>(nullable: false),
                    AssistedEntitiesMaxVolunteer = table.Column<int>(nullable: false),
                    AssistedEntitiesContact = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistedEntities", x => x.AssistedEntitiesID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    CityStateId = table.Column<int>(nullable: false),
                    UFId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    StateAbreviationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressKind = table.Column<int>(nullable: false),
                    AddressDesignation = table.Column<string>(nullable: true),
                    AddressNumber = table.Column<string>(nullable: true),
                    AddressDistrict = table.Column<string>(nullable: true),
                    AddressComplement = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDay = table.Column<DateTime>(nullable: false),
                    JobPeriod = table.Column<string>(nullable: false),
                    ActionKind = table.Column<int>(nullable: false),
                    AssistedEntitiesID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Job_AssistedEntities_AssistedEntitiesID",
                        column: x => x.AssistedEntitiesID,
                        principalTable: "AssistedEntities",
                        principalColumn: "AssistedEntitiesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerDocCPF = table.Column<string>(nullable: true),
                    VolunteerDocRG = table.Column<string>(nullable: true),
                    VolunteerName = table.Column<string>(nullable: true),
                    VolunteerBirthDate = table.Column<DateTime>(nullable: false),
                    VolunteerAge = table.Column<int>(nullable: false),
                    VolunteerResumee = table.Column<string>(nullable: true),
                    VolunteerPhone = table.Column<string>(nullable: true),
                    VolunteerMessagePhone = table.Column<bool>(nullable: false),
                    VolunteerEmail = table.Column<string>(nullable: true),
                    VolunteerSocialMidiaProfile = table.Column<string>(nullable: true),
                    VolunteerActive = table.Column<bool>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: true),
                    TeamID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerID);
                    table.ForeignKey(
                        name: "FK_Volunteer_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Volunteer_Team_TeamID1",
                        column: x => x.TeamID1,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchedule",
                columns: table => new
                {
                    TeamScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamScheduleDate = table.Column<DateTime>(nullable: false),
                    TeamSchedulePeriod = table.Column<string>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchedule", x => x.TeamScheduleID);
                    table.ForeignKey(
                        name: "FK_TeamSchedule_Volunteer_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteer",
                        principalColumn: "VolunteerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityID",
                table: "Address",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_AssistedEntitiesID",
                table: "Job",
                column: "AssistedEntitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_TeamID",
                table: "Job",
                column: "TeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchedule_VolunteerId",
                table: "TeamSchedule",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_AddressID",
                table: "Volunteer",
                column: "AddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_TeamID",
                table: "Volunteer",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_TeamID1",
                table: "Volunteer",
                column: "TeamID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "TeamSchedule");

            migrationBuilder.DropTable(
                name: "AssistedEntities");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
