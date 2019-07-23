using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IImagesService
    {
        void DeleteImagesFromDirectory(string path);

        Task UploadImageAsync(IFormFile formImage, string filePath);

        Task UploadImagesAsync(IList<IFormFile> formImages, string folderPath, string folderName);

        bool IsValidImage(IFormFile formImage);

        bool IsValidImageCollection(IEnumerable<IFormFile> formImages);
    }
}
