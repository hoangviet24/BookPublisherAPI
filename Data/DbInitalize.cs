using BookPublisher.Models;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Data
{
    internal class DbInitalize
    {
        private ModelBuilder _builder;

        public DbInitalize(ModelBuilder builder)
        {
            this._builder = builder;
        }
        public void Seed()
        {
            #region Nhập Author
            _builder.Entity<Author>(a =>
            {
                a.HasData(new Author
                {
                    Id = 1,
                    IdList = 1,
                    Name = "Võ Hoàng Việt"
                });
                a.HasData(new Author
                {
                    Id = 2,
                    IdList = 2,
                    Name = "Nguyễn Phạm Phương Linh"
                });
            });
            #endregion
            #region Nhập sách
            _builder.Entity<Book>(b =>
            {
                b.HasData(new Book
                {
                    Id = 1,
                    Title = "Sách hay",
                    DateAdd = new DateTime(2004,1,28,15,0,0),
                    DateRead = new DateOnly(2024,4,15),
                    Rate = 4,
                    IsRead = false,
                    Genre = Genre.Development,
                    PublisherId = 1,
                    CoverUrl = "Hello",
                    Description = "Chưa biết",
                }) ;
                b.HasData(new Book
                {
                    Id = 2,
                    Title = "Sách hay",
                    DateAdd = new DateTime(2004, 1, 28, 15, 0, 0),
                    DateRead = new DateOnly(2024, 4, 15),
                    Rate = 3,
                    IsRead = false,
                    Genre = Genre.Development,
                    PublisherId = 1,
                    CoverUrl = "Hello",
                    Description = "Chưa biết",
                });
            });
            #endregion
            #region Nhập publisher
            _builder.Entity<Publishers>(p =>
            {
                p.HasData(new Publishers
                {
                    Id = 1,
                    Name = "NoName",
                    BookId = 1,
                });
            });
            #endregion
            #region Nhập Book_Author
            _builder.Entity<BookAuthor>(ba =>
            {
                ba.HasData(new BookAuthor
                {
                    Id = 1,
                    idbook = 1,
                    idauthor = 1,
                });
                ba.HasData(new BookAuthor
                {
                    Id = 2,
                    idbook = 2,
                    idauthor = 2,
                });
            });
            #endregion
        }
    }
}