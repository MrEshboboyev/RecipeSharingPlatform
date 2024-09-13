namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> GetImageAsync(string fileName);
    }
}
