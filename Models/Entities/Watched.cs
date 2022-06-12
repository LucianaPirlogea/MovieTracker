namespace MovieTracker.Entities
{
    public class Watched
    {
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int? IdReview { get; set; }
        public Review Review { get; set; }

    }
}
