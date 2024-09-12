using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IRecipeLabelRepository : IRepository<RecipeLabel>
    {
        void Update(RecipeLabel recipeLabel);
        Task<RecipeLabel> GetLabelWithRecipesAsync(Guid labelId);
    }
}
