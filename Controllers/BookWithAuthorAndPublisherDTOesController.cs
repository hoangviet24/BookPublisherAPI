using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookPublisher.Data;
using BookPublisher.Models.DTO;

namespace BookPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWithAuthorAndPublisherDTOesController : ControllerBase
    {
        private readonly DataContext _context;

        public BookWithAuthorAndPublisherDTOesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookWithAuthorAndPublisherDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithAuthorAndPublisherDTO>>> GetBookWithAuthorAndPublisherDTO()
        {
            return await _context.BookWithAuthorAndPublisherDTO.ToListAsync();
        }

        // GET: api/BookWithAuthorAndPublisherDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookWithAuthorAndPublisherDTO>> GetBookWithAuthorAndPublisherDTO(int id)
        {
            var bookWithAuthorAndPublisherDTO = await _context.BookWithAuthorAndPublisherDTO.FindAsync(id);

            if (bookWithAuthorAndPublisherDTO == null)
            {
                return NotFound();
            }

            return bookWithAuthorAndPublisherDTO;
        }

        // PUT: api/BookWithAuthorAndPublisherDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookWithAuthorAndPublisherDTO(int id, BookWithAuthorAndPublisherDTO bookWithAuthorAndPublisherDTO)
        {
            if (id != bookWithAuthorAndPublisherDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookWithAuthorAndPublisherDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookWithAuthorAndPublisherDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookWithAuthorAndPublisherDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookWithAuthorAndPublisherDTO>> PostBookWithAuthorAndPublisherDTO(BookWithAuthorAndPublisherDTO bookWithAuthorAndPublisherDTO)
        {
            _context.BookWithAuthorAndPublisherDTO.Add(bookWithAuthorAndPublisherDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookWithAuthorAndPublisherDTO", new { id = bookWithAuthorAndPublisherDTO.Id }, bookWithAuthorAndPublisherDTO);
        }

        // DELETE: api/BookWithAuthorAndPublisherDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookWithAuthorAndPublisherDTO(int id)
        {
            var bookWithAuthorAndPublisherDTO = await _context.BookWithAuthorAndPublisherDTO.FindAsync(id);
            if (bookWithAuthorAndPublisherDTO == null)
            {
                return NotFound();
            }

            _context.BookWithAuthorAndPublisherDTO.Remove(bookWithAuthorAndPublisherDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookWithAuthorAndPublisherDTOExists(int id)
        {
            return _context.BookWithAuthorAndPublisherDTO.Any(e => e.Id == id);
        }
    }
}
