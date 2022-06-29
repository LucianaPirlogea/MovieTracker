using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories;
using MovieTracker.Repositories.MovieRepository;
using MovieTracker.Repositories.WatchedRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchedController : ControllerBase
    {
        private readonly IWatchedRepository _repositoryWatched;
        private readonly IMovieRepository _repositoryMovie;
        private readonly IUserRepository _repositoryUser;

        public WatchedController(IWatchedRepository repositoryWatched, IMovieRepository repositoryMovie, IUserRepository repositoryUser)
        {
            _repositoryWatched = repositoryWatched;
            _repositoryMovie = repositoryMovie;
            _repositoryUser = repositoryUser;
        }

        //CREATE watched
        [HttpPost("AddWatched/{movieTitle}_{userEmail}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create(string movieTitle, string userEmail)
        {
            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie cannot be found!");
            }

            var user = await _repositoryUser.GetUsersByEmail(userEmail);
            if (user == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var watched = await _repositoryWatched.GetWatchedsByIds(movie.Id, user.Id);

            if (watched != null)
            {
                return BadRequest("This movie has already been viewed by this user.");
            }

            var newWatched = new Watched
            {
                IdMovie = movie.Id,
                IdUser = user.Id,
                Date = DateTime.Now
            };

            _repositoryWatched.Create(newWatched);
            await _repositoryWatched.SaveAsync();
            return Ok();
        }

        //DELETE watched
        [HttpDelete("DeleteWatched/{movieTitle}_{userEmail}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete(string movieTitle, string userEmail)
        {

            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie cannot be found!");
            }

            var user = await _repositoryUser.GetUsersByEmail(userEmail);
            if (user == null)
            {
                return BadRequest("The user cannot be found!");
            }

            var watchedDeleted = await _repositoryWatched.GetWatchedsByIds(movie.Id, user.Id);

            if (watchedDeleted == null)
            {
                return BadRequest("This movie has not been viewed by this user.");
            }
            _repositoryWatched.Delete(watchedDeleted);
            await _repositoryWatched.SaveAsync();
            return Ok();
        }
    }
}

