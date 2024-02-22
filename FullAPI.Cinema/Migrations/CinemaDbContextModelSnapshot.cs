﻿// <auto-generated />
using System;
using FullAPI.Cinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullAPI.Cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Duration")
                        .HasColumnType("int");

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

                    b.Property<string>("TechnologyType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnologyId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("MovieRoomTechnology", b =>
                {
                    b.Property<int>("MovieRoomsMovieRoomId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologiesTechnologyId")
                        .HasColumnType("int");

                    b.HasKey("MovieRoomsMovieRoomId", "TechnologiesTechnologyId");

                    b.HasIndex("TechnologiesTechnologyId");

                    b.ToTable("MovieRoomTechnology");
                });

            modelBuilder.Entity("MovieTechnology", b =>
                {
                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologiesTechnologyId")
                        .HasColumnType("int");

                    b.HasKey("MoviesMovieId", "TechnologiesTechnologyId");

                    b.HasIndex("TechnologiesTechnologyId");

                    b.ToTable("MovieTechnology");
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

            modelBuilder.Entity("MovieRoomTechnology", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.MovieRoom", null)
                        .WithMany()
                        .HasForeignKey("MovieRoomsMovieRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieTechnology", b =>
                {
                    b.HasOne("FullAPI.Cinema.Data.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullAPI.Cinema.Data.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("FullAPI.Cinema.Data.MovieRoom", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
