using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.CastRepository
{
    public interface ICastRepository : IGenericRepository<Cast>
    {
        Task<Cast> GetCastByIds(int movieId, int actorId);
    }
}
