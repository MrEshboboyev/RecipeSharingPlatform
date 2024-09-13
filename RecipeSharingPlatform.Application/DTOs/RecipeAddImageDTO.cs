namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeAddImageDTO
    {
        public Guid RecipeId { get; set; }
        public string ChefId { get; set; }
        public ImageDTO ImageDTO { get; set; }
    }
}
