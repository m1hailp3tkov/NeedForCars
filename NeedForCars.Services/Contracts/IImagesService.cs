using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IImagesService
    {
        void UploadImage(IFormFile formImage, string filePath);

        bool IsValidImage(IFormFile formImage);

        void EnsureDirectoryExists(string fileName);
    }
}
