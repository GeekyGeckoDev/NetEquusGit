using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using Domain.IPictureStorages;
using Microsoft.Extensions.Configuration;


namespace Application.Services.PictureStorageServices
{
    public class BackblazeS3PictureStorage : IPictureStorage
    {
        private readonly IAmazonS3 _s3;

        private readonly string _bucket;

        private readonly string _endpoint;

        public BackblazeS3PictureStorage(IAmazonS3 s3Client, IConfiguration cfg)
        {
            _s3 = s3Client;
            _bucket = cfg["Backblaze:BucketName"];
            _endpoint = cfg["Backblaze:S3Endpoint"].TrimEnd('/');
        }

        public async Task<string> UploadAsync (Stream data, string fileName, string contentType, bool makePublic = false, CancellationToken ct = default)
        {
            var key = $"{Guid.NewGuid():N}-{SanitizeFileName(fileName)}";

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = key,
                InputStream = data,
                ContentType = contentType,
                AutoCloseStream = true
            };

            if (makePublic)
                putRequest.CannedACL = S3CannedACL.PublicRead;

            var res = await _s3.PutObjectAsync(putRequest, ct);
            // If bucket is public or you set public ACL, the public URL is:
            return GetPublicUrl(key);
        }

        public async Task DeleteAsync(string objectPath, CancellationToken ct = default)
        {
            var key = ExtractKeyFromPath(objectPath);
            await _s3.DeleteObjectAsync(new DeleteObjectRequest { BucketName = _bucket, Key = key }, ct);
        }

        public Task<Uri> GeneratedPredesignedUrlAsync(string objectKey, TimeSpan expiry, bool forUpload = false)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucket,
                Key = objectKey,
                Expires = DateTime.UtcNow.Add(expiry),
                Verb = forUpload ? HttpVerb.PUT : HttpVerb.GET
            };

            var url = _s3.GetPreSignedURL(request);
            return Task.FromResult(new Uri(url));
        }

        public string GetPublicUrl(string objectKey)
        {
            // Path-style URL (works with ForcePathStyle = true in client config)
            return $"{_endpoint}/{_bucket}/{Uri.EscapeDataString(objectKey)}";
        }

        // small helpers (simple sanitization, extraction)
        private string SanitizeFileName(string fn) => fn.Replace(" ", "-").Replace("/", "-");
        private string ExtractKeyFromPath(string path) => Path.GetFileName(new Uri(path).LocalPath);
    }
}
