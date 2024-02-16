using Microsoft.EntityFrameworkCore;

namespace Mission06_Hammond.Models
{
    public class MovieDatabaseContext :DbContext
    {
        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options) //Constructor
        {}

        public DbSet<MovieSubmit> movieSubmits { get; set; }
        
    }
}
