using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class CastDTO
    {
        public int IdMovie { get; set; }
        public int IdActor { get; set; }

        public CastDTO(Cast cast)
        {
            this.IdMovie = cast.IdMovie;
            this.IdActor = cast.IdActor;
        }
    }
}
