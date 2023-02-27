using BusinessLogic.Interfaces;
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
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]                   // GET: ~/api/movies
        //[HttpGet("collection")]   // GET: ~/api/movies/collection
        //[HttpGet("/movies")]      // GET: ~/movies
        public async Task<IActionResult> Get()
        {
            return Ok(await moviesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // FromQuery, FromRoute
        {
            var item = await moviesService.GetById(id);
            if (item == null) return NotFound();

            return Ok(item); // JSON
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie movie)
        {
            await moviesService.Create(movie);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Movie movie)
        {
            await moviesService.Edit(movie);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await moviesService.Delete(id);

            return Ok();
        }
    }
}
