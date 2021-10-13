﻿// <auto-generated />
using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelAPI.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20210924175207_InicijalniPodaci")]
    partial class InicijalniPodaci
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelAPI.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jamaica",
                            ShortName = "JM"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bajamas",
                            ShortName = "BS"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rumunija",
                            ShortName = "RO"
                        });
                });

            modelBuilder.Entity("HotelAPI.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Negril",
                            CountryId = 1,
                            Name = "Sandal Resort and Spa",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Nassua",
                            CountryId = 2,
                            Name = "Grand Palldium",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Tranasilvania",
                            CountryId = 3,
                            Name = "Hotel Grof Drakula",
                            Rating = 4.7999999999999998
                        });
                });

            modelBuilder.Entity("HotelAPI.Data.Hotel", b =>
                {
                    b.HasOne("HotelAPI.Data.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}