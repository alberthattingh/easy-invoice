using System.IO;
using System.Threading.Tasks;
using BusinessLogic.Helpers;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class GoogleCloudStorage : ICloudStorage
    {
        private readonly GoogleCredential GoogleCredential;
        private readonly StorageClient StorageClient;
        private readonly string BucketName;

        private const string DownloadPath = "../EasyInvoice/Downloads";

        public GoogleCloudStorage(AppSettings appSettings)
        {
            GoogleCredential = GoogleCredential.FromJson(JsonConvert.SerializeObject(appSettings.GoogleConfig));
            StorageClient = StorageClient.Create(GoogleCredential);
            BucketName = appSettings.GoogleConfig.CloudStorageBucket;
        }

        public async Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage)
        {
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                var dataObject = await StorageClient.UploadObjectAsync(BucketName, fileNameForStorage, null, memoryStream);
                return dataObject.MediaLink;
            }
        }

        public async Task DeleteFileAsync(string fileNameForStorage)
        {
            await StorageClient.DeleteObjectAsync(BucketName, fileNameForStorage);
        }

        public async Task<string> DownloadFileAsync(string blobName)
        {
            var path = $"{DownloadPath}/{blobName}";
            using var outputFile = File.OpenWrite(path);
            await StorageClient.DownloadObjectAsync(BucketName, blobName, outputFile);
            return path;
        }
    }
}