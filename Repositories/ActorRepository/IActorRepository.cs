using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.ActorRepository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        Task<List<Actor>> GetAllActors();

        Task<Actor> GetActorByName(string name);

        List<Actor> GetActorsByMovie(string movieTitle);

    }
}
