using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CategoryOfMoviesRepository
{
    public class CategoryOfMoviesRepository : GenericRepository<CategoryOfMovie>, ICategoryOfMoviesRepository
    {
        public CategoryOfMoviesRepository(MovieTrackerContext context) : base(context) { }

        public async Task<CategoryOfMovie> GetCategoryOfMovieByIds(int movieId, int categoryId)
        {
            return await _context.CategoryOfMovies.Where(a => a.IdMovie.Equals(movieId) && a.IdCategory.Equals(categoryId)).FirstOrDefaultAsync();
        }
    }
}
