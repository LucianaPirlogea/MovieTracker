namespace MovieTracker.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Cast> Casts { get; set; }

    }
}
