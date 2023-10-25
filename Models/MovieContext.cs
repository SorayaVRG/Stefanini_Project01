using Microsoft.EntityFrameworkCore;

namespace Stefanini_Project01.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
