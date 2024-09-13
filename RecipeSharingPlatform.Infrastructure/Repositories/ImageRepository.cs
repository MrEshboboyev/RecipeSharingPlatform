using RecipeSharingPlatform.Application.Common.Interfaces;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public Task<byte[]> GetImageAsync(string filePath)
        {
            return File.ReadAllBytesAsync(filePath);
        }
    }
}
