using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookPublisher.Data;
using BookPublisher.Models.DTO;
using BookPublisher.Models;

namespace BookPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWithAuthorAndPublisherDTOesController : ControllerBase
    {
        private readonly DataContext _context;

        public BookWithAuthorAndPublisherDTOesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookWithAuthorAndPublisherDTOes
        [HttpGet]
        public IActionResult GetAll()
        {
            var allbookDomain = _context.books;
            var allbookDTO = allbookDomain.Select(books => new BookWithAuthorAndPublisherDTO()
            {
                Id = books.Id,
                Title = books.Title,
                Description = books.Description,
                isRead = books.IsRead,
                DateRead = (bool)books.IsRead ? books.DateRead.Value : null,
                Rate = (bool)books.IsRead ? books.Rate : null,
                Genre = books.Genre,
                Url = books.CoverUrl,
                PublisherId = books.Publishers.Name,
                AuthorName = books.BookList.Select(n => n.Author.Name).ToList()
            });
            return Ok(allbookDTO);
        }

        // GET: api/BookWithAuthorAndPublisherDTOes/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var GetBookId = _context.books.Where(book => book.Id == id);
            if(GetBookId == null)
            {
                return NotFound();
            }
            var GetBookDTO = GetBookId.Select(books => new BookWithAuthorAndPublisherDTO()
            {
                Id = books.Id,
                Title = books.Title,
                Description = books.Description,
                isRead = books.IsRead,
                DateRead = (bool)books.IsRead ? books.DateRead.Value : null,
                Rate = (bool)books.IsRead ? books.Rate : null,
                Genre = books.Genre,
                Url = books.CoverUrl,
                PublisherId = books.Publishers.Name,
                AuthorName = books.BookList.Select(n => n.Author.Name).ToList()
            });
            return Ok(GetBookDTO);
        }

        // PUT: api/BookWithAuthorAndPublisherDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddBookDTO addBookDTO)
        {
            var bookmainDomain = _context.books.FirstOrDefault(n => n.Id == id);
            if(bookmainDomain != null)
            {
                bookmainDomain.Title = addBookDTO.Title;
                bookmainDomain.Description = addBookDTO.Description;
                bookmainDomain.IsRead = addBookDTO.isRead;
                bookmainDomain.DateRead = addBookDTO.DateRead;
                bookmainDomain.DateAdd = addBookDTO.DateAdd;
                bookmainDomain.Rate = addBookDTO.Rate;
                bookmainDomain.CoverUrl = addBookDTO.Url;
                bookmainDomain.PublisherId = addBookDTO.PublisherId;
                _context.SaveChanges();
            }
            var authorDomain = _context.book_authors.Where(a => a.idbook == id).ToList();
            if(authorDomain != null)
            {
                _context.book_authors.RemoveRange(authorDomain);
                _context.SaveChanges();
            }
            foreach(var authorid in addBookDTO.AuthorId)
            {
                var book_author = new BookAuthor()
                {
                    idbook = id,
                    idauthor = authorid,
                };
                _context.book_authors.Add(book_author);
                _context.SaveChanges();
            }
            return Ok(addBookDTO);
        }

        // POST: api/BookWithAuthorAndPublisherDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] AddBookDTO bookDTO)
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
            _context.books.Add(bookmainDomain);
            _context.SaveChanges();
            foreach(var id in bookDTO.AuthorId)
            {
                var book_author = new BookAuthor
                {
                    idauthor = id,
                    idbook = bookmainDomain.Id,
                };
                _context.book_authors.Add(book_author);
                _context.SaveChanges();
            }
            return Ok();
        }

        // DELETE: api/BookWithAuthorAndPublisherDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookWithAuthorAndPublisherDTO(int id)
        {
            var bookWithAuthorAndPublisherDTO = await _context.books.FindAsync(id);
            if (bookWithAuthorAndPublisherDTO == null)
            {
                return NotFound();
            }

            _context.books.Remove(bookWithAuthorAndPublisherDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool BookWithAuthorAndPublisherDTOExists(int id)
        //{
        //    return _context.BookWithAuthorAndPublisherDTO.Any(e => e.Id == id);
        //}
    }
}
