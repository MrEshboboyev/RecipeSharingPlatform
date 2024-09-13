using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.Extensions.Configuration;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class ImageProcessingService : IImageProcessingService
    {
        private readonly string _imageFolderPath;
        private readonly int _thumbnailWidth;
        private readonly int _thumbnailHeight;

        public ImageProcessingService(IConfiguration configuration)
        {
            // Read configurations from appsettings.json (better than hardcoding)
            _imageFolderPath = configuration["ImageSettings:ImageFolderPath"] ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            _thumbnailWidth = int.Parse(configuration["ImageSettings:ThumbnailWidth"] ?? "150");
            _thumbnailHeight = int.Parse(configuration["ImageSettings:ThumbnailHeight"] ?? "150");

            Directory.CreateDirectory(_imageFolderPath); // Ensure the folder exists
        }

        public async Task<ImageDTO> ProcessImageAsync(IFormFile imageFile, Guid recipeId)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Image file cannot be null or empty");
            }

            // Generate a unique filename with recipe ID and extension
            var fileExtension = Path.GetExtension(imageFile.FileName);
            var uniqueFileName = $"{recipeId}_{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_imageFolderPath, uniqueFileName);

            // Save the original image
            await SaveImageFileAsync(imageFile, filePath);

            // Generate and save the thumbnail
            var thumbnailFileName = $"thumb_{uniqueFileName}";
            var thumbnailFilePath = Path.Combine(_imageFolderPath, thumbnailFileName);
            await GenerateThumbnailAsync(imageFile, thumbnailFilePath);

            // Construct the URLs
            var imageUrl = $"/images/{uniqueFileName}";
            var thumbnailUrl = $"/images/{thumbnailFileName}";

            return new ImageDTO
            {
                ImageUrl = imageUrl,
                ThumbnailUrl = thumbnailUrl
            };
        }

        private async Task SaveImageFileAsync(IFormFile imageFile, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
        }

        private async Task GenerateThumbnailAsync(IFormFile imageFile, string thumbnailFilePath)
        {
            using (Image image = Image.Load(imageFile.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(_thumbnailWidth, _thumbnailHeight));
                await image.SaveAsync(thumbnailFilePath);
            }
        }

        public async Task DeleteImageAsync(ImageDTO imageDTO)
        {
            DeleteFileIfExists(Path.Combine(_imageFolderPath, Path.GetFileName(imageDTO.ImageUrl)));
            DeleteFileIfExists(Path.Combine(_imageFolderPath, Path.GetFileName(imageDTO.ThumbnailUrl)));
            await Task.CompletedTask;
        }

        private void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
