using BookPublisher.Models;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Publishers> publishers { get; set; }
        public DbSet<BookAuthor> book_authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasOne(b => b.Publishers).WithMany(b => b.IdBook);

            new DbInitalize(builder).Seed();
        }
    }
}
