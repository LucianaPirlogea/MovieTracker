using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.WatchedRepository
{
    public interface IWatchedRepository : IGenericRepository<Watched>
    {
        Task<Watched> GetWatchedsByIds(int movieId, int userId);
    }
}
