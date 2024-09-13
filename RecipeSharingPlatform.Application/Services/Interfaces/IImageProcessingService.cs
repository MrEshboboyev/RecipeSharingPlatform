using Microsoft.AspNetCore.Http;
using RecipeSharingPlatform.Application.DTOs;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IImageProcessingService
    {
        Task<ImageDTO> ProcessImageAsync(IFormFile imageFile, Guid recipeId);
        Task DeleteImageAsync(ImageDTO imageDTO);
    }
}
