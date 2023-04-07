using Core.Dtos;

namespace Core.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<MovieDto?> GetById(int id);
        Task Create(CreateMovieDto movie);
        Task Edit(MovieDto movie);
        Task Delete(int id);
    }
}
