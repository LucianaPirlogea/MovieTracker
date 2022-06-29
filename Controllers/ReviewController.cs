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
        //[Authorize(Roles = "User")]
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
        public async Task<IActionResult> GetReviewsByMovieTitle(string movieTitle)
        {
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
        public async Task<IActionResult> GetReviewByUserName(string userName)
        {
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
        public async Task<IActionResult> GetReviewByUserNameAndMovieTitle(string userName, string movieTitle)
        {
            var review = await _repositoryReview.GetReviewByUserNameAndMovieTitle(userName, movieTitle);

            if (review == null)
            {
                return BadRequest("There are no reviews for this username and movie");
            }

            var reviewToReturn = new ReviewDTO(review);

            return Ok(reviewToReturn);
        }

        [HttpPost("AddReview/{movieTitle}/{userEmail}")]
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
        public async Task<IActionResult> Update([FromBody] ReviewDTO review)
        {
            var reviewUpdated = await _repositoryReview.GetReviewById(review.Id);

            reviewUpdated.NumberOfStars = review.NumberOfStars;
            reviewUpdated.Comment = review.Comment;
            reviewUpdated.Date = DateTime.Now;
            _repositoryReview.Update(reviewUpdated);
            await _repositoryReview.SaveAsync();
            return Ok();
        }

        [HttpDelete("DeleteReview{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var reviewDeleted = await _repositoryReview.GetReviewById(id);

            _repositoryReview.Delete(reviewDeleted);
            await _repositoryReview.SaveAsync();
            return Ok();
        }
    }
}
