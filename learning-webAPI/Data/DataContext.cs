using learning_webAPI.WebAPIClasses;

namespace learning_webAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<superhero> SuperHeroes { get; set; }

    }
}
 