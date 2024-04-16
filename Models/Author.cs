using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookPublisher.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public int? IdList { get; set; }
        public List<BookAuthor>? Author_List { get; set; }
        public string? Name { get; set; }
    }
}
