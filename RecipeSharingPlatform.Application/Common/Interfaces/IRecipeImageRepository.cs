using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IRecipeImageRepository : IRepository<RecipeImage>
    {
        void Update(RecipeImage recipeImage);
    }
}
