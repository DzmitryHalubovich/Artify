using Artify.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Artify.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
