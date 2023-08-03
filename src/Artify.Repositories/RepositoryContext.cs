using Artify.Entities.Models;
using Artify.Repositories.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Artify.Repository
{
    public class RepositoryContext : IdentityDbContext<Author>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
