using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieTrackerContext context) : base(context) { }

        public async Task<List<Category>> GetAllCategories()
        {
            return await GetAll().ToListAsync();
        }
    }
}
