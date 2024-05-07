using BookPublisher.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.Controllers
{
    internal class FilteringDTO
    {
        public IActionResult Name { get; set; }
        public Task<ActionResult<List<Author>>> paging { get; set; }
        public IActionResult so { get; set; }
    }
}