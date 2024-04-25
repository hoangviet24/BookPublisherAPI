using BookPublisher.Data;
using BookPublisher.Models.DTO;
using BookPublisher.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDTOr : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly IAuthorRepository _authorRepository;
        public AuthorDTOr (DataContext datacontext, IAuthorRepository authorRepository)
        {
            _datacontext = datacontext;
            _authorRepository = authorRepository;
        }
        [HttpGet("Get-all")]
        public IActionResult Getall()
        {
            var allauthor = _authorRepository.GetAll();
            return Ok(allauthor);
        }
        [HttpGet("Get-By-Id")]
        public IActionResult GetId(int id)
        {
            var getid = _authorRepository.GetById(id);
            return Ok( getid );
        }
        [HttpPost("Push-Author")]
        public IActionResult Push([FromBody] AddAuthorDTO addAuthor)
        {
            var PushAuthor = _authorRepository.AddAuthor(addAuthor);
            return Ok( PushAuthor );
        }
        [HttpPut]
        public IActionResult Put(int id, [FromBody] AddAuthorDTO addAuthorDTO)
        {
            var PutAuthor = _authorRepository.Put(id, addAuthorDTO);
            return Ok( PutAuthor );
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var Delt = _authorRepository.Delete(id);
            return Ok( Delt );
        }
    }
}
