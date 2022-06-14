using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CategoryOfMoviesRepository
{
    public class CategoryOfMoviesRepository : GenericRepository<CategoryOfMovie>, ICategoryOfMoviesRepository
    {
        public CategoryOfMoviesRepository(MovieTrackerContext context) : base(context) { }
    }
}
