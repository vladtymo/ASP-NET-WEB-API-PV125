using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbContextExtensions
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = (int)Genres.Sci_fi, Name = "Sci-fi" },
                new Genre() { Id = (int)Genres.Adventure, Name = "Adventure" },
                new Genre() { Id = (int)Genres.Romance, Name = "Romance" },
                new Genre() { Id = (int)Genres.Drama, Name = "Drama" },
                new Genre() { Id = (int)Genres.Fantasy, Name = "Fantasy" },
                new Genre() { Id = (int)Genres.Action, Name = "Action" },
                new Genre() { Id = (int)Genres.Anime, Name = "Anime" },
                new Genre() { Id = (int)Genres.History, Name = "History" },
                new Genre() { Id = (int)Genres.Biography, Name = "Biography" },
                new Genre() { Id = (int)Genres.Comedy, Name = "Comedy" }
            });
        }
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new[]
            {
                new Movie() { Id = 1, Name = "Dune", Year=2021 },
                new Movie() { Id = 2, Name = "The Green Mile", Year= 1999 },
                new Movie() { Id = 3, Name = "Titanic", Year=1997 },
                new Movie() { Id = 4, Name = "The Terminator", Year=1984 }
            });

            modelBuilder.Entity<MovieGenre>().HasData(new[]
            {
                new MovieGenre() { MovieId = 1, GenreId = (int)Genres.Sci_fi },
                new MovieGenre() { MovieId = 1, GenreId = (int)Genres.Fantasy },

                new MovieGenre() { MovieId = 2, GenreId = (int)Genres.Romance },
                new MovieGenre() { MovieId = 2, GenreId = (int)Genres.Drama },

                new MovieGenre() { MovieId = 3, GenreId = (int)Genres.History },

                new MovieGenre() { MovieId = 4, GenreId = (int)Genres.Action },
                new MovieGenre() { MovieId = 4, GenreId = (int)Genres.Sci_fi },
                new MovieGenre() { MovieId = 4, GenreId = (int)Genres.Adventure }
            });
        }
    }
}