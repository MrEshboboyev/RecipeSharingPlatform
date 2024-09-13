using Microsoft.AspNetCore.Http;

namespace RecipeSharingPlatform.Application.Common.Models
{
    public class AddImageToRecipeModel
    {
        public Guid RecipeId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
