using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CategoryOfMoviesRepository
{
    public interface ICategoryOfMoviesRepository : IGenericRepository<CategoryOfMovie>
    {
        Task<CategoryOfMovie> GetCategoryOfMovieByIds(int movieId, int categoryId);
    }
}
