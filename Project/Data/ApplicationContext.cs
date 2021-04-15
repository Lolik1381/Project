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

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            if (DefaultSettings.isFirstData)
            {
                Database.EnsureDeleted();
            }

            Database.EnsureCreated();
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(DefaultData.createUser());
            *//*modelBuilder.Entity<Direction>().HasData(
                DefaultData.createDirection().ForEach(direction => new { direction.id, direction.name, PhotoId = 1 }).ToList()
            );*//*
            
            modelBuilder.Entity<Photo>().HasData(new { id = 1, image = DefaultData.getByteImage(@"wwwroot\img\vail.jpg"), name = @"img\vail.jpg" });
            foreach (Direction d in DefaultData.createDirection())
            {
                modelBuilder.Entity<Direction>().HasData(new { 
                    id = d.id, 
                    name = d.name, 
                    description = d.description,
                    shortDescription = d.shortDescription,
                    PhotoId = 1 
                });
            }

        }*/
    }
}
