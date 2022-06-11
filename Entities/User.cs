using Microsoft.AspNetCore.Identity;

namespace MovieTracker.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public int? FollowerId { get; set; }
        public virtual User Follower { get; set; }
        public virtual ICollection<User> FollowingUsers { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Watched> Watcheds { get; set; }
    }
}
