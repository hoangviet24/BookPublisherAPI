using Azure;
using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using BookPublisher.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Drives.Item.Items.Item.Workbook.Functions.Var_P;
using Microsoft.Graph.Models.Security;
using NuGet.Versioning;
using Serilog;
using System.Drawing.Printing;
using System.Runtime.Serialization;
using System.Security.Permissions;

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
        [HttpGet("Filter-page-sort")]
        public IActionResult Filtering(string? name,int page, float pageSize,bool isAccess) 
        {
            if (ModelState.IsValid)
            {
                var getid = _authorRepository.GetByName(name);
                return Ok(getid);
            }
            if (ModelState.IsValid)
            {
                switch (isAccess)
                {
                    case true:
                        var post = _authorRepository.GetAll().OrderByDescending(a => a.Id).ToList();
                        return Ok(post);
                    case false:
                        var post1 = _authorRepository.GetAll().OrderBy(a => a.Id).ToList();
                        return Ok(post1);
                }
            }
            if (ModelState.IsValid)
            {
                if (_datacontext.author == null)
                {
                    return NotFound();
                }

                if (_datacontext.author.Count() == 0)
                {
                    return NoContent(); // No data found
                }

                int pageCount = (int)Math.Ceiling(_datacontext.author.Count() / pageSize);

                if (page < 1 || page > pageCount)
                {
                    return BadRequest("Invalid page number"); // Handle invalid page requests
                }

                int skip = (page - 1) * (int)pageSize;
                int take = (int)pageSize;

                var author = _datacontext.author
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                var response = new AuthorPage
                {
                    Author = author,
                    CurrentPage = page,
                    Pages = pageCount,
                };

                Log.Information("Student Page => {@response}", response);

                return Ok(response);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("Filter")]
        public IActionResult GetFiltering( string name)
        {
            if (ModelState.IsValid)
            {
                var getid = _authorRepository.GetByName(name);
                return Ok(getid);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("Sortby")]
        public IActionResult GetSortbyPaging(bool isAccess)
        {
            if (ModelState.IsValid)
            {
                switch (isAccess)
                {
                    case true:
                        var post = _authorRepository.GetAll().OrderByDescending(a => a.Id).ToList();
                        return Ok(post);
                    case false:
                        var post1 = _authorRepository.GetAll().OrderBy(a => a.Id).ToList();
                        return Ok(post1);
                }
            }
            else { return BadRequest(); }
        }
        [HttpGet("Paging")]
        public IActionResult GetPaging(int page, float pageSize)
        {
            if (ModelState.IsValid)
            {
                if (_datacontext.author == null)
                {
                    return NotFound();
                }

                if (_datacontext.author.Count() == 0)
                {
                    return NoContent(); // No data found
                }

                int pageCount = (int)Math.Ceiling(_datacontext.author.Count() / pageSize);

                if (page < 1 || page > pageCount)
                {
                    return BadRequest("Invalid page number"); // Handle invalid page requests
                }

                int skip = (page - 1) * (int)pageSize;
                int take = (int)pageSize;

                var author = _datacontext.author
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                var response = new AuthorPage
                {
                    Author = author,
                    CurrentPage = page,
                    Pages = pageCount,
                };

                Log.Information("Student Page => {@response}", response);

                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
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
