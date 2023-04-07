using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Core.Specifications;
using Core.Entities;
using Core.Helpers;
using System.Net;
using Core.Resources;

namespace Core.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> moviesRepo;
        private readonly IRepository<Genre> genreRepo;
        private readonly IRepository<MovieGenre> movieGenRepo;
        private readonly IMapper mapper;

        public MoviesService(IRepository<Movie> moviesRepo,
                             IRepository<Genre> genreRepo,
                             IRepository<MovieGenre> movieGenRepo,
                             IMapper mapper)
        {
            this.moviesRepo = moviesRepo;
            this.genreRepo = genreRepo;
            this.movieGenRepo = movieGenRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var result = await moviesRepo.GetListBySpec(new Movies.OrderedAll());
            return mapper.Map<IEnumerable<MovieDto>>(result);
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var result = await genreRepo.GetAll();
            return mapper.Map<IEnumerable<GenreDto>>(result);
        }

        public async Task<MovieDto?> GetById(int id)
        {
            Movie? item = await moviesRepo.GetItemBySpec(new Movies.ById(id));

            if (item == null) 
                throw new HttpException(ErrorMessages.MovieNotFound, HttpStatusCode.NotFound);

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

        public async Task Create(CreateMovieDto dto)
        {
            var movie = mapper.Map<Movie>(dto);

            await moviesRepo.Insert(movie);
            await moviesRepo.Save();
            // after Save() we can get the movie id

            if (dto.GenreIds != null)
            {
                foreach (var gId in dto.GenreIds)
                {
                    await movieGenRepo.Insert(new MovieGenre()
                    {
                        GenreId = gId,
                        MovieId = movie.Id // created movie id
                    });
                }
            }

            await movieGenRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await moviesRepo.GetById(id) == null)
                throw new HttpException(ErrorMessages.MovieNotFound, HttpStatusCode.NotFound);

            await moviesRepo.Delete(id);
            await moviesRepo.Save();
        }
    }
}
