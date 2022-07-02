using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories;
using MovieTracker.Repositories.MovieRepository;
using MovieTracker.Repositories.ReviewRepository;
using MovieTracker.Repositories.WatchedRepository;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repositoryReview;
        private readonly IWatchedRepository _repositoryWatched;
        private readonly IMovieRepository _repositoryMovie;
        private readonly IUserRepository _repositoryUser;

        public ReviewController(IReviewRepository repositoryReview, IWatchedRepository repositoryWatched, IMovieRepository repositoryMovie, IUserRepository repositoryUser)
        {
            _repositoryReview = repositoryReview;
            _repositoryWatched = repositoryWatched;
            _repositoryMovie = repositoryMovie;
            _repositoryUser = repositoryUser;
        }

        [HttpGet]
        [AllowAnonymous]
        // READ toate reviewurile
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _repositoryReview.GetAllReviews();

            var reviewsToReturn = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                var auxReview = new ReviewDTO(review);

                reviewsToReturn.Add(auxReview);
            }

            return Ok(reviewsToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _repositoryReview.GetReviewById(id);

            if (review == null)
            {
                return BadRequest("There is no review with this id");
            }

            var reviewToReturn = new ReviewDTO(review);

            return Ok(reviewToReturn);
        }

        [HttpGet("Review/{numberOfStars}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetReviewsByNumberOfStars(int numberOfStars)
        {
            var reviews = _repositoryReview.GetReviewsByNumberOfStars(numberOfStars);

            if (!reviews.Any())
            {
                return BadRequest("There are no reviews for this number of stars");
            }

            var reviewsToReturn = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                var auxReview = new ReviewDTO(review);
                reviewsToReturn.Add(auxReview);
            }

            return Ok(reviewsToReturn);
        }

        [HttpGet("Movie/{movieTitle}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetReviewsByMovieTitle(string movieTitle)
        {
            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie you search cannot be found!");
            }
            var reviews = _repositoryReview.GetReviewsByMovieTitle(movieTitle);

            if (!reviews.Any())
            {
                return BadRequest("There are no reviews for this movie title");
            }

            var reviewsToReturn = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                var auxReview = new ReviewDTO(review);
                reviewsToReturn.Add(auxReview);
            }

            return Ok(reviewsToReturn);
        }

        [HttpGet("User/{userName}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetReviewByUserName(string userName)
        {
            var user = await _repositoryUser.GetUsersByEmail(userName);

            if (user == null)
            {
                return BadRequest("There is no user with this username");
            }
            var reviews = _repositoryReview.GetReviewsByUserName(userName);

            if (!reviews.Any())
            {
                return BadRequest("There are no reviews for this user name");
            }

            var reviewsToReturn = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                var auxReview = new ReviewDTO(review);
                reviewsToReturn.Add(auxReview);
            }

            return Ok(reviewsToReturn);
        }

        [HttpGet("{userName}/{movieTitle}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetReviewByUserNameAndMovieTitle(string userName, string movieTitle)
        {
            var user = await _repositoryUser.GetUsersByEmail(userName);

            if (user == null)
            {
                return BadRequest("There is no user with this username");
            }

            var movie = await _repositoryMovie.GetMovieByName(movieTitle);
            if (movie == null)
            {
                return BadRequest("The movie you search cannot be found!");
            }

            var review = await _repositoryReview.GetReviewByUserNameAndMovieTitle(userName, movieTitle);

            if (review == null)
            {
                return BadRequest("There are no reviews for this username and movie");
            }

            var reviewToReturn = new ReviewDTO(review);

            return Ok(reviewToReturn);
        }

        [HttpPost("AddReview/{movieTitle}/{userEmail}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create([FromBody] ReviewDTO review, string movieTitle, string userEmail)
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

            if (watched == null)
            {
                return BadRequest("You can't rate this movie before watching it.");
            }
            
            var newReview = new Review
            {
                NumberOfStars = review.NumberOfStars,
                Comment = review.Comment,
                Date = DateTime.Now
            };

            _repositoryReview.Create(newReview);
            await _repositoryReview.SaveAsync();

            watched.IdReview = newReview.Id;
            _repositoryWatched.Update(watched);
            await _repositoryWatched.SaveAsync();

            return Ok();
        }

        [HttpPut("UpdateReview")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Update([FromBody] ReviewDTO review)
        {
            var reviewUpdated = await _repositoryReview.GetReviewById(review.Id);
            if (reviewUpdated == null)
            {
                return BadRequest("The review does not exist");
            }
            reviewUpdated.NumberOfStars = review.NumberOfStars;
            reviewUpdated.Comment = review.Comment;
            reviewUpdated.Date = DateTime.Now;
            _repositoryReview.Update(reviewUpdated);
            await _repositoryReview.SaveAsync();
            return Ok();
        }

        [HttpDelete("DeleteReview{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var reviewDeleted = await _repositoryReview.GetReviewById(id);
            if (reviewDeleted == null)
            {
                return BadRequest("The review does not exist");
            }
            _repositoryReview.Delete(reviewDeleted);
            await _repositoryReview.SaveAsync();
            return Ok();
        }
    }
}
