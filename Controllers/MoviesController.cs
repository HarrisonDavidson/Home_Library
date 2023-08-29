using Microsoft.AspNetCore.Mvc;
using HomeLibrary.Models;
using HomeLibrary.Repositories;

namespace HomeLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _movieRepository;
        public MoviesController(IMoviesRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // https://localhost:5001/api/movies/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieRepository.GetAll());
        }

        // https://localhost:5001/api/movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // https://localhost:5001/api/movies/
        [HttpPost]
        public IActionResult Post(Movies movies)
        {
            _movieRepository.Add(movies);
            return CreatedAtAction("Get", new { id = movies.Id }, movies);
        }

        // https://localhost:5001/api/movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Movies movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _movieRepository.Update(movie);
            return NoContent();
        }

        // https://localhost:5001/api/movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieRepository.Delete(id);
            return NoContent();
        }
    }
}