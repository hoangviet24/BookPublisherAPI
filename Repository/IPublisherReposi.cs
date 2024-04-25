using BookPublisher.Models;
using BookPublisher.Models.DTO;

namespace BookPublisher.Repository
{
    public interface IPublisherReposi
    {
        List<publisherDTO> GetAll();
        publisherDTO GetById(int id);
        AddPublisherDTO AddPublisher(AddPublisherDTO publisher);
        AddPublisherDTO UpdatePublisher(AddPublisherDTO publisher,int id);
        Publishers? Delete(int id);
    }
}
