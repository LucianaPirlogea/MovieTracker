using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieTrackerContext context) : base(context) { }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await GetAll().ToListAsync();
        }
    }
}
