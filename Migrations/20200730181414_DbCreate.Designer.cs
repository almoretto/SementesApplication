﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SementesApplication.Data;

namespace SementesApplication.Migrations
{
    [DbContext(typeof(SementesApplicationContext))]
    [Migration("20200730181414_DbCreate")]
    partial class DbCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SementesApplication.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressKind")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("CityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SementesApplication.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SementesApplication.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxVolunteer")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitDay")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("VisitDuration")
                        .HasColumnType("time");

                    b.Property<int>("VisitScale")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitTime")
                        .HasColumnType("datetime2");

                    b.HasKey("EntityId");

                    b.ToTable("AssistedEntities");
                });

            modelBuilder.Entity("SementesApplication.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionKind")
                        .HasColumnType("int");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("MaxVolunteer")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("EntityId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("SementesApplication.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UFAbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UFName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("SementesApplication.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SementesApplication.TeamSchedule", b =>
                {
                    b.Property<int>("TeamScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TSDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TSPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("TeamScheduleId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("TeamSchedule");
                });

            modelBuilder.Entity("SementesApplication.TeamVolunteer", b =>
                {
                    b.Property<int>("TeamVolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("TeamVolunteerId");

                    b.HasIndex("TeamId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("TeamVolunteer");
                });

            modelBuilder.Entity("SementesApplication.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<bool>("VActive")
                        .HasColumnType("bit");

                    b.Property<int>("VAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("VBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VDocCPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VDocRG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VMessagePhone")
                        .HasColumnType("bit");

                    b.Property<string>("VName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VResumee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VSocialMidiaProfile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("SementesApplication.Address", b =>
                {
                    b.HasOne("SementesApplication.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.City", b =>
                {
                    b.HasOne("SementesApplication.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.Job", b =>
                {
                    b.HasOne("SementesApplication.Entity", "Entity")
                        .WithMany("Jobs")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.Team", b =>
                {
                    b.HasOne("SementesApplication.Job", "Job")
                        .WithOne("Team")
                        .HasForeignKey("SementesApplication.Team", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.TeamSchedule", b =>
                {
                    b.HasOne("SementesApplication.Volunteer", "Volunteer")
                        .WithMany("TeamSchedules")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.TeamVolunteer", b =>
                {
                    b.HasOne("SementesApplication.Team", "Team")
                        .WithMany("TeamVolunteer")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SementesApplication.Volunteer", "Volunteer")
                        .WithMany("TeamVolunteer")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.Volunteer", b =>
                {
                    b.HasOne("SementesApplication.Address", "Address")
                        .WithOne("Volunteer")
                        .HasForeignKey("SementesApplication.Volunteer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SementesApplication.Team", null)
                        .WithMany("Volunteers")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
