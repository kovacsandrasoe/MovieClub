using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieClub.Entities;

namespace MovieClub.Data
{
    public class MovieClubContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public MovieClubContext(DbContextOptions<MovieClubContext> ctx)
            :base(ctx)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Ratings)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
