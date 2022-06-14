using MovieTracker.Entities;

namespace MovieTracker.Models.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public ActorDTO() { }

        public ActorDTO(Actor actor)
        {
            this.Id = actor.Id;
            this.Name = actor.Name;
            this.Image = actor.Image;
        }
    }
}
