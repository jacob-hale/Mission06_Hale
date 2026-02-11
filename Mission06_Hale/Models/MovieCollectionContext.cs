using Microsoft.EntityFrameworkCore;

namespace Mission06_Hale.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
        {
            // leave blank for now
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
