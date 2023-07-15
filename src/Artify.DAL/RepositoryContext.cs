using Artify.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artify.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        DbSet<Artwork>? Artworks { get; set; }
        DbSet<Author>? Authors { get; set; }
    }
}
