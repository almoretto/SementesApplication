﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;


namespace SementesApplication.Migrations
{
    [DbContext(typeof(SementesApplicationContext))]
    partial class SementesApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SementesApplication.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressComplement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressDesignation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressKind")
                        .HasColumnType("int");

                    b.Property<string>("AddressNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.HasKey("AddressID");

                    b.HasIndex("CityID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SementesApplication.AssistedEntities", b =>
                {
                    b.Property<int>("AssistedEntitiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssistedEntitiesContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssistedEntitiesMaxVolunteer")
                        .HasColumnType("int");

                    b.Property<string>("AssistedEntitiesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssistedEntitiesVisitDay")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("AssistedEntitiesVisitDuration")
                        .HasColumnType("time");

                    b.Property<DateTime>("AssistedEntitiesVisitTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("AssitedEntitiesVisitScale")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssistedEntitiesID");

                    b.ToTable("AssistedEntities");
                });

            modelBuilder.Entity("SementesApplication.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateAbreviationId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SementesApplication.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionKind")
                        .HasColumnType("int");

                    b.Property<int>("AssistedEntitiesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("JobID");

                    b.HasIndex("AssistedEntitiesID");

                    b.HasIndex("TeamID")
                        .IsUnique();

                    b.ToTable("Job");
                });

            modelBuilder.Entity("SementesApplication.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SementesApplication.TeamSchedule", b =>
                {
                    b.Property<int>("TeamScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TeamScheduleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeamSchedulePeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("TeamScheduleID");

                    b.HasIndex("VolunteerId");

                    b.ToTable("TeamSchedule");
                });

            modelBuilder.Entity("SementesApplication.Volunteer", b =>
                {
                    b.Property<int>("VolunteerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID1")
                        .HasColumnType("int");

                    b.Property<bool>("VolunteerActive")
                        .HasColumnType("bit");

                    b.Property<int>("VolunteerAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("VolunteerBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VolunteerDocCPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolunteerDocRG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolunteerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VolunteerMessagePhone")
                        .HasColumnType("bit");

                    b.Property<string>("VolunteerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolunteerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolunteerResumee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolunteerSocialMidiaProfile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerID");

                    b.HasIndex("AddressID")
                        .IsUnique();

                    b.HasIndex("TeamID");

                    b.HasIndex("TeamID1");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("SementesApplication.Address", b =>
                {
                    b.HasOne("SementesApplication.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SementesApplication.Job", b =>
                {
                    b.HasOne("SementesApplication.AssistedEntities", "AssitedEntity")
                        .WithMany("Jobs")
                        .HasForeignKey("AssistedEntitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SementesApplication.Team", "Team")
                        .WithOne("job")
                        .HasForeignKey("SementesApplication.Job", "TeamID")
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

            modelBuilder.Entity("SementesApplication.Volunteer", b =>
                {
                    b.HasOne("SementesApplication.Address", "Address")
                        .WithOne("Volunteer")
                        .HasForeignKey("SementesApplication.Volunteer", "AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SementesApplication.Team", null)
                        .WithMany("Volunteer")
                        .HasForeignKey("TeamID");

                    b.HasOne("SementesApplication.Team", null)
                        .WithMany("Volunteers")
                        .HasForeignKey("TeamID1");
                });
#pragma warning restore 612, 618
        }
    }
}
