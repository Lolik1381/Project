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
    [Migration("20210508154838_Migration-11")]
    partial class Migration11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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

                    b.Property<int?>("Directionid")
                        .HasColumnType("integer");

                    b.Property<int>("countStars")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("hrefSite")
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
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.Property<string>("styleHotel")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Directionid");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("hotels");
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

                    b.Property<int?>("Directionid")
                        .HasColumnType("integer");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("mainPhotoid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.Property<string>("services")
                        .HasColumnType("text");

                    b.Property<string>("specialMenu")
                        .HasColumnType("text");

                    b.Property<string>("timeEating")
                        .HasColumnType("text");

                    b.Property<string>("typeCuisine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("webSite")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Directionid");

                    b.HasIndex("mainPhotoid");

                    b.ToTable("restaurants");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("dateTravel")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("hotelId")
                        .HasColumnType("integer");

                    b.Property<int?>("landmarkId")
                        .HasColumnType("integer");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.Property<int?>("restaurantId")
                        .HasColumnType("integer");

                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("hotelId");

                    b.HasIndex("landmarkId");

                    b.HasIndex("restaurantId");

                    b.HasIndex("userId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Project.Models.RoomEquipment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("photoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Hotelid");

                    b.HasIndex("photoid");

                    b.ToTable("roomEquipment");
                });

            modelBuilder.Entity("Project.Models.RoomType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("photoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Hotelid");

                    b.HasIndex("photoid");

                    b.ToTable("roomTypes");
                });

            modelBuilder.Entity("Project.Models.Services", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Hotelid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("photoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Hotelid");

                    b.HasIndex("photoid");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int?>("profileid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("profileid");

                    b.ToTable("AspNetUsers");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Project.Models.Direction", null)
                        .WithMany("hotels")
                        .HasForeignKey("Directionid");

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
                    b.HasOne("Project.Models.Direction", null)
                        .WithMany("restaurants")
                        .HasForeignKey("Directionid");

                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoid");

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("reviews")
                        .HasForeignKey("hotelId");

                    b.HasOne("Project.Models.Landmark", null)
                        .WithMany("reviews")
                        .HasForeignKey("landmarkId");

                    b.HasOne("Project.Models.Restaurant", null)
                        .WithMany("reviews")
                        .HasForeignKey("restaurantId");

                    b.HasOne("Project.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Project.Models.RoomEquipment", b =>
                {
                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("roomEquipment")
                        .HasForeignKey("Hotelid");

                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoid");

                    b.Navigation("photo");
                });

            modelBuilder.Entity("Project.Models.RoomType", b =>
                {
                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("roomType")
                        .HasForeignKey("Hotelid");

                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoid");

                    b.Navigation("photo");
                });

            modelBuilder.Entity("Project.Models.Services", b =>
                {
                    b.HasOne("Project.Models.Hotel", null)
                        .WithMany("services")
                        .HasForeignKey("Hotelid");

                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoid");

                    b.Navigation("photo");
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
                    b.Navigation("hotels");

                    b.Navigation("landmarks");

                    b.Navigation("photos");

                    b.Navigation("restaurants");
                });

            modelBuilder.Entity("Project.Models.Hotel", b =>
                {
                    b.Navigation("photos");

                    b.Navigation("reviews");

                    b.Navigation("roomEquipment");

                    b.Navigation("roomType");

                    b.Navigation("services");
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
