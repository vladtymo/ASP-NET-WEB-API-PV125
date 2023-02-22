using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbContextExtensions
    {
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new[]
            {
                new Movie() { Id = 1, Name = "Dune", Genre="Sci-fi/Adventur", Year=2021 },
                new Movie() { Id = 2, Name = "The Green Mile", Year= 1999, Genre="Drama/Fantasy" },
                new Movie() { Id = 3, Name = "Titanic", Genre="Romance/Drama", Year=1997 },
                new Movie() { Id = 4, Name = "The Terminator", Genre="Sci-fi/Action", Year=1984 }
            });
        }
    }
}