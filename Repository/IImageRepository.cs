using BookPublisher.Models;

namespace BookPublisher.Services
{
    public interface IImageRepository
    {
        Image upload(Image image);
        List<Image> Getlist();
        (byte[] , string , string ) Download(int id);
        public Image? Delete(int id);
    }
}
