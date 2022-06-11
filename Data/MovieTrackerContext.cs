using Microsoft.EntityFrameworkCore;
using MovieTracker.Entities;

namespace MovieTracker.Data
{
    public class MovieTrackerContext: DbContext
    {
        public MovieTrackerContext(DbContextOptions<MovieTrackerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryOfMovie> CategoryOfMovies { get; set; }
        public DbSet<Watched> Watcheds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many

            modelBuilder.Entity<User>()
                .HasOne(b => b.Follower)
                .WithMany(b => b.FollowingUsers)
                .HasForeignKey(b => b.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            // One to One

            modelBuilder.Entity<Review>()
                .HasOne(a => a.Watched)
                .WithOne(adr => adr.Review)
                .HasForeignKey<Watched>(a => a.IdReview);

            // Many to Many
            modelBuilder.Entity<Watched>().HasKey(arp => new { arp.IdMovie, arp.IdUser });

            modelBuilder.Entity<Watched>()
                .HasOne(arp => arp.Movie)
                .WithMany(a => a.Watcheds)
                .HasForeignKey(arp => arp.IdMovie);

            modelBuilder.Entity<Watched>()
                .HasOne(arp => arp.User)
                .WithMany(rp => rp.Watcheds)
                .HasForeignKey(arp => arp.IdUser);

            modelBuilder.Entity<CategoryOfMovie>().HasKey(arp => new { arp.IdMovie, arp.IdCategory });

            modelBuilder.Entity<CategoryOfMovie>()
                .HasOne(arp => arp.Movie)
                .WithMany(a => a.CategoryOfMovies)
                .HasForeignKey(arp => arp.IdMovie);

            modelBuilder.Entity<CategoryOfMovie>()
                .HasOne(arp => arp.Category)
                .WithMany(rp => rp.CategoryOfMovies)
                .HasForeignKey(arp => arp.IdCategory);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
