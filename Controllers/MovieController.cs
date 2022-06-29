using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories;
using MovieTracker.Repositories.MovieRepository;
using MovieTracker.Repositories.UserFollowingRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repositoryMovie;
        private readonly IUserRepository _repositoryUser;
        private readonly IUserFollowingRepository _repositoryUserFollowing;

        public MovieController(IMovieRepository repositoryMovie, IUserRepository repositoryUser, IUserFollowingRepository repositoryUserFollowing)
        {
            _repositoryMovie = repositoryMovie;
            _repositoryUserFollowing = repositoryUserFollowing;
            _repositoryUser = repositoryUser;
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

        [HttpGet("Movie/{userEmail}")]
        public async Task<IActionResult> GetMoviesForUser(string userEmail)
        {
            var movies = _repositoryMovie.GetMoviesByUser(userEmail);
            if (!movies.Any())
            {
                return BadRequest("This user didn't watch any movie.");
            }
            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var auxMovie = new MovieDTO(movie);

                moviesToReturn.Add(auxMovie);
            }

            return Ok(moviesToReturn);
        }

        [HttpGet("Movie/Follower/{userEmail}/{followerEmail}")]
        public async Task<IActionResult> GetMoviesForFollower(string userEmail, string followerEmail)
        {
            var user1 = await _repositoryUser.GetUsersByEmail(userEmail);
            var user2 = await _repositoryUser.GetUsersByEmail(followerEmail);
            var userFollowing = await _repositoryUserFollowing.GetUserFollowingByIds(user1.Id, user2.Id);

            if (userFollowing == null)
            {
                return BadRequest("You need to follow this user in order to see their watched movies.");
            }

            var movies = _repositoryMovie.GetMoviesByUser(followerEmail);
            if (!movies.Any())
            {
                return BadRequest("This user didn't watch any movie.");
            }
            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var auxMovie = new MovieDTO(movie);

                moviesToReturn.Add(auxMovie);
            }

            return Ok(moviesToReturn);
        }

        [HttpGet("MovieSuggestions/{userEmail}")]
        public async Task<IActionResult> GetMovieSuggestionsForUser(string userEmail)
        {
            var movies = _repositoryMovie.GetSuggestionsForUser(userEmail);
            if (movies == null)
            {
                var popularMovies = _repositoryMovie.GetPopularMovies();

                var popularMoviesToReturn = new List<MovieDTO>();

                foreach (var movie in popularMovies)
                {

                    var auxMovie = new MovieDTO(movie);

                    popularMoviesToReturn.Add(auxMovie);
                }

                return Ok(popularMoviesToReturn);
            }

            var watchedMovies = _repositoryMovie.GetMoviesByUser(userEmail);

            var moviesToReturn = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                if (watchedMovies.Contains(movie))
                {
                    var auxMovie = new MovieDTO(movie);

                    moviesToReturn.Add(auxMovie);
                }
            }

            if (!moviesToReturn.Any())
            {
                return BadRequest("There are no suggestions for you.");
            }

            return Ok(moviesToReturn);
        }

        [HttpGet("PopularMovies")]
        public async Task<IActionResult> GetPopularMovies()
        {
            var movies = _repositoryMovie.GetPopularMovies();

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

            if (movieDeleted == null)
            {
                return BadRequest("There is no movie with this name");
            }
            _repositoryMovie.Delete(movieDeleted);
            await _repositoryMovie.SaveAsync();
            return Ok();
        }

    }
}
