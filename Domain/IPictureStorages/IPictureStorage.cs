using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IPictureStorages
{
    public interface IPictureStorage
    {
        // Uploads a stream, returns the public (or logical) path/URL to the object
        Task<string> UploadAsync(Stream data, string fileName, string contentType, bool makePublic = false, CancellationToken ct = default);

        // Delete an object (path is what UploadAsync returned)
        Task DeleteAsync (string objectPath, CancellationToken ct = default);

        // Generate a presigned URL for uploading or downloading (server can pass it to client)
        Task<Uri> GeneratedPredesignedUrlAsync(string objectPath, TimeSpan expiry, bool forUpload = false);

        // Get a public URL for the object if it's in a public bucket (or path-style)
        string GetPublicUrl(string objectKey);
    }
}
