using Microsoft.EntityFrameworkCore;


namespace MvcMovie.Data
{

    public class MvcMovieContext(DbContextOptions<MvcMovieContext> options) : DbContext(options)
    {
        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;

    }
}
