﻿// <auto-generated />
using System;
using MayTheFourth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MayTheFourth.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240422152716_AddPlanetModel")]
    partial class AddPlanetModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("MayTheFourth.Models.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CharacterId");

                    b.Property<long?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("MayTheFourth.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MovieId");

                    b.Property<long?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MayTheFourth.Models.Planet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("PlanetId");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RotationPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Planet");
                });

            modelBuilder.Entity("MayTheFourth.Models.StarShip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("StarShipId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StarShip");
                });

            modelBuilder.Entity("MayTheFourth.Models.Character", b =>
                {
                    b.HasOne("MayTheFourth.Models.Planet", null)
                        .WithMany("Characters")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("MayTheFourth.Models.Movie", b =>
                {
                    b.HasOne("MayTheFourth.Models.Planet", null)
                        .WithMany("Movies")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("MayTheFourth.Models.Planet", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
