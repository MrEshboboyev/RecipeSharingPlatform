namespace RecipeSharingPlatform.Domain.Entities
{
    public class RecipeImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
