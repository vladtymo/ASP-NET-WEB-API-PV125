﻿using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await moviesService.GetGenres());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // FromQuery, FromRoute
        {
            var item = await moviesService.GetById(id);

            return Ok(item); // JSON
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieDto movie)
        {
            if (!ModelState.IsValid) return BadRequest();

            await moviesService.Create(movie);

            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Edit([FromBody] MovieDto movie)
        {
            if (!ModelState.IsValid) return BadRequest();

            await moviesService.Edit(movie);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await moviesService.Delete(id);

            return Ok();
        }
    }
}
