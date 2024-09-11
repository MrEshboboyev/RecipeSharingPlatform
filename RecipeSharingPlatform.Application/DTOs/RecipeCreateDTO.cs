namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string ChefId { get; set; }
    }
}
