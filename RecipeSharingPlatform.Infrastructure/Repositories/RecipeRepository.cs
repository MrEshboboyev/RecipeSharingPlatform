using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Domain.Entities;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly AppDbContext _db;
        public RecipeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Recipe recipe)
        {
            _db.Recipes.Update(recipe);
        }
    }
}
