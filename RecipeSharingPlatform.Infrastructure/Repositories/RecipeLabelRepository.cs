using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Domain.Entities;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class RecipeLabelRepository : Repository<RecipeLabel>, IRecipeLabelRepository
    {
        private readonly AppDbContext _db;
        public RecipeLabelRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RecipeLabel recipeLabel)
        {
            _db.RecipeLabels.Update(recipeLabel);
        }
    }
}
