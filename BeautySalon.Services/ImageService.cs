using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautySalon.Services
{
    public class ImageService : IImageService
    {
        private readonly BlobServiceClient _blobService;
        public ImageService(BlobServiceClient blobService)
        {
            _blobService = blobService;
        }
        public async Task<IEnumerable<string>> AllImages(string containerName)
        {
            var containerClient = _blobService.GetBlobContainerClient(containerName);

            var files = new List<string>();

            var images = containerClient.GetBlobsAsync();

            await foreach (var item in images)
            {
                files.Add(item.Name);
            }

            return files;
        }

        public async Task<bool> DeleteImage(string name, string containerName)
        {
            var containerClient = _blobService.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetImage(string name, string containerName)
        {
            var containerClient = _blobService.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadImage(string name, IFormFile file, string containerName)
        {
            var containerClient = _blobService.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var res = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if (res != null)
            {
                return true;
            }
            return false;
        }
    }
}
