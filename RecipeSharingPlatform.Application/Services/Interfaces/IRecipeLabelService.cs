using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeLabelService
    {
        Task<IEnumerable<RecipeLabel>> GetAllLabelsAsync();
        Task<RecipeLabel> GetLabelWithRecipesAsync(Guid labelId);
        Task<RecipeLabel> GetLabelByIdAsync(Guid labelId);
        Task CreateLabelAsync(RecipeLabelDTO recipeLabelDTO);  
        Task UpdateLabelAsync(RecipeLabelDTO recipeLabelDTO);  
        Task DeleteLabelAsync(Guid labelId);  
    }
}
