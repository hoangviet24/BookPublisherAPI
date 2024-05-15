using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // Thêm 
        public AddBookDTO AddBook(AddBookDTO bookDTO)
        {
            var bookmainDomain = new Book
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                IsRead = bookDTO.isRead,
                DateRead = bookDTO.DateRead,
                DateAdd = bookDTO.DateAdd,
                Rate = bookDTO.Rate,
                Genre = bookDTO.Genre,
                CoverUrl = bookDTO.Url,
                PublisherId = bookDTO.PublisherId,
            };
            _dataContext.books.Add(bookmainDomain);
            _dataContext.SaveChanges();
            foreach (var id in bookDTO.AuthorId)
            {
                var book_author = new BookAuthor
                {
                    idauthor = id,
                    idbook = bookmainDomain.Id,
                };
                _dataContext.book_authors.Add(book_author);
                _dataContext.SaveChanges();
            }
            return bookDTO;
        }
        //Xóa
        public Book? Delete(int id)
        {
            var bookDomain = _dataContext.books.FirstOrDefault(n=>n.Id == id);
            if (bookDomain != null)
            {
                _dataContext.books.Remove(bookDomain);
                _dataContext.SaveChanges();
            }
            return bookDomain;
        }
        //Lấy tất cả
        public List<BookWithAuthorAndPublisherDTO> GetAll()
        {
            var allbookDTO = _dataContext.books.Select(books => new BookWithAuthorAndPublisherDTO()
            {
                Id = books.Id,
                Title = books.Title,
                Description = books.Description,
                isRead = books.IsRead,
                DateRead = (bool)books.IsRead ? books.DateRead.Value : null,
                DateAdd = books.DateAdd,
                Rate = (bool)books.IsRead ? books.Rate : null,
                Genre = books.Genre,
                Url = books.CoverUrl,
                PublisherName = books.Publishers.Name,
                AuthorName = books.BookList.Select(n => n.Author.Name).ToList()
            }).ToList();
            return allbookDTO;
        }
        // Lấy theo ID
        public BookWithAuthorAndPublisherDTO GetById(int id)
        {
            var GetBookId = _dataContext.books.Where(book => book.Id == id);
            var GetBookDTO = GetBookId.Select(books => new BookWithAuthorAndPublisherDTO()
            {
                Id = books.Id,
                Title = books.Title,
                Description = books.Description,
                isRead = books.IsRead,
                DateRead = (bool)books.IsRead ? books.DateRead.Value : null,
                DateAdd = books.DateAdd,
                Rate = (bool)books.IsRead ? books.Rate : null,
                Genre = books.Genre,
                Url = books.CoverUrl,
                PublisherName = books.Publishers.Name,
                AuthorName = books.BookList.Select(n => n.Author.Name).ToList()
            }).FirstOrDefault();
            return GetBookDTO;
        }
        //Xóa
        public AddBookDTO? Put(int id, AddBookDTO addBookDTO)
        {
            var bookmainDomain = _dataContext.books.FirstOrDefault(n => n.Id == id);
            if (bookmainDomain != null)
            {
                bookmainDomain.Title = addBookDTO.Title;
                bookmainDomain.Description = addBookDTO.Description;
                bookmainDomain.IsRead = addBookDTO.isRead;
                bookmainDomain.DateRead = addBookDTO.DateRead;
                bookmainDomain.DateAdd = addBookDTO.DateAdd;
                bookmainDomain.Rate = addBookDTO.Rate;
                bookmainDomain.CoverUrl = addBookDTO.Url;
                bookmainDomain.PublisherId = addBookDTO.PublisherId;
                _dataContext.SaveChanges();
            }
            var authorDomain = _dataContext.book_authors.Where(a => a.idbook == id).ToList();
            if (authorDomain != null)
            {
                _dataContext.book_authors.RemoveRange(authorDomain);
                _dataContext.SaveChanges();
            }
            foreach (var authorid in addBookDTO.AuthorId)
            {
                var book_author = new BookAuthor()
                {
                    idbook = id,
                    idauthor = authorid,
                };
                _dataContext.book_authors.Add(book_author);
                _dataContext.SaveChanges();
            }
            return addBookDTO;
        }
    }
}
