using Microsoft.Extensions.Configuration;
using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _imageFolderPath;

        public ImageService(IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _imageFolderPath = configuration["ImageSettings:ImageFolderPath"] ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        }

        public async Task<byte[]> GetImageAsync(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_imageFolderPath, fileName);

                if (!_unitOfWork.Image.FileExists(filePath))
                    throw new Exception("Image not found!");

                return await _unitOfWork.Image.GetImageAsync(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
