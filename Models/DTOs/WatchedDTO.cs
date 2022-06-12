using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class WatchedDTO
    {
        public int IdMovie { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public int? IdReview { get; set; }
        public WatchedDTO(Watched watched)
        {
            this.IdMovie = watched.IdMovie;
            this.IdUser = watched.IdUser;
            this.Date = watched.Date;
            this.IdReview = watched.IdReview;
        }
    }
}
