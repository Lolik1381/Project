using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Direction> directions { get; set; }
        public DbSet<Landmark> landmarks { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<DirectionLandmarkLink> directionLandmarkLinks { get; set; }
        public DbSet<DirectionPhotoLink> directionPhotoLinks { get; set; }
        public DbSet<LandmarkPhotoLink> landmarkPhotoLinks { get; set; }
        public DbSet<LandmarkReviewLink> landmarkReviewLinks { get; set; }
        public DbSet<ReviewPhotoLink> reviewPhotoLinks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            if (DefaultSettings.isFirstData)
            {
                Database.EnsureDeleted();
            }

            Database.EnsureCreated();
        }
    }
}
