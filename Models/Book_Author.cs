using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Models
{
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public int? idbook { get; set; }
        public Book? Book { get; set; }
        public int? idauthor { get; set; }
        public Author? Author { get; set; }
    }
}
