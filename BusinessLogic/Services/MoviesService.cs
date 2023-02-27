using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> moviesRepo;

        public MoviesService(IRepository<Movie> moviesRepo)
        {
            this.moviesRepo = moviesRepo;
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await moviesRepo.Get();
        }

        public async Task<Movie?> GetById(int id)
        {
            if (await moviesRepo.GetByID(id) == null) return null; // throw exception

            return await moviesRepo.GetByID(id);
        }

        public async Task Edit(Movie movie)
        {
            await moviesRepo.Update(movie);
            await moviesRepo.Save();
        }

        public async Task Create(Movie movie)
        {
            await moviesRepo.Insert(movie);
            await moviesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await moviesRepo.GetByID(id) == null) return; // throw exception

            await moviesRepo.Delete(id);
            await moviesRepo.Save();
        }
    }
}
