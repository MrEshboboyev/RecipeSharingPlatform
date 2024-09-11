namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipe { get; }
        IRecipeImageRepository RecipeImage { get; }
        IRecipeLabelRepository RecipeLabel { get; }

        void Save();
    }
}
