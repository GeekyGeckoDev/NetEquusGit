using Application.IPictureStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PictureStorages
{
    public class LocalPictureStorage : IPictureStorage
    {
        private readonly string _basepath;
        private readonly string _baseUrl;

        public LocalPictureStorage(string basepath, string baseUrl)
        {
            _basepath = basepath;
            _baseUrl = baseUrl?.TrimEnd('/');
            Directory.CreateDirectory(_basepath);
        }

        public async Task<string> UploadAsync (Stream data, string fileName, string ContentType, bool MakePublic = false, CancellationToken ct = default)
        {
            var safeName = Path.GetRandomFileName() + Path.GetExtension(fileName);

            var fullPath = Path.Combine(_basepath, safeName);

            using var fs = File.Create(fullPath);

            await data.CopyToAsync(fs, ct);

            return $"{_baseUrl}/{safeName}"; // what you store in DB as the picture URL

        }

        public Task DeleteAsync (string objectPath, CancellationToken ct = default)
        {
            var fileName = Path.GetFileName(new Uri(objectPath).LocalPath);

            var path = Path.Combine(_basepath, fileName);

            if(File.Exists(path)) File.Delete(path);

            return Task.CompletedTask;
        }

        public Task<Uri> GeneratedPredesignedUrlAsync(string objectKey, TimeSpan expiry, bool forUpload = false)
            => Task.FromResult<Uri>(new Uri($"{_baseUrl}/{objectKey}"));

        public string GetPublicUrl(string objectKey) => $"{_baseUrl}/{objectKey}";
    }
}
