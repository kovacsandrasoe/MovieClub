using Microsoft.EntityFrameworkCore;
using MovieClub.Entities;

namespace MovieClub.Data
{
    public class MovieClubContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }

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
