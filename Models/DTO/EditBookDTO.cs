﻿namespace BookPublisher.Models.DTO
{
    public class EditBookDTO
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? isRead { get; set; }
        public DateOnly? DateRead { get; set; }
        public DateOnly? DateAdd { get; set; }
        public int? Rate { get; set; }
        public Genre? Genre { get; set; }
        public string? Url { get; set; }
        public int? PublisherId { get; set; }
        public List<int>? AuthorId { get; set; }
    }
}
