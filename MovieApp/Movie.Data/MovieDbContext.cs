using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Models;

namespace MovieApp.Data
{
    public class MovieDbContext : IdentityDbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
