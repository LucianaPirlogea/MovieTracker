using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Entities;
using MovieTracker.Repositories.GenericRepository;

namespace MovieTracker.Repositories.ActorRepository
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieTrackerContext context) : base(context) { }

        public async Task<List<Actor>> GetAllActors()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Actor> GetActorByName(string name)
        {
            return await _context.Actors.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public List<Actor> GetActorsByMovie(string movieTitle)
        {
            var actors = (from a in _context.Actors
                          join b in _context.Casts on a.Id equals b.IdActor
                          join c in _context.Movies on b.IdMovie equals c.Id
                          where c.Title == movieTitle
                          select new
                          {
                              a.Id,
                              a.Name,
                              a.Image
                          });
            var actorsToReturn = new List<Actor>();
            foreach (var actor in actors)
            {
                Actor newActor = new Actor();
                newActor.Id = actor.Id;
                newActor.Name = actor.Name;
                newActor.Image = actor.Image;
                actorsToReturn.Add(newActor);
            }
            return actorsToReturn;
        }
    }
}
