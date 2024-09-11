namespace RecipeSharingPlatform.Application.Common.Models
{
    public class CreateRecipeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
