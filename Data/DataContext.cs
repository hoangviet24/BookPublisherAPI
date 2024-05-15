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
        public DbSet<Image>Images { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasOne(b => b.Publishers).WithMany(b => b.IdBook).HasForeignKey(b=>b.PublisherId);
            builder.Entity<BookAuthor>().HasOne(b => b.Book).WithMany(b => b.BookList).HasForeignKey(b=>b.idbook);
            builder.Entity<BookAuthor>().HasOne(b=>b.Author).WithMany(b=>b.Author_List).HasForeignKey(b=>b.idauthor);
            new DbInitalize(builder).Seed();
        }
        public DbSet<BookPublisher.Models.DTO.BookWithAuthorAndPublisherDTO> BookWithAuthorAndPublisherDTO { get; set; } = default!;
        public DbSet<BookPublisher.Models.DTO.AuthorDTO> AuthorDTO { get; set; } = default!;
    }
}
