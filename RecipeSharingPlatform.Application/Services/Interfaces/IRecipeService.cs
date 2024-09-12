using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync();
        Task<IEnumerable<RecipeDTO>> GetAllRecipesByChefAsync(string chefId);
        Task CreateRecipeAsync(RecipeCreateDTO recipeCreateDTO);  
        Task UpdateRecipeAsync(RecipeUpdateDTO recipeUpdateDTO);  
        Task DeleteRecipeAsync(RecipeDeleteDTO recipeDeleteDTO);  
        Task AddLabelToRecipeAsync(RecipeAddLabelDTO addLabelDTO);
    }
}
