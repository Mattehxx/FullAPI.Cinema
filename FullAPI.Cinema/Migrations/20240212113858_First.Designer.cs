﻿// <auto-generated />
using System;
using FullAPI.Cinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullAPI.Cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20240212113858_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FullAPI.Cinema.Data.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.HasIndex("ShowId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Limitation", b =>
                {
                    b.Property<int>("LimitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LimitationId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LimitationId");

                    b.ToTable("Limitations");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LimitationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("LimitationId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.MovieRoom", b =>
                {
                    b.Property<int>("MovieRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieRoomId"));

                    b.Property<int>("CleanTimeMins")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieRoomId");

                    b.ToTable("MovieRooms");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.MovieTechnology", b =>
                {
                    b.Property<int>("MovieTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieTechnologyId"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.HasKey("MovieTechnologyId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("MovieTechnologies");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.RoomTechnology", b =>
                {
                    b.Property<int>("RoomTechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTechnologyId"));

                    b.Property<int>("MovieRoomId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.HasKey("RoomTechnologyId");

                    b.HasIndex("MovieRoomId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("RoomTechnologies");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("MovieRoomId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ShowId");

                    b.HasIndex("MovieId");

                    b.HasIndex("MovieRoomId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Technology", b =>
                {
                    b.Property<int>("TechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnologyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnologyId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Activity", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.Employee", "Employee")
                        .WithMany("Activities")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Role", "Role")
                        .WithMany("Activities")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Show", "Show")
                        .WithMany("Activities")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Movie", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.Limitation", "Limitation")
                        .WithMany("Movies")
                        .HasForeignKey("LimitationId");

                    b.Navigation("Limitation");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.MovieTechnology", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.Movie", "Movie")
                        .WithMany("MovieTechnologies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Technology", "Technology")
                        .WithMany("MovieTechnologies")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.RoomTechnology", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.MovieRoom", "MovieRoom")
                        .WithMany("RoomTechnologies")
                        .HasForeignKey("MovieRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Technology", "Technology")
                        .WithMany("RoomTechnologies")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieRoom");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Show", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.MovieRoom", "MovieRoom")
                        .WithMany("Shows")
                        .HasForeignKey("MovieRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("MovieRoom");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Employee", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Limitation", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Movie", b =>
                {
                    b.Navigation("MovieTechnologies");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.MovieRoom", b =>
                {
                    b.Navigation("RoomTechnologies");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Role", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Show", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.Technology", b =>
                {
                    b.Navigation("MovieTechnologies");

                    b.Navigation("RoomTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
