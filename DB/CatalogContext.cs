using System.Data.Entity;

namespace DB
{
    public class CatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
