using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTracker.Entities;
using MovieTracker.Models.Entities;

namespace MovieTracker.Data
{
    public class MovieTrackerContext: IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MovieTrackerContext(DbContextOptions<MovieTrackerContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryOfMovie> CategoryOfMovies { get; set; }
        public DbSet<Watched> Watcheds { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // One to Many


            modelBuilder.Entity<UserFollowing>(b =>
            {
                b.HasKey(e => new { e.UserId, e.FollowingPersonId });
                b.HasOne(e => e.User).WithMany(e => e.Following);
                b.HasOne(e => e.FollowingPerson).WithMany().OnDelete(DeleteBehavior.ClientSetNull);
            });


            // One to One

            modelBuilder.Entity<Review>()
                .HasOne(a => a.Watched)
                .WithOne(adr => adr.Review)
                .HasForeignKey<Watched>(a => a.IdReview)
                .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity<Cast>().HasKey(arp => new { arp.IdActor, arp.IdMovie });

            modelBuilder.Entity<Cast>()
                .HasOne(arp => arp.Movie)
                .WithMany(a => a.Casts)
                .HasForeignKey(arp => arp.IdMovie);

            modelBuilder.Entity<Cast>()
                .HasOne(arp => arp.Actor)
                .WithMany(rp => rp.Casts)
                .HasForeignKey(arp => arp.IdActor);


            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId); 
            });


            
        }

    }
}
