using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;

namespace BookPublisher.Repository
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public AddAuthorDTO AddAuthor(AddAuthorDTO addBookDTO)
        {
            var addAuthor = new Author
            {
                Id = addBookDTO.Id,
                Name = addBookDTO.Name,
            };
            _context.author.Add(addAuthor);
            _context.SaveChanges();
            
            return addBookDTO;
        }

        public Author? Delete(int id)
        {
            var authorDomain = _context.author.FirstOrDefault(n => n.Id == id);
            if (authorDomain != null)
            {
                _context.author.Remove(authorDomain);
                _context.SaveChanges();
            }
            return authorDomain;
        }

        public List<AuthorDTO> GetAll()
        {
            var allauthorDTO = _context.author.Select(author => new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name,
            }).ToList();
            return allauthorDTO;
        }

        public AuthorDTO GetById(int id)
        {
            var GetIdAuthor = _context.author.Where(a => a.Id == id);
            var GetIdDTO = GetIdAuthor.Select(author=>new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name,
            }).FirstOrDefault();
            return GetIdDTO;
        }

        public AddAuthorDTO? Put(int id, AddAuthorDTO addAuthorDTO)
        {
            var authormainDomain = _context.author.FirstOrDefault(n => n.Id == id);
            if (authormainDomain != null)
            {
                authormainDomain.Id = id;
                authormainDomain.Name = addAuthorDTO.Name;
                _context.SaveChanges();
            }
            var authorDomain = _context.book_authors.Where(a => a.idauthor == id).ToList();
            if (authorDomain != null)
            {
                _context.book_authors.RemoveRange(authorDomain);
                _context.SaveChanges();
            }
            return addAuthorDTO;
        }
    }
}
