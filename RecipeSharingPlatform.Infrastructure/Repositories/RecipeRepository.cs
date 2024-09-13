using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Application.Common.Filters;
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

        public async Task<IEnumerable<Recipe>> GetFilteredRecipesAsync(RecipeFilterParams filterParams)
        {
            var query = _db.Recipes.AsQueryable();

            // Filter by Keyword
            if (!string.IsNullOrEmpty(filterParams.Keyword))
            {
                query = query.Where(r => r.Title.Contains(filterParams.Keyword) 
                            || r.Description.Contains(filterParams.Keyword));
            }

            // Filter by Publication Date Range
            if (filterParams.StartDate.HasValue)
            {
                query = query.Where(r => r.PublicationDate >= filterParams.StartDate.Value);
            }
            if (filterParams.EndDate.HasValue)
            {
                query = query.Where(r => r.PublicationDate <= filterParams.EndDate.Value);
            }

            // Filter by Chef Id
            if (!string.IsNullOrEmpty(filterParams.ChefId))
            {
                query = query.Where(r => r.ChefId == filterParams.ChefId);
            }

            // Filter by Label Ids
            if (filterParams.LabelIds != null && filterParams.LabelIds.Any())
            {
                query = query.Where(r => r.Labels.Any(l => filterParams.LabelIds.Contains(l.Id)));
            }

            return await query.Include(r => r.Chef)
                            .Include(r => r.Labels)
                            .ToListAsync();
        }
    }
}
