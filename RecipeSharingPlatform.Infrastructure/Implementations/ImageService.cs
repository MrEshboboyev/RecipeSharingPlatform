using Microsoft.Extensions.Configuration;
using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _imageFolderPath;

        public ImageService(IConfiguration configuration,
            IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
            _imageFolderPath = configuration["ImageSettings:ImageFolderPath"] ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        }

        public async Task<byte[]> GetImageAsync(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_imageFolderPath, fileName);

                if (!_imageRepository.FileExists(filePath))
                    throw new Exception("Image not found!");

                return await _imageRepository.GetImageAsync(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
