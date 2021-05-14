﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Context;

namespace Project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210420102727_Migration-2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Project.Models.Direction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("shortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("directions");
                });

            modelBuilder.Entity("Project.Models.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("countStars")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("hrefSite")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("languages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("styleHotel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("restingPlaces");
                });

            modelBuilder.Entity("Project.Models.Landmark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Directionid")
                        .HasColumnType("integer");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("Directionid");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("landmarks");
                });

            modelBuilder.Entity("Project.Models.Photo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Directionid")
                        .HasColumnType("integer");

                    b.Property<int?>("Hotelid")
                        .HasColumnType("integer");

                    b.Property<int?>("Landmarkid")
                        .HasColumnType("integer");

                    b.Property<int?>("Restaurantid")
                        .HasColumnType("integer");

                    b.Property<int?>("Reviewid")
                        .HasColumnType("integer");

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Directionid");

                    b.HasIndex("Hotelid");

                    b.HasIndex("Landmarkid");

                    b.HasIndex("Restaurantid");

                    b.HasIndex("Reviewid");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("Project.Models.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("backgroundPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("userInfoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("backgroundPhotoid");

                    b.HasIndex("mainPhotoid");

                    b.HasIndex("userInfoid");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Project.Models.Restaurant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("service")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("typeCuisine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("webSite")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("restaurants");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Hotelid")
                        .HasColumnType("integer");

                    b.Property<int?>("Landmarkid")
                        .HasColumnType("integer");

                    b.Property<int?>("Restaurantid")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.Property<int?>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Hotelid");

                    b.HasIndex("Landmarkid");

                    b.HasIndex("Restaurantid");

                    b.HasIndex("userid");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("profileid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("profileid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Project.Models.UserInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("create")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("hrefWebSite")
                        .HasColumnType("text");

                    b.Property<string>("personalInformation")
                        .HasColumnType("text");

                    b.Property<string>("placeResidence")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("userInfos");
                });

            modelBuilder.Entity("Project.Models.Direction", b =>
                {
                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.Hotel", b =>
                {
                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.Landmark", b =>
                {
                    b.HasOne("Project.Models.Direction", null)
                        .WithMany("landmarks")
                        .HasForeignKey("Directionid");

                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.Photo", b =>
                {
                    b.HasOne("Project.Models.Direction", null)
                        .WithMany("photos")
                        .HasForeignKey("Directionid");

                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("photos")
                        .HasForeignKey("Hotelid");

                    b.HasOne("Project.Models.Landmark", null)
                        .WithMany("photos")
                        .HasForeignKey("Landmarkid");

                    b.HasOne("Project.Models.Restaurant", null)
                        .WithMany("photos")
                        .HasForeignKey("Restaurantid");

                    b.HasOne("Project.Models.Review", null)
                        .WithMany("photos")
                        .HasForeignKey("Reviewid");
                });

            modelBuilder.Entity("Project.Models.Profile", b =>
                {
                    b.HasOne("Project.Models.Photo", "backgroundPhoto")
                        .WithMany()
                        .HasForeignKey("backgroundPhotoid");

                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.HasOne("Project.Models.UserInfo", "userInfo")
                        .WithMany()
                        .HasForeignKey("userInfoid");

                    b.Navigation("backgroundPhoto");

                    b.Navigation("mainPhoto");

                    b.Navigation("userInfo");
                });

            modelBuilder.Entity("Project.Models.Restaurant", b =>
                {
                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("reviews")
                        .HasForeignKey("Hotelid");

                    b.HasOne("Project.Models.Landmark", null)
                        .WithMany("reviews")
                        .HasForeignKey("Landmarkid");

                    b.HasOne("Project.Models.Restaurant", null)
                        .WithMany("reviews")
                        .HasForeignKey("Restaurantid");

                    b.HasOne("Project.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.HasOne("Project.Models.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileid");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Project.Models.Direction", b =>
                {
                    b.Navigation("landmarks");

                    b.Navigation("photos");
                });

            modelBuilder.Entity("Project.Models.Hotel", b =>
                {
                    b.Navigation("photos");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("Project.Models.Landmark", b =>
                {
                    b.Navigation("photos");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("Project.Models.Restaurant", b =>
                {
                    b.Navigation("photos");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Navigation("photos");
                });
#pragma warning restore 612, 618
        }
    }
}
