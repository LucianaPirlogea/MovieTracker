using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Models.DTOs;
using MovieTracker.Repositories.GenericRepository;
using System.Linq;

namespace MovieTracker.Repositories.ReviewRepository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieTrackerContext context) : base(context) { }

        public async Task<List<Review>> GetAllReviews()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var reviews = (from a in _context.Reviews
                           where a.Id == id
                           select new
                           {
                               a.Id,
                               a.NumberOfStars,
                               a.Comment,
                               a.Date
                           });
            var reviewsToReturn = new List<Review>();
            foreach (var review in reviews)
            {
                Review newReview = new Review();
                newReview.Id = review.Id;
                newReview.NumberOfStars = review.NumberOfStars;
                newReview.Comment = review.Comment;
                newReview.Date = review.Date;
                reviewsToReturn.Add(newReview);
            }

            return reviewsToReturn[0];
        }

        public List<Review> GetReviewsByNumberOfStars(int numberOfStars)
        {
            var reviews = (from a in _context.Reviews
                           where a.NumberOfStars == numberOfStars
                           select new
                           {
                               a.Id,
                               a.NumberOfStars,
                               a.Comment,
                               a.Date
                           });
            var reviewsToReturn = new List<Review>();
            foreach (var review in reviews)
            {
                Review newReview = new Review();
                newReview.Id = review.Id;
                newReview.NumberOfStars = review.NumberOfStars;
                newReview.Comment = review.Comment;
                newReview.Date = review.Date;
                reviewsToReturn.Add(newReview);
            }

            return reviewsToReturn;
        }

        public List<Review> GetReviewsByMovieTitle(string movieTitle)
        {
            var reviews = (from a in _context.Reviews
                           join b in _context.Watcheds on a.Id equals b.IdReview
                           join c in _context.Movies on b.IdMovie equals c.Id
                           where c.Title == movieTitle
                           select new
                           {
                               a.Id,
                               a.NumberOfStars,
                               a.Comment,
                               a.Date
                           });

            var reviewsToReturn = new List<Review>();
            foreach (var review in reviews)
            {
                Review newReview = new Review();
                newReview.Id = review.Id;
                newReview.NumberOfStars = review.NumberOfStars;
                newReview.Comment = review.Comment;
                newReview.Date = review.Date;
                reviewsToReturn.Add(newReview);
            }

            return reviewsToReturn;
        }

        public List<Review> GetReviewsByUserName(string userName)
        {
            var reviews = (from a in _context.Reviews
                           join b in _context.Watcheds on a.Id equals b.IdReview
                           join c in _context.Users on b.IdUser equals c.Id
                           where c.UserName == userName
                           select new
                           {
                               a.Id,
                               a.NumberOfStars,
                               a.Comment,
                               a.Date
                           });

            var reviewsToReturn = new List<Review>();
            foreach (var review in reviews)
            {
                Review newReview = new Review();
                newReview.Id = review.Id;
                newReview.NumberOfStars = review.NumberOfStars;
                newReview.Comment = review.Comment;
                newReview.Date = review.Date;
                reviewsToReturn.Add(newReview);
            }

            return reviewsToReturn;
        }

        public async Task<Review> GetReviewByUserNameAndMovieTitle (string userName, string movieTitle)
        {
            var reviews = (from a in _context.Reviews
                          join b in _context.Watcheds on a.Id equals b.IdReview
                          join c in _context.Users on b.IdUser equals c.Id
                          join d in _context.Movies on b.IdMovie equals d.Id
                          where c.UserName == userName && d.Title == movieTitle
                          select new
                          {
                              a.Id,
                              a.NumberOfStars,
                              a.Comment,
                              a.Date
                          });

            var reviewsToReturn = new List<Review>();
            foreach (var review in reviews)
            {
                Review newReview = new Review();
                newReview.Id = review.Id;
                newReview.NumberOfStars = review.NumberOfStars;
                newReview.Comment = review.Comment;
                newReview.Date = review.Date;
                reviewsToReturn.Add(newReview);
            }

            return reviewsToReturn[0];

        }
    }
}
