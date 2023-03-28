using Lab5_CodeFirst_FromScratch.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5_CodeFirst_FromScratch.Models
{
    public class BookStoreDBContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }
        public virtual DbSet<PriceOffer> PriceOffers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=BookStoreDB;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(b => new { b.BookId, b.AuthorId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

