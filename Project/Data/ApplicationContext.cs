using Microsoft.EntityFrameworkCore;
using Project.Models;

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
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Hotel> restingPlaces { get; set; }

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
