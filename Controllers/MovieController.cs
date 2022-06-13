using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.MovieRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repositoryMovie;

        public MovieController(IMovieRepository repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;

        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        // READ toate filmele
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _repositoryMovie.GetAllMovies();

            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var auxMovie = new MovieDTO(movie);

                moviesToReturn.Add(auxMovie);
            }

            return Ok(moviesToReturn);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMovieByName(string name)
        {
            var movie = await _repositoryMovie.GetMovieByName(name);
            if(movie == null)
            {
                return BadRequest("The movie you search cannot be found!");
            }
            var movieToReturn = new MovieDTO(movie);

            return Ok(movieToReturn);

        }

        [HttpGet("Category/{genre}")]
        public async Task<IActionResult> GetMovieByCategory(string genre)
        {
            var movies = _repositoryMovie.GetMoviesByCategory(genre);
            if(!movies.Any())
            {
                return BadRequest("There are no movies for this category");
            }
            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var auxMovie = new MovieDTO(movie);

                moviesToReturn.Add(auxMovie);
            }

            return Ok(moviesToReturn);

        }

        [HttpGet("Actor/{actor}")]
        public async Task<IActionResult> GetMovieByActor(string actor)
        {
            var movies = _repositoryMovie.GetMoviesByActor(actor);
            if (!movies.Any())
            {
                return BadRequest("There are no movies for this actor");
            }
            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var auxMovie = new MovieDTO(movie);

                moviesToReturn.Add(auxMovie);
            }

            return Ok(moviesToReturn);

        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> Create([FromBody] MovieDTO movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description,
                Duration = movie.Duration,
                Poster = movie.Poster
            };

            _repositoryMovie.Create(newMovie);
            await _repositoryMovie.SaveAsync();
            return Ok();
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> Update([FromBody] MovieDTO movie)
        {
            var movieUpdated = await _repositoryMovie.GetMovieByName(movie.Title);
            movieUpdated.ReleaseDate = movie.ReleaseDate;
            movieUpdated.Description = movie.Description;
            movieUpdated.Duration = movie.Duration;
            movieUpdated.Poster = movie.Poster;
            _repositoryMovie.Update(movieUpdated);
            await _repositoryMovie.SaveAsync();
            return Ok();
        }

        [HttpDelete("DeleteMovie{name}")]
        public async Task<IActionResult> Delete([FromRoute] string name)
        {

            var movieDeleted = await _repositoryMovie.GetMovieByName(name);
            _repositoryMovie.Delete(movieDeleted);
            await _repositoryMovie.SaveAsync();
            return Ok();
        }

    }
}
