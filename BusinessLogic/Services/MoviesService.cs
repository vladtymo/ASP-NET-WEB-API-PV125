using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (item == null) return null; // throw exception

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
            if (await moviesRepo.GetById(id) == null) return; // throw exception

            await moviesRepo.Delete(id);
            await moviesRepo.Save();
        }
    }
}
