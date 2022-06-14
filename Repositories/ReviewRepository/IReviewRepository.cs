using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.ReviewRepository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        List<Review> GetReviewsByNumberOfStars(int numberOfStars);
        List<Review> GetReviewsByMovieTitle(string movieTitle);
        List<Review> GetReviewsByUserName(string userName);
        Task<Review> GetReviewByUserNameAndMovieTitle (string userName, string movieTitle);
    }
}
