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
        public Task GetAll()
        {
            return moviesRepo.Get();
        }

        public Task<Movie?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
