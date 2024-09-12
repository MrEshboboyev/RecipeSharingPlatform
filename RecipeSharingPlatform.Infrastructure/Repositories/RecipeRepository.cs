using Microsoft.EntityFrameworkCore;
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

        public async Task AddLabelToRecipeAsync(Guid recipeId, Guid labelId)
        {
            // get recipe and label from db
            var recipeFromDb = await _db.Recipes
                                    .Include(r => r.Labels) // with labels
                                    .FirstOrDefaultAsync(r => r.Id == recipeId);
            var labelFromDb = await _db.RecipeLabels.FirstOrDefaultAsync(rl => rl.Id == labelId);

            // attach label to recipe
            recipeFromDb.Labels.Add(labelFromDb);

            // Save Changes
            _db.SaveChanges();
        }
    }
}
