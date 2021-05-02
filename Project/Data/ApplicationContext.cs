﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> users { get; set; }
        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Direction> directions { get; set; }
        public DbSet<Landmark> landmarks { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Hotel> hotels { get; set; }

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
