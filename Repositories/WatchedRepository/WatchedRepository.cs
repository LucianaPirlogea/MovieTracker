using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.WatchedRepository
{
    public class WatchedRepository : GenericRepository<Watched>, IWatchedRepository
    {
        public WatchedRepository(MovieTrackerContext context) : base(context) { }

        public async Task<Watched> GetWatchedsByIds(int movieId, int userId)
        {
            return await _context.Watcheds.Where(a => a.IdMovie.Equals(movieId) && a.IdUser.Equals(userId)).FirstOrDefaultAsync();
        }
    }
}
