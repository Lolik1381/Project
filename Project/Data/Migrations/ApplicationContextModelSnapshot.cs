﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Context;

namespace Project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("mainPhotoId")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("shortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("mainPhotoId");

                    b.ToTable("directions");
                });

            modelBuilder.Entity("Project.Models.DirectionLandmarkLink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("directionId")
                        .HasColumnType("integer");

                    b.Property<int>("landmarkId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("directionId");

                    b.HasIndex("landmarkId");

                    b.ToTable("directionLandmarkLinks");
                });

            modelBuilder.Entity("Project.Models.DirectionPhotoLink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("directionId")
                        .HasColumnType("integer");

                    b.Property<int>("photoId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("directionId");

                    b.HasIndex("photoId");

                    b.ToTable("directionPhotoLinks");
                });

            modelBuilder.Entity("Project.Models.Landmark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("landmarks");
                });

            modelBuilder.Entity("Project.Models.LandmarkPhotoLink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("landmarkId")
                        .HasColumnType("integer");

                    b.Property<int>("photoId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("landmarkId");

                    b.HasIndex("photoId");

                    b.ToTable("landmarkPhotoLinks");
                });

            modelBuilder.Entity("Project.Models.LandmarkReviewLink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("landmarkId")
                        .HasColumnType("integer");

                    b.Property<int>("reviewId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("landmarkId");

                    b.HasIndex("reviewId");

                    b.ToTable("landmarkReviewLinks");
                });

            modelBuilder.Entity("Project.Models.Photo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("Project.Models.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("mainPhotoId")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userInfoId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("mainPhotoId");

                    b.HasIndex("userInfoId");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("rating")
                        .HasColumnType("numeric");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Project.Models.ReviewPhotoLink", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("photoId")
                        .HasColumnType("integer");

                    b.Property<int>("reviewId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("photoId");

                    b.HasIndex("reviewId");

                    b.ToTable("reviewPhotoLinks");
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

                    b.Property<int>("profileId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("profileId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Project.Models.UserInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("create")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("hrefWebSite")
                        .HasColumnType("text");

                    b.Property<string>("personalInformation")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("userInfos");
                });

            modelBuilder.Entity("Project.Models.Direction", b =>
                {
                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mainPhoto");
                });

            modelBuilder.Entity("Project.Models.DirectionLandmarkLink", b =>
                {
                    b.HasOne("Project.Models.Direction", "direction")
                        .WithMany()
                        .HasForeignKey("directionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Landmark", "landmark")
                        .WithMany()
                        .HasForeignKey("landmarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("direction");

                    b.Navigation("landmark");
                });

            modelBuilder.Entity("Project.Models.DirectionPhotoLink", b =>
                {
                    b.HasOne("Project.Models.Direction", "direction")
                        .WithMany()
                        .HasForeignKey("directionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("direction");

                    b.Navigation("photo");
                });

            modelBuilder.Entity("Project.Models.LandmarkPhotoLink", b =>
                {
                    b.HasOne("Project.Models.Landmark", "landmark")
                        .WithMany()
                        .HasForeignKey("landmarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("landmark");

                    b.Navigation("photo");
                });

            modelBuilder.Entity("Project.Models.LandmarkReviewLink", b =>
                {
                    b.HasOne("Project.Models.Landmark", "landmark")
                        .WithMany()
                        .HasForeignKey("landmarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Review", "review")
                        .WithMany()
                        .HasForeignKey("reviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("landmark");

                    b.Navigation("review");
                });

            modelBuilder.Entity("Project.Models.Profile", b =>
                {
                    b.HasOne("Project.Models.Photo", "mainPhoto")
                        .WithMany()
                        .HasForeignKey("mainPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.UserInfo", "userInfo")
                        .WithMany()
                        .HasForeignKey("userInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mainPhoto");

                    b.Navigation("userInfo");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.HasOne("Project.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Project.Models.ReviewPhotoLink", b =>
                {
                    b.HasOne("Project.Models.Photo", "photo")
                        .WithMany()
                        .HasForeignKey("photoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Review", "review")
                        .WithMany()
                        .HasForeignKey("reviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("photo");

                    b.Navigation("review");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.HasOne("Project.Models.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("profile");
                });
#pragma warning restore 612, 618
        }
    }
}
