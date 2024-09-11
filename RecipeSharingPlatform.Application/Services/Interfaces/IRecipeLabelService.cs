using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeLabelService
    {
        Task<IEnumerable<RecipeLabel>> GetAllLabelsAsync();
        Task<IEnumerable<Recipe>> GetLabelRecipesAsync(Guid labelId);
        Task<RecipeLabel> GetLabelByIdAsync(Guid labelId);
        Task CreateLabelAsync(RecipeLabel recipeLabel);  
        Task UpdateLabelAsync(RecipeLabel recipeLabel);  
        Task DeleteLabelAsync(Guid labelId);  
    }
}
