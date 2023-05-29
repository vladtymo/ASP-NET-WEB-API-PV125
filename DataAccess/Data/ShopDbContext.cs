using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    internal class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext() : base() { }
        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------- Set Configurations -----------
            //modelBuilder.ApplyConfiguration(new MovieConfigurations());
            //modelBuilder.ApplyConfiguration(new MovieConfigurations());
            //modelBuilder.ApplyConfiguration(new GenreConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // ----------- Data Initialisation -----------
            modelBuilder.SeedGenres();
            modelBuilder.SeedMovies();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = @"Server=tcp:cinema-server.database.windows.net,1433;Initial Catalog=cinemadb125;Persist Security Info=False;User ID=admin123;Password=Qwer1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connStr);
        }

        // ---------------- Data Collections ----------------
        public DbSet<Movie> Movies { get; set; }
    }
}