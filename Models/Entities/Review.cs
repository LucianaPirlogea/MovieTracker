namespace MovieTracker.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int NumberOfStars { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Watched Watched { get; set; }
    }
}
