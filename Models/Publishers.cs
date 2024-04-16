using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookPublisher.Models
{
    public class Publishers
    {
        [Key]
        public int Id { get; set; }
        public int? BookId { get; set; }
        public List<Book>? IdBook { get; set; }
        public string? Name { get; set; }
    }
}
