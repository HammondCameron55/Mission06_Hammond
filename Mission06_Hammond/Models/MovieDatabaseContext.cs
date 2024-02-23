using Microsoft.EntityFrameworkCore;

namespace Mission06_Hammond.Models
{
    public class MovieDatabaseContext :DbContext //Liasison between the database and the application
    {
        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options) //Constructor
        {}

        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<CategoriesModel> Categories { get; set; }
    }
}
