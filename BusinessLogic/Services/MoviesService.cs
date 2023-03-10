using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;
using Core.Helpers;
using System.Net;

namespace Core.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> moviesRepo;
        private readonly IMapper mapper;

        public MoviesService(IRepository<Movie> moviesRepo, IMapper mapper)
        {
            this.moviesRepo = moviesRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var result = await moviesRepo.GetListBySpec(new Movies.OrderedAll());

            return mapper.Map<IEnumerable<MovieDto>>(result);
        }

        public async Task<MovieDto?> GetById(int id)
        {
            Movie? item = await moviesRepo.GetItemBySpec(new Movies.ById(id));

            if (item == null) 
                throw new HttpException($"Movie with ID of {id} not found!", HttpStatusCode.NotFound);

            // map entity type to dto type

            //MovieDto dto = new()
            //{
            //    Id = item.Id,
            //    Name = item.Name,
            //    Year = item.Year
            //};

            return mapper.Map<MovieDto>(item);
        }

        public async Task Edit(MovieDto dto)
        {
            await moviesRepo.Update(mapper.Map<Movie>(dto));
            await moviesRepo.Save();
        }

        public async Task Create(MovieDto dto)
        {
            await moviesRepo.Insert(mapper.Map<Movie>(dto));
            await moviesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await moviesRepo.GetById(id) == null)
                throw new HttpException($"Movie with ID of {id} not found!", HttpStatusCode.NotFound);

            await moviesRepo.Delete(id);
            await moviesRepo.Save();
        }
    }
}
