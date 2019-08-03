using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IImagesService
    {
        bool TryDeleteImage(string path);

        bool TryDeleteImagesFromDirectory(string path);

        Task UploadImageAsync(IFormFile formImage, string filePath);

        Task UploadImagesAsync(IList<IFormFile> formImages, string folderPath, string folderName);

        bool IsValidImage(IFormFile formImage);

        bool IsValidImageCollection(IEnumerable<IFormFile> formImages);

        IEnumerable<string> GetImageUrls(string path, string id);
    }
}
