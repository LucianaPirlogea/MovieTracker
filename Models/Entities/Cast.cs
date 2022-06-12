namespace MovieTracker.Entities
{
    public class Cast
    {
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
        public int IdActor { get; set; }
        public Actor Actor { get; set; }

    }
}
