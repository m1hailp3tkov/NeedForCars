using Microsoft.AspNetCore.Http;

namespace NeedForCars.Services.Contracts
{
    public interface IImagesService
    {
        void UploadImage(IFormFile formImage, string filePath);
    }
}
