namespace MovieTracker.Entities
{
    public class CategoryOfMovie
    {
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}
