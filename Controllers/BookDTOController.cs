using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using BookPublisher.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDTOController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IBookRepository _bookRepository;
        public BookDTOController(DataContext dataContext, IBookRepository bookRepository)
        {
            _dataContext = dataContext;
            _bookRepository = bookRepository;
        }
        [HttpGet("Get all")]
        public IActionResult Getall()
        {
            var allbook = _bookRepository.GetAll();
            return Ok(allbook);
        }
        [HttpGet("Get-by-id")]
        public IActionResult Get(int id)
        {
            var GetBook = _bookRepository.GetById(id);
            return Ok(GetBook);
        }
        [HttpPost("Push")]
        public IActionResult Post([FromBody] AddBookDTO addBookDTO)
        {
            var PostBook = _bookRepository.AddBook(addBookDTO);
            return Ok(PostBook);
        }
        [HttpPut("Put by Id")]
        public IActionResult Put(int id,[FromBody] AddBookDTO addBookDTO)
        {
            var PutBook = _bookRepository.Put(id, addBookDTO);
            return Ok(PutBook);
        }
        [HttpDelete]
        public IActionResult Del(int id)
        {
            var Delt = _bookRepository.Delete(id);
            return Ok(Delt);
        }
    }
}
