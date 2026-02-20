using AplicaçãoTesteRazorPages.Domain.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace AplicaçãoTesteRazorPages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(b => b.Books)
                .WithOne(b => b.Author)
                .HasForeignKey("AuthorId");
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Books)
                .WithMany(c => c.Categories);   
        }

    } 
}
