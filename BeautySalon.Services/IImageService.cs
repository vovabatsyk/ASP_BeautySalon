using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public interface IImageService
    {
        Task<string> GetImage(string name, string containerName);
        Task<IEnumerable<string>> AllImages(string containerName);
        Task<bool> UploadImage(string name, IFormFile file, string containerName);
        Task<bool> DeleteImage(string name, string containerName);
    }
}
