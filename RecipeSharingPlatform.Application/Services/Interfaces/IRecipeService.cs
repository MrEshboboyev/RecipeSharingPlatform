using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<IEnumerable<Recipe>> GetAllRecipesByUserAsync();
        Task CreateRecipeAsync(RecipeCreateDTO recipeCreateDTO);  
        Task UpdateRecipeAsync(RecipeUpdateDTO recipeUpdateDTO);  
        Task DeleteRecipeAsync(RecipeDeleteDTO recipeDeleteDTO);  
    }
}
