﻿// <auto-generated />
using System;
using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLAPI.Migrations
{
    [DbContext(typeof(MyHotelDbContext))]
    [Migration("20220128150557_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLAPI.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alper Ebicoglu",
                            RegisterDate = new DateTime(2022, 1, 18, 20, 35, 56, 691, DateTimeKind.Local).AddTicks(714)
                        },
                        new
                        {
                            Id = 2,
                            Name = "George Michael",
                            RegisterDate = new DateTime(2022, 1, 23, 20, 35, 56, 743, DateTimeKind.Local).AddTicks(5102)
                        },
                        new
                        {
                            Id = 3,
                            Name = "Daft Punk",
                            RegisterDate = new DateTime(2022, 1, 27, 20, 35, 56, 743, DateTimeKind.Local).AddTicks(5607)
                        });
                });

            modelBuilder.Entity("GraphQLAPI.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckinDate = new DateTime(2022, 1, 26, 20, 35, 56, 745, DateTimeKind.Local).AddTicks(1018),
                            CheckoutDate = new DateTime(2022, 1, 31, 20, 35, 56, 745, DateTimeKind.Local).AddTicks(1061),
                            GuestId = 1,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 2,
                            CheckinDate = new DateTime(2022, 1, 27, 20, 35, 56, 746, DateTimeKind.Local).AddTicks(5109),
                            CheckoutDate = new DateTime(2022, 2, 1, 20, 35, 56, 746, DateTimeKind.Local).AddTicks(5153),
                            GuestId = 2,
                            RoomId = 4
                        });
                });

            modelBuilder.Entity("GraphQLAPI.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowedSmoking")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowedSmoking = false,
                            Name = "yellow-room",
                            Number = 101,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            AllowedSmoking = false,
                            Name = "blue-room",
                            Number = 102,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            AllowedSmoking = false,
                            Name = "white-room",
                            Number = 103,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            AllowedSmoking = false,
                            Name = "black-room",
                            Number = 104,
                            Status = 0
                        });
                });

            modelBuilder.Entity("GraphQLAPI.Models.Reservation", b =>
                {
                    b.HasOne("GraphQLAPI.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQLAPI.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}