using PresentationBuilder.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PresentationBuilder.WebAPI.Data
{
    public class PresentationContext : DbContext
    {
        public PresentationContext(DbContextOptions<PresentationContext> options) : base(options)
        {
        }

        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presentation>().ToTable("Presentation");
            modelBuilder.Entity<Page>().ToTable("Page");
            modelBuilder.Entity<Author>().ToTable("Author");
        }

    }

}