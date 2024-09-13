namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IImageRepository
    {
        Task<byte[]> GetImageAsync(string filePath);
        bool FileExists(string filePath);
    }
}
