using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using BookPublisher.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        [HttpGet("Get-By-Sortby")]
        public IActionResult Get()
        {
            var post = _authorRepository.GetAll().OrderByDescending(a=>a.Id).ToList();
            return Ok(post);
        }
        [HttpGet("Get-Filter")]
        public IActionResult Get(string Name)
        {
            var getid = _authorRepository.GetByName(Name);
            return Ok(getid);
        }
        [HttpGet("{page}")]
        public async Task<ActionResult<List<Author>>> GetAuthor(int page)
        {
            if (_datacontext.author == null)
            {
                return NotFound();
            }
            var pageResults = 2f;
            var pageCount = Math.Ceiling(_datacontext.author.Count() / pageResults);
            var author = await _datacontext.author
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new AuthorPage
            {
                Author = author,
                CurrentPage = page,
                Pages = (int)pageCount,
            };
            Log.Information("Student Page => {@response}", response);
            return Ok(response);
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
