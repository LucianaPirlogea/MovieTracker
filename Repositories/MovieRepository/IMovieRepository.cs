using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieByName(string name);
        List<Movie> GetMoviesByCategory(string genre);
        List<Movie> GetMoviesByActor(string actor);
    }
}
