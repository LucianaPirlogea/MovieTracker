using Microsoft.AspNetCore.Identity;
using MovieTracker.Models.Entities;

namespace MovieTracker.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserFollowing> Following { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Watched> Watcheds { get; set; }
    }
}
