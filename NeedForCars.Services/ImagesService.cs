using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NeedForCars.Services.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NeedForCars.Services
{
    public class ImagesService : IImagesService
    {
        public ImagesService()
        {
            //TODO: add logging for exception
        }

        public bool TryDeleteImagesFromDirectory(string path)
        {
            path = Path.GetDirectoryName(path);
            try
            {
                Directory.Delete(path, recursive: true);
                return true;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
        }

        public async Task UploadImageAsync(IFormFile formImage, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            
            using (FileStream stream = File.Create(path))
            {
                await formImage.CopyToAsync(stream);
            }
        }

        public async Task UploadImagesAsync(IList<IFormFile> formImages, string path, string folderName)
        {
            for(int i=0;i<formImages.Count;i++)
            {
                string _path = string.Format(path, folderName, i);

                await UploadImageAsync(formImages[i], _path);
            }
        }

        public bool IsValidImage(IFormFile formImage)
        {
            if (formImage == null) return false;

            return formImage.ContentType == "image/png" ||
                    formImage.ContentType == "image/jpeg";
        }

        public bool IsValidImageCollection(IEnumerable<IFormFile> formImages)
        {
            foreach(var formImage in formImages)
            {
                if (!IsValidImage(formImage)) return false;
            }

            return true;
        }
    }
}
