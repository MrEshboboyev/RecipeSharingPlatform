using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        void Update(Recipe recipe);
        Task AddLabelToRecipeAsync(Guid recipeId, Guid labelId);
    }
}
