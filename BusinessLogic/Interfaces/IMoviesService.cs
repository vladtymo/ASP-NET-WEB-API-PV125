using Core.Dtos;

namespace Core.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto?> GetById(int id);
        Task Create(MovieDto movie);
        Task Edit(MovieDto movie);
        Task Delete(int id);
    }
}
