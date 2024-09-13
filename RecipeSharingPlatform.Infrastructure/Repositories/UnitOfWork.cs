using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IRecipeRepository Recipe { get; private set; }
        public IRecipeImageRepository RecipeImage { get; private set; }
        public IRecipeLabelRepository RecipeLabel { get; private set; }
        public IImageRepository Image { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Recipe = new RecipeRepository(db);
            RecipeImage = new RecipeImageRepository(db);
            RecipeLabel = new RecipeLabelRepository(db);
            Image = new ImageRepository();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
