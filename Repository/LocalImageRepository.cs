using BookPublisher.Models;
using System.Text;
using BookPublisher.Data;
namespace BookPublisher.Services
{
    public class LocalImageRepository:IImageRepository
    {
        private readonly IHttpContextAccessor _contac;
        private readonly IWebHostEnvironment _env;
        private readonly DataContext context;
        public LocalImageRepository(IHttpContextAccessor contac, IWebHostEnvironment env, DataContext context)
        {
            _contac = contac;
            _env = env;
            this.context = context;
        }

        public Image? Delete(int id)
        {
            var find = context.Images.FirstOrDefault(x => x.Id == id);
            context.Images.Remove(find);
            context.SaveChanges();
            return find;
        }

        public (byte[] , string , string ) Download(int id)
        {
            try
            {
                var FileById = context.Images.Where(x=>x.Id== id).FirstOrDefault();
                var path = Path.Combine(_env.ContentRootPath, "Images", $"{FileById.FileName},{FileById.FileExtension}");
                var stream = File.ReadAllBytes(path);
                var fileName = FileById.FileName + FileById.FileExtension;
                return (stream, "application/octet-stream", fileName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<Image> Getlist()
        {
            var getall = context.Images.ToList();
            return getall;
        }

        public Image upload(Image image)
        {
            var localFilePath = Path.Combine(_env.ContentRootPath, "Images",
                $"{image.FileName},{image.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            image.File.CopyTo(stream);
            var urlFilePath = $"{_contac.HttpContext.Request.Scheme}:" +
                $"{_contac.HttpContext.Request.Host}" +
                $"{_contac.HttpContext.Request.PathBase}" +
                $"{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            context.Images.Add(image);
            context.SaveChanges();  

            return image;
        }
    }
}
