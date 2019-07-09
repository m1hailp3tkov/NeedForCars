using Microsoft.AspNetCore.Http;
using NeedForCars.Services.Contracts;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace NeedForCars.Services
{
    public class ImagesService : IImagesService
    {
        public async void UploadImage(IFormFile formImage, string path)
        {
            using (FileStream stream = File.Create(path))
            {
                await formImage.CopyToAsync(stream);
            }
        }

        public bool IsValidImage(IFormFile formImage)
        {
            if(!(formImage.ContentType == "image/png" || formImage.ContentType == "image/jpeg"))
            {
                return false;
            }

            return true;
        }
    }
}
