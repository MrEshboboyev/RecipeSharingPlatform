using RecipeSharingPlatform.Application.Common.Filters;
using RecipeSharingPlatform.Application.DTOs;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync();
        Task<IEnumerable<RecipeDTO>> GetAllRecipesByChefAsync(string chefId);
        Task<IEnumerable<RecipeDTO>> GetFilteredRecipesAsync(RecipeFilterParams filterParams);
        Task<PagedResult<RecipeDTO>> GetPagedRecipesAsync(PaginationParameters paginationParameters);
        Task<RecipeDTO> GetRecipeByIdAsync(Guid recipeId);
        Task CreateRecipeAsync(RecipeCreateDTO recipeCreateDTO);  
        Task UpdateRecipeAsync(RecipeUpdateDTO recipeUpdateDTO);  
        Task DeleteRecipeAsync(RecipeDeleteDTO recipeDeleteDTO);  
        Task AddLabelToRecipeAsync(RecipeAddLabelDTO addLabelDTO);

        // working with images
        Task AddImageToRecipeAsync(RecipeAddImageDTO addImageDTO);
    }
}
