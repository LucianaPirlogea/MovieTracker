using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CastRepository
{
    public class CastRepository : GenericRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieTrackerContext context) : base(context) { }

        public async Task<Cast> GetCastByIds(int movieId, int actorId)
        {
            return await _context.Casts.Where(a => a.IdMovie.Equals(movieId) && a.IdActor.Equals(actorId)).FirstOrDefaultAsync();
        }
    }
}
