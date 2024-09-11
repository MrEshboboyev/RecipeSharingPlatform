namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeUpdateDTO
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string ChefId { get; set; }
    }
}
