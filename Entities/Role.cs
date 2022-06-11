using Microsoft.AspNetCore.Identity;

namespace MovieTracker.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
