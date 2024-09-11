namespace RecipeSharingPlatform.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipe { get; }

        void Save();
    }
}
