using Artify.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artify.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
