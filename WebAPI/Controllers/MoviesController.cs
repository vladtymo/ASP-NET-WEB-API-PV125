using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> moviesRepo;

        public MoviesController(IRepository<Movie> moviesRepo)
        {
            this.moviesRepo = moviesRepo;
        }

        [HttpGet]                   // GET: ~/api/movies
        //[HttpGet("collection")]   // GET: ~/api/movies/collection
        //[HttpGet("/movies")]      // GET: ~/movies
        public IActionResult Get()
        {
            return Ok(moviesRepo.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id) // FromQuery, FromRoute
        {
            if (moviesRepo.GetByID(id) == null) 
                return NotFound();

            return Ok(moviesRepo.GetByID(id)); // JSON
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            moviesRepo.Insert(movie);
            moviesRepo.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Movie movie)
        {
            moviesRepo.Update(movie);
            moviesRepo.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (moviesRepo.GetByID(id) == null) 
                return BadRequest();

            moviesRepo.Delete(id);
            moviesRepo.Save();

            return Ok();
        }
    }
}
