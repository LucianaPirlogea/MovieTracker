using MovieTracker.Entities;

namespace MovieTracker.Models.Entities
{
    public class UserFollowing
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int FollowingPersonId { get; set; }
        public virtual User FollowingPerson { get; set; }
    }
}
