using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookPublisher.Models
{
    public class Book
    {
        [Key] 
        public int Id { get; set; }
        public int IdList { get; set; }
        public List<BookAuthor>? BookList { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsRead { get; set; }
        public DateOnly? DateRead { get; set; }
        public int? Rate { get; set; }
        public Genre? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateOnly? DateAdd { get; set; }
        public int? PublisherId { get; set; }
        public Publishers? Publishers { get; set; }
    }
}
