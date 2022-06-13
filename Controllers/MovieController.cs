using Microsoft.AspNetCore.Mvc;
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

    }
}
