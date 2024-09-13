using RecipeSharingPlatform.Application.Common.Filters;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        void Update(Recipe recipe);
        Task AddLabelToRecipeAsync(Guid recipeId, Guid labelId);
        Task<IEnumerable<Recipe>> GetFilteredRecipesAsync(RecipeFilterParams filterParams);
        Task<IEnumerable<Recipe>> GetPagedRecipesAsync(PaginationParameters paginationParameters);
    }
}
