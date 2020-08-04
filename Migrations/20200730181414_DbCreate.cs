using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SementesApplication.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(nullable: true),
                    VisitDay = table.Column<int>(nullable: false),
                    VisitTime = table.Column<DateTime>(nullable: false),
                    VisitDuration = table.Column<TimeSpan>(nullable: false),
                    VisitScale = table.Column<int>(nullable: false),
                    MaxVolunteer = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistedEntities", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UFAbreviation = table.Column<string>(nullable: true),
                    UFName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDay = table.Column<DateTime>(nullable: false),
                    JobPeriod = table.Column<string>(nullable: false),
                    ActionKind = table.Column<int>(nullable: false),
                    MaxVolunteer = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Job_AssistedEntities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressKind = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VDocCPF = table.Column<string>(nullable: true),
                    VDocRG = table.Column<string>(nullable: true),
                    VName = table.Column<string>(nullable: true),
                    VBirthDate = table.Column<DateTime>(nullable: false),
                    VAge = table.Column<int>(nullable: false),
                    VResumee = table.Column<string>(nullable: true),
                    VPhone = table.Column<string>(nullable: true),
                    VMessagePhone = table.Column<bool>(nullable: false),
                    VEmail = table.Column<string>(nullable: true),
                    VSocialMidiaProfile = table.Column<string>(nullable: true),
                    VActive = table.Column<bool>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK_Volunteer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchedule",
                columns: table => new
                {
                    TeamScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TSDate = table.Column<DateTime>(nullable: false),
                    TSPeriod = table.Column<string>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchedule", x => x.TeamScheduleId);
                    table.ForeignKey(
                        name: "FK_TeamSchedule_Volunteer_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteer",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamVolunteer",
                columns: table => new
                {
                    TeamVolunteerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamVolunteer", x => x.TeamVolunteerId);
                    table.ForeignKey(
                        name: "FK_TeamVolunteer_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamVolunteer_Volunteer_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteer",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_EntityId",
                table: "Job",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_JobId",
                table: "Team",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamSchedule_VolunteerId",
                table: "TeamSchedule",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamVolunteer_TeamId",
                table: "TeamVolunteer",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamVolunteer_VolunteerId",
                table: "TeamVolunteer",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_AddressId",
                table: "Volunteer",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_TeamId",
                table: "Volunteer",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSchedule");

            migrationBuilder.DropTable(
                name: "TeamVolunteer");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
