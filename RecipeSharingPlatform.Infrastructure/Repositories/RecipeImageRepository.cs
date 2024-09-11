using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Domain.Entities;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class RecipeImageRepository : Repository<RecipeImage>, IRecipeImageRepository
    {
        private readonly AppDbContext _db;
        public RecipeImageRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RecipeImage recipeImage)
        {
            _db.RecipeImages.Update(recipeImage);
        }
    }
}
