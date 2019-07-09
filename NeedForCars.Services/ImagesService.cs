using Microsoft.AspNetCore.Http;
using NeedForCars.Services.Contracts;
using System.IO;

namespace NeedForCars.Services
{
    public class ImagesService : IImagesService
    {
        public async void UploadImage(IFormFile formImage, string path)
        {
            using(FileStream stream = File.Create(path))
            {
                await formImage.CopyToAsync(stream);
            }
        }
    }
}
