using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
    public interface ICloudStorage
    {
        Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage);
        Task DeleteFileAsync(string fileNameForStorage);
        Task<string> DownloadFileAsync(string blobName);
    }
}