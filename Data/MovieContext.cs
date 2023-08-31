using Microsoft.EntityFrameworkCore;
using MovieTrackerAPI.Models;  // Add this to reference the Movie model.

namespace MovieTrackerAPI.Data   // Adjusted namespace to reflect folder structure.
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        
        // ... (rest of your class)
    }
}
