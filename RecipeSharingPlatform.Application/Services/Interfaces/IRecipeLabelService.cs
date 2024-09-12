using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeLabelService
    {
        Task<IEnumerable<LabelDTO>> GetAllLabelsAsync();
        Task<IEnumerable<RecipeDTO>> GetLabelRecipesAsync(Guid labelId);
        Task<LabelDTO> GetLabelByIdAsync(Guid labelId);
        Task CreateLabelAsync(RecipeLabelDTO recipeLabelDTO);  
        Task UpdateLabelAsync(RecipeLabelDTO recipeLabelDTO);  
        Task DeleteLabelAsync(Guid labelId);  
    }
}
