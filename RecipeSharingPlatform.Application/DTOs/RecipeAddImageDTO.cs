using Microsoft.AspNetCore.Http;

namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeAddImageDTO
    {
        public Guid RecipeId { get; set; }
        public string ChefId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
