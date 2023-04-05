using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
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
                new Movie() { Id = 1, Title = "Dune", Year=2021, Duration = new(1, 35, 0), CoverUrl = @"https://m.media-amazon.com/images/M/MV5BN2FjNmEyNWMtYzM0ZS00NjIyLTg5YzYtYThlMGVjNzE1OGViXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg" },
                new Movie() { Id = 2, Title = "The Green Mile", Year= 1999, Duration = new(2, 11, 0), CoverUrl = @"https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_FMjpg_UX1000_.jpg" },
                new Movie() { Id = 3, Title = "Titanic", Year=1997, Duration = new(3, 14, 0), CoverUrl = @"https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_.jpg" },
                new Movie() { Id = 4, Title = "The Terminator", Year=1984, Duration = new(2, 54, 0), CoverUrl = @"https://m.media-amazon.com/images/M/MV5BMGU2NzRmZjUtOGUxYS00ZjdjLWEwZWItY2NlM2JhNjkxNTFmXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg" }
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