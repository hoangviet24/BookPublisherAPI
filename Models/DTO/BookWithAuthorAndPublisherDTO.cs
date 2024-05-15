namespace BookPublisher.Models.DTO
{
    public class BookWithAuthorAndPublisherDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? isRead { get; set; }
        public DateOnly? DateRead { get; set; }
        public int? Rate { get; set; }
        public Genre? Genre { get; set; }
        public string? Url { get; set; }
        public DateOnly? DateAdd { get; set; }
        public string PublisherName { get; set; }
        public List<string>? AuthorName { get; set; }
    }
}
