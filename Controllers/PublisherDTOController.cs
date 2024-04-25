using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using BookPublisher.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;

namespace BookPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherDTOController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPublisherReposi reposi;
        public PublisherDTOController(DataContext dataContext, IPublisherReposi reposi)
        {
            _dataContext = dataContext;
            this.reposi = reposi;
        }
        [HttpGet("Get-All")]
        public IActionResult Get()
        {
            var allpublisher = reposi.GetAll();
            return Ok(allpublisher);
        }
        [HttpGet("Get-By-Id")]
        public IActionResult GetId(int id)
        {
            var getId = reposi.GetById(id);
            return Ok(getId);
        }
        [HttpPost("Push-Up")]
        public IActionResult Post([FromBody] AddPublisherDTO publishers)
        {
            var PushPublish = reposi.AddPublisher(publishers);
            return Ok(PushPublish);
        }
        [HttpPut("Updrage")]
        public IActionResult Put(int id,[FromBody] AddPublisherDTO publishers)
        {
            var PutPublish = reposi.UpdatePublisher(publishers,id);
            return Ok(PutPublish);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var delt = reposi.Delete(id);
            return Ok(delt);
        }
    }
}
