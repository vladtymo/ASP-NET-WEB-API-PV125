using DataAccess.Configurations;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace DataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base() { }
        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------- Data Initialisation -----------
            modelBuilder.SeedMovies();

            modelBuilder.ApplyConfiguration(new MovieConfigurations());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PV125_CINEMA_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            optionsBuilder.UseSqlServer(connStr);
        }

        // ---------------- Data Collections ----------------
        public DbSet<Movie> Movies { get; set; }
    }
}