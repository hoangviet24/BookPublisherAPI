using BookPublisher.Data;
using BookPublisher.Models;
using BookPublisher.Models.DTO;
using System.Linq.Expressions;

namespace BookPublisher.Repository
{
    public class PublisherReposi : IPublisherReposi
    {
        private readonly DataContext _dataContext;
        public PublisherReposi(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public AddPublisherDTO AddPublisher(AddPublisherDTO publisher)
        {
            var addPublisher = new Publishers
            {
                Id = publisher.Id,
                Name = publisher.Name,
            };
            _dataContext.publishers.Add(addPublisher);
            _dataContext.SaveChanges();
            return publisher;
        }

        public Publishers? Delete(int id)
        {
            var publisherDomain = _dataContext.publishers.FirstOrDefault(x => x.Id == id);
            if(publisherDomain != null)
            {
                _dataContext.publishers.Remove(publisherDomain);
                _dataContext.SaveChanges(true);
            }
            return publisherDomain;
        }

        public List<publisherDTO> GetAll()
        {
            var allPublisher = _dataContext.publishers.Select(publisher=>new publisherDTO()
            {
                Id = publisher.Id,
                Name=publisher.Name,
            }).ToList();
            return allPublisher;
        }

        public publisherDTO GetById(int id)
        {
            var GetbyId = _dataContext.publishers.Where(n=>n.Id == id);
            var GetIdDTO = GetbyId.Select(p => new publisherDTO()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstOrDefault();
            return GetIdDTO;
        }

        public AddPublisherDTO UpdatePublisher(AddPublisherDTO publisher, int id)
        {
            var publishmainDomain = _dataContext.publishers.FirstOrDefault(n => n.Id == id);
            if (publishmainDomain != null)
            {
                publishmainDomain.Id = publisher.Id;
                publishmainDomain.Name = publisher.Name;
                _dataContext.SaveChanges();
            }
            return publisher;
        }
    }
}
