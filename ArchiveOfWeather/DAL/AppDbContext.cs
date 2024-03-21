using ArchiveOfWeather.Entities;
using ArchiveOfWeather.Services;
using Microsoft.EntityFrameworkCore;

namespace ArchiveOfWeather.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherInfo> WeatherInfo { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherInfo>()
                .HasKey(w => new { w.Date, w.Time });
        }
    }
}
