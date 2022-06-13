using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<List<Movie>> GetAllMovies();
    }
}
