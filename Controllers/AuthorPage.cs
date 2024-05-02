using BookPublisher.Models;

namespace BookPublisher.Controllers
{
    internal class AuthorPage
    {
        public List<Author> Author { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}