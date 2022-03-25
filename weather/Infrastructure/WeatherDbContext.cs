using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Infrastructure
{
    public class WeatherDbContext : DbContext
    {

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}
