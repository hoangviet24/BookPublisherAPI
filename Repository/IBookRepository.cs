using BookPublisher.Models;
using BookPublisher.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.Repository
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO>  GetAll();
        BookWithAuthorAndPublisherDTO GetById(int id);
        AddBookDTO AddBook(AddBookDTO addBookDTO);
        AddBookDTO? Put(int id,AddBookDTO addBookDTO);
        Book? Delete  (int id);
    }
}
